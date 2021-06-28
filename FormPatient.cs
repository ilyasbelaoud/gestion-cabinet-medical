using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GestionCabinetMedical
{
    [Serializable]
    public partial class FormPatient : Form
    {
        FormDashboard f = new FormDashboard();
        CabinetMedical cm = new CabinetMedical();

        private static int nbr;

        public FormPatient()
        {
            InitializeComponent();
        }
        public FormPatient(FormDashboard f):this()
        {
            this.f=f;
        }
        private void FormPatient_Load(object sender, EventArgs e)
        {
            ImporterDataFromFile();
            this.Vider();
        }

        private void BtnAjouter_Click(object sender, EventArgs e)
        {
            try
            {
                if ((this.txtNom.Text.Length < 3) || this.txtNom.Text.Length > 15)
                {
                    this.lblnote.Visible = true;
                    //lblnote contient le message suivant : "les champs contains "*" sont obligatoire"
                    throw new Exception("Le nom qui vous avez entre est invaide");
                }
                string nom = this.txtNom.Text;

                if ((this.txtPrenom.Text.Length < 3) || this.txtPrenom.Text.Length > 15)
                {
                    this.lblnote.Visible = true;
                    throw new Exception("Le prenom qui vous avez entre est invaide");
                }
                string prenom = this.txtPrenom.Text;

                if (this.dtpDateNaissance.Value.Date > DateTime.Now.Date)
                {
                    this.lblnote.Visible = true;
                    throw new Exception("Le date qui vous avez entre est invaide");
                }
                DateTime dateNaissance = this.dtpDateNaissance.Value.Date;

                string sexe;
                if (this.rbm.Checked == false && this.rbf.Checked == false)
                {
                    this.lblnote.Visible = true;
                    throw new Exception("Please select your gender");
                }
                if (this.rbm.Checked == true)
                {sexe = rbm.Text;}
                else sexe = rbf.Text;
                
                string adresse = this.txtAdresse.Text;

                if (txtTelephone.Text.Length < 5 || txtTelephone.Text.Length > 15)
                {
                    this.lblnote.Visible = true;
                    throw new Exception("telephone incorrect");
                }
                string tele = txtTelephone.Text;

                string email = this.txtEmail.Text;

                nbr = this.f.Cbm.ListPatient.Count;
                int codePatient = nbr++;

                Patient pat = new Patient(codePatient, nom, prenom, dateNaissance, sexe, adresse, tele, email);

                foreach (Patient p in this.f.Cbm.ListPatient)
                {
                    if (pat.Equals(p)) throw new Exception("Patient est deja exist");
                }

                this.f.Cbm.ListPatient.Add(pat);
                this.ChargerData();
                this.Vider();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
        private void TxtTelephone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsDigit(e.KeyChar)) || (char.IsControl(e.KeyChar))) e.Handled = false;
            else e.Handled = true;
        }
        private void TxtNom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsLetter(e.KeyChar)) || (char.IsControl(e.KeyChar))) e.Handled = false; 
            else e.Handled = true; 
        }
        private void TxtPrenom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsLetter(e.KeyChar)) || (char.IsControl(e.KeyChar))) e.Handled = false; 
            else e.Handled = true; 
        }

        private void ChargerData()
        {
            this.dgPatient.Rows.Clear();
            this.cmbCodePatient.Items.Clear();
            foreach (Patient p in this.f.Cbm.ListPatient)
            {
                this.cmbCodePatient.Items.Add(p.CodePatient);
                this.dgPatient.Rows.Add(p.CodePatient, p.Nom, p.Prenom, p.DateNaissance.ToShortDateString(), p.Sexe, p.Adresse, p.Tel, p.Email);
            }
        }
        
        private void Vider()
        {
            txtNom.Text = null;
            txtPrenom.Text = null;
            txtAdresse.Text = null;
            txtEmail.Text = null;
            txtTelephone.Text = null;
            rbf.Checked = false;
            rbm.Checked = false;
            cmbCodePatient.Text = null;
            dtpDateNaissance.Value = DateTime.Now.Date;
            lblnote.Visible = false;
            dgPatient.ClearSelection();
        }
        
        private void BtnSupprimer_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Voullez vous vraiment supprimer ce patient ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (res == DialogResult.OK)
            {
                try
                {
                    //supprimer par codePatient
                    int indice = int.Parse(cmbCodePatient.SelectedItem.ToString());
                    Patient p = this.f.Cbm.TrouverPatient(indice);
                    this.f.Cbm.ListPatient.Remove(p);
                    if(p.RendezVous!=null) this.f.Cbm.ListRendezVous.Remove(p.RendezVous);
                    this.ChargerData();
                    this.Vider();

                    //une autre metode - supprimer par datatagrid
                    //int indice = dgPatient.CurrentCell.RowIndex;
                    //for (int i = 0; i < this.f.Cbm.ListPatient.Count; i++)
                    //{
                    //    if (this.f.Cbm.ListPatient[i].CodePatient.ToString() == dgPatient.Rows[indice].Cells[0].Value.ToString())
                    //    {
                    //        RendezVous rv = this.f.Cbm.TrouverRendezVous(this.f.Cbm.ListPatient[i].CodePatient);
                    //        if (rv!=null) this.f.Cbm.ListRendezVous.Remove(rv);
                    //        this.f.Cbm.ListPatient.RemoveAt(i);
                    //    }
                    //}
                    //dgPatient.Rows.RemoveAt(indice);
                    //this.Vider();
                }
                catch (Exception){}
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
        public void ImporterDataFromFile()
        {
            if (File.Exists("DataBase.bin"))
            {
                BinaryFormatter f = new BinaryFormatter();
                FileStream fs = new FileStream("DataBase.bin", FileMode.Open, FileAccess.Read);
                this.f.Cbm.ListPatient = (List<Patient>)f.Deserialize(fs);
                ChargerData();
                fs.Close();
            }
        }

        public void SaveDataInFile()
        {
            BinaryFormatter f = new BinaryFormatter();
            FileStream fs = new FileStream("DataBase.bin", FileMode.OpenOrCreate, FileAccess.Write);
            f.Serialize(fs, this.f.Cbm.ListPatient);
            fs.Close();
        }

        private void BtnFermer_Click(object sender, EventArgs e)
        {
            this.SaveDataInFile();
            this.Close();
        }

        private void DgPatient_Click(object sender, EventArgs e)
        {
            try
            {
                int indice = dgPatient.CurrentCell.RowIndex;
                this.cmbCodePatient.SelectedItem = dgPatient.Rows[indice].Cells[0].Value;
                this.txtNom.Text = dgPatient.Rows[indice].Cells[1].Value.ToString();
                this.txtPrenom.Text = dgPatient.Rows[indice].Cells[2].Value.ToString();
                this.dtpDateNaissance.Text = dgPatient.Rows[indice].Cells[3].Value.ToString();
                if (dgPatient.Rows[indice].Cells[4].Value.ToString() == "M") { this.rbm.Checked = true; }
                else { this.rbf.Checked = true; }
                this.txtAdresse.Text = dgPatient.Rows[indice].Cells[5].Value.ToString();
                this.txtTelephone.Text = dgPatient.Rows[indice].Cells[6].Value.ToString();
                this.txtEmail.Text = dgPatient.Rows[indice].Cells[7].Value.ToString();
            }
            catch (Exception ex) { }
        }

        private void CmbCodePatient_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = cmbCodePatient.SelectedIndex;
            if(indice!=-1)
            {
                dgPatient.ClearSelection();
                dgPatient.Rows[indice].Selected = true;
                this.txtNom.Text = dgPatient.Rows[indice].Cells[1].Value.ToString();
                this.txtPrenom.Text = dgPatient.Rows[indice].Cells[2].Value.ToString();
                this.dtpDateNaissance.Text = dgPatient.Rows[indice].Cells[3].Value.ToString();
                if (dgPatient.Rows[indice].Cells[4].Value.ToString() == "M") { this.rbm.Checked = true; }
                else { this.rbf.Checked = true; }
                this.txtAdresse.Text = dgPatient.Rows[indice].Cells[5].Value.ToString();
                this.txtTelephone.Text = dgPatient.Rows[indice].Cells[6].Value.ToString();
                this.txtEmail.Text = dgPatient.Rows[indice].Cells[7].Value.ToString();
            }
        }

        private void BtnModifier_Click_1(object sender, EventArgs e)
        {
            try
            {
                DialogResult res = MessageBox.Show("Voullez vous vraiment modifier ce patient ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (res == DialogResult.OK)
                {

                    int codePatient = int.Parse(cmbCodePatient.SelectedItem.ToString());

                    if ((this.txtNom.Text.Length < 3) || this.txtNom.Text.Length > 15)
                    {
                        this.lblnote.Visible = true;
                        throw new Exception("Le nom qui vous avez entre est invaide");
                    }
                    string nom = this.txtNom.Text;

                    if ((this.txtPrenom.Text.Length < 3) || this.txtPrenom.Text.Length > 15)
                    {
                        this.lblnote.Visible = true;
                        throw new Exception("Le prenom qui vous avez entre est invaide");
                    }
                    string prenom = this.txtPrenom.Text;

                    if (this.dtpDateNaissance.Value.Date > DateTime.Now.Date)
                    {
                        this.lblnote.Visible = true;
                        throw new Exception("Le date qui vous avez entre est invaide");
                    }
                    DateTime dateNaissance = this.dtpDateNaissance.Value.Date;

                    string sexe;
                    if (this.rbm.Checked == false && this.rbf.Checked == false)
                    {
                        this.lblnote.Visible = true;
                        throw new Exception("Please select your gender");
                    }
                    if (this.rbm.Checked == true)
                    { sexe = rbm.Text; }
                    else sexe = rbf.Text;

                    string adresse = this.txtAdresse.Text;

                    if (txtTelephone.Text.Length < 5 || txtTelephone.Text.Length > 15)
                    {
                        this.lblnote.Visible = true;
                        throw new Exception("telephone incorrect");
                    }
                    string tele = txtTelephone.Text;

                    string email = this.txtEmail.Text;

                    this.f.Cbm.ListPatient.Remove(this.f.Cbm.TrouverPatient(codePatient));

                    Patient pat = new Patient(codePatient, nom, prenom, dateNaissance, sexe, adresse, tele, email);

                    this.f.Cbm.ListPatient.Add(pat);
                    this.ChargerData();
                    this.Vider();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnSaveTxt_Click(object sender, EventArgs e)
        {
            this.saveFileDialog1.Title = "Select a file";
            this.saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
                foreach (Patient p in this.f.Cbm.ListPatient)
                {
                    sw.WriteLine(p.ToString());
                }
                sw.Close();
            }
        }
    }
}
