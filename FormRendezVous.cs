using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace GestionCabinetMedical
{
    [Serializable]
    public partial class FormRendezVous : Form
    {
        FormDashboard f = new FormDashboard();
        CabinetMedical cm = new CabinetMedical();


        public FormRendezVous()
        {
            InitializeComponent();
        }

        public FormRendezVous(FormDashboard f) : this()
        {
            this.f = f;
        }

        public void chargerHeureCombo()
        {
            for (int i = 8; i < 18; i++)
            {
                cmbHours.Items.Add(i.ToString());
            }
            for (int i = 00; i < 60; i += 15)
            {
                cmbMinutes.Items.Add(i.ToString());
            }
        }

        private void Vider()
        {
            this.txtCodePatient.Text = null;
            this.dtpDateRV.Value = DateTime.Now.Date;
            this.lblnote.Visible = false;
            this.cmbHours.Text = null;
            this.cmbMinutes.Text = null;
            lblnote.Visible = false;
            dgRendezVous.ClearSelection();
        }

        private void FormRendezVous_Load(object sender, EventArgs e)
        {
            ImporterDataFromFile();
            this.chargerHeureCombo();
            this.Vider();
        }

        private void BtnAjouter_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodePatient.Text == "") throw new Exception("Remplir tout les chams!");
                
                    int codePatient = int.Parse(this.txtCodePatient.Text);

                if (this.dtpDateRV.Value.Date < DateTime.Now.Date)
                {
                    this.lblnote.Visible = true;
                    throw new Exception("Le date qui vous avez entre est invaide");
                }
                DateTime dateRendezVous = this.dtpDateRV.Value.Date;

                if (cmbHours.SelectedItem == null || cmbMinutes.SelectedItem == null)
                {
                    this.lblnote.Visible = true;
                    throw new Exception("Remplir tout les chams !");
                }
                string heureRendezVous = cmbHours.Text + ":" + cmbMinutes.Text;

                string observation = txtObservation.Text;

                Patient p = this.f.Cbm.TrouverPatient(codePatient);
                if (p == null) throw new Exception("Patient n'est pas trouver !!");
                if (p.RendezVous != null) throw new Exception("Patient a deja un rendez vous!");

                RendezVous r = new RendezVous(codePatient, dateRendezVous, heureRendezVous, observation);
                this.f.Cbm.AjouterRDV(r);
                p.RendezVous = r;
                this.ChargerData();
                this.Vider();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK); }
        }

        public void ImporterDataFromFile()
        {
            if (File.Exists("RendezVous.bin"))
            {
                BinaryFormatter f = new BinaryFormatter();
                FileStream fs = new FileStream("RendezVous.bin", FileMode.Open, FileAccess.Read);
                this.f.Cbm.ListRendezVous = (List<RendezVous>)f.Deserialize(fs);
                fs.Close();
                this.ChargerData();
            }
        }
        public void SaveDataInFile()
        {
            BinaryFormatter f = new BinaryFormatter();
            FileStream fs = new FileStream("RendezVous.bin", FileMode.Create, FileAccess.Write);
            f.Serialize(fs, this.f.Cbm.ListRendezVous);
            fs.Close();
        }
        private void ChargerData()
        {
            this.dgRendezVous.Rows.Clear();
            foreach (RendezVous rv in this.f.Cbm.ListRendezVous)
            {
                this.dgRendezVous.Rows.Add(rv.CodePatient,rv.DateRendezVous.ToShortDateString(), rv.HeureRendezVous, rv.Observation);
            }
        }

        private void BtnExporter_Click(object sender, EventArgs e)
        {
            this.SaveDataInFile();
        }

        private void BtnImporter_Click(object sender, EventArgs e)
        {
            this.ImporterDataFromFile();
        }

        private void BtnFermer_Click(object sender, EventArgs e)
        {
            this.SaveDataInFile();
            this.Close();
        }

        private void BtnSupprimer_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult res = MessageBox.Show("Voullez vous vraiment supprimer ce rendez vous ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (res == DialogResult.OK)
                {
                    int indice = int.Parse(txtCodePatient.Text);
                    RendezVous rv = this.f.Cbm.TrouverPatient(indice).RendezVous;
                    if (rv!=null)
                    {
                        this.f.Cbm.TrouverPatient(indice).RendezVous = null;
                        this.f.Cbm.ListRendezVous.Remove(this.f.Cbm.TrouverRendezVous(indice));
                        this.ChargerData();
                        this.Vider();
                    }
                    throw new Exception("Patient n'a pas un rendez vous  ! ");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Gb1_Enter(object sender, EventArgs e)
        {

        }

        private void TxtCodePatient_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
