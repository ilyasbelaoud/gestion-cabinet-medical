using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;

namespace GestionCabinetMedical
{
    [Serializable]

    public partial class FormDashboard : Form
    {
        CabinetMedical cbm = new CabinetMedical();
        public CabinetMedical Cbm { get => cbm; set => cbm = value; }
        public FormDashboard()
        {
            InitializeComponent();
            this.timer1.Start();

        }
        private void ChargerCombo()
        {
            this.cmbRecherchrePar.Items.Add("Code Patient");
            this.cmbRecherchrePar.Items.Add("Nom Complet");
        }

        private void FormDashboard_Load(object sender, EventArgs e)
        {
            this.ChargerCombo();
            FormPatient fp = new FormPatient(this);
            FormRendezVous fr = new FormRendezVous(this);
            fp.ImporterDataFromFile();
            fr.ImporterDataFromFile();
            this.lblNombrePatient.Text = this.Cbm.ListPatient.Count.ToString();
        }

        private void BtnRechercher_Click(object sender, EventArgs e)


        {
            try
            {
                if ((cmbRecherchrePar.SelectedItem == null) || (txtRechercher.Text == ""))
                {
                    throw new Exception("Remplir tout les chams!");
                }
                else if (cmbRecherchrePar.Text == "Code Patient")
                {
                    Patient p = this.Cbm.TrouverPatient(int.Parse(txtRechercher.Text));
                    if (p == null) throw new Exception("Patient n'est pas trouver !!");
                    txtCodePatient.Text = p.CodePatient.ToString();
                    txtNom.Text = p.Nom;
                    txtPrenom.Text = p.Prenom;
                    dtpDateNaissance.Text = p.DateNaissance.ToShortDateString();
                    if (p.Sexe == "M") rbm.Checked = true;
                    else rbf.Checked = true;
                    txtAdresse.Text = p.Adresse;
                    txtTelephone.Text = p.Tel;
                    txtEmail.Text = p.Email;
                    lvRendezVous.Items.Clear();
                    RendezVous rv = this.Cbm.TrouverRendezVous(p.CodePatient);
                    if (rv != null)
                    {
                        ListViewItem lvi = new ListViewItem(rv.CodePatient.ToString());
                        lvi.SubItems.Add(rv.DateRendezVous.ToShortDateString());
                        lvi.SubItems.Add(rv.HeureRendezVous);
                        lvi.SubItems.Add(rv.Observation);
                        lvRendezVous.Items.Add(lvi);
                    }
                }
                else if (cmbRecherchrePar.Text == "Nom Complet")
                {
                    Patient p = this.Cbm.TrouverPatient(txtRechercher.Text);
                    if (p == null) throw new Exception("Patient n'est pas trouver !!");
                    txtCodePatient.Text = p.CodePatient.ToString();
                    txtNom.Text = p.Nom;
                    txtPrenom.Text = p.Prenom;
                    dtpDateNaissance.Text = p.DateNaissance.ToShortDateString();
                    if (p.Sexe == "M") rbm.Checked = true;
                    else rbf.Checked = true;
                    txtAdresse.Text = p.Adresse;
                    txtTelephone.Text = p.Tel;
                    txtEmail.Text = p.Email;
                    lvRendezVous.Items.Clear();
                    RendezVous rv = this.Cbm.TrouverRendezVous(p.CodePatient);
                    if (rv != null)
                    {
                        ListViewItem lvi = new ListViewItem(rv.CodePatient.ToString());
                        lvi.SubItems.Add(rv.DateRendezVous.ToShortDateString());
                        lvi.SubItems.Add(rv.HeureRendezVous);
                        lvi.SubItems.Add(rv.Observation);
                        lvRendezVous.Items.Add(lvi);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    
    public void Vider()
    {
        this.lvRendezVous.Items.Clear();
        this.txtRechercher.Text = null;
        txtNom.Text = null;
        txtPrenom.Text = null;
        txtAdresse.Text = null;
        txtEmail.Text = null;
        txtTelephone.Text = null;
        rbf.Checked = false;
        rbm.Checked = false;
        txtCodePatient.Text = null;
        dtpDateNaissance.Value = DateTime.Now.Date;
    }

        private void Timer1_Tick(object sender, EventArgs e)
        {

            this.lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
            this.lblToday.Text = DateTime.Now.ToString("dd MMMM yyyy");
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
