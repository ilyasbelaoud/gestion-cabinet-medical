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
    public partial class Form1 : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
       (
           int nLeftRect,     // x-coordinate of upper-left corner
           int nTopRect,      // y-coordinate of upper-left corner
           int nRightRect,    // x-coordinate of lower-right corner
           int nBottomRect,   // y-coordinate of lower-right corner
           int nWidthEllipse, // height of ellipse
           int nHeightEllipse // width of ellipse
       );

        private Button currentButton;
        private Form activeForm;


        CabinetMedical cbm = new CabinetMedical();
        public CabinetMedical Cbm { get => cbm; set => cbm = value; }

        public Form1()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            this.timer1.Start();
        }
        private void ButtonActivate(object btnSender)
        {
            ButtonDisable();
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    currentButton = (Button)btnSender;
                    pnlNav.Height = currentButton.Height;
                    pnlNav.Top = currentButton.Top;
                    pnlNav.Left = currentButton.Left;
                    currentButton.BackColor = Color.FromArgb(46, 51, 73);
                }
            }
        }
        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            ButtonActivate(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelMain.Controls.Add(childForm);
            this.panelMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            this.lblTitle.Text = childForm.Text;
        }
        private void ButtonDisable()
        {
            foreach (Control btn in panelMenu.Controls)
            {
                if (btn.GetType() == typeof(Button))
                {
                    btn.BackColor = Color.FromArgb(24, 30, 54);
                }
            }
        }

        private void ChargerCombo()
        {
            this.cmbRecherchrePar.Items.Add("Code Patient");
            this.cmbRecherchrePar.Items.Add("Nom Complet");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ChargerCombo();
            FormPatient fp = new FormPatient(this);
            fp.ImporterDataFromFile();
            FormRendezVous fr = new FormRendezVous(this);
            fr.ImporterDataFromFile();
            this.lblNombrePatient.Text = this.Cbm.ListPatient.Count.ToString();
        }

        private void BtnFermer_Click(object sender, EventArgs e)
        {
            FormPatient fp = new FormPatient(this);
            fp.SaveDataInFile();
            FormRendezVous fr = new FormRendezVous(this);
            fr.SaveDataInFile();
            Environment.Exit(0);
        }

        private void BtnPatient_Click(object sender, EventArgs e)
        {
            FormPatient fp = new FormPatient(this);
            OpenChildForm(fp, sender);
            this.Vider();
        }

        private void BtnRendezVous_Click(object sender, EventArgs e)
        {
            FormRendezVous fr = new FormRendezVous(this);
            OpenChildForm(fr, sender);
            this.Vider();
        }

        private void BtnRechercher_Click(object sender, EventArgs e)
        {
            try
            {
                if ((cmbRecherchrePar.SelectedItem==null) || (txtRechercher.Text==""))
                {
                    throw new Exception("Remplir tout les chams!");
                }
                else if (cmbRecherchrePar.Text == "Code Patient")
                {
                    Patient p = this.Cbm.TrouverPatient(int.Parse(txtRechercher.Text));
                    if (p==null) throw new Exception("Patient n'est pas trouver !!");
                    txtCodePatient.Text = p.CodePatient.ToString();
                    txtNom.Text = p.Nom;
                    txtPrenom.Text = p.Prenom;
                    dtpDateNaissance.Text = p.DateNaissance.ToShortDateString();
                    if (p.Sexe=="M") rbm.Checked = true;
                    else rbf.Checked = true;
                    txtAdresse.Text = p.Adresse;
                    txtTelephone.Text = p.Tel;
                    txtEmail.Text = p.Email;
                    listBox1.Items.Clear();
                    RendezVous rv = this.Cbm.TrouverRendezVous(p.CodePatient);
                    if (rv!=null) listBox1.Items.Add(rv);
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
                    listBox1.Items.Clear();
                    RendezVous rv = this.Cbm.TrouverRendezVous(p.CodePatient);
                    if (rv != null) listBox1.Items.Add(rv);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void Vider()
        {
            this.listBox1.Items.Clear();
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

        private void BtnAbout_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormAbout(), sender);

        }

        private void BtnDashboard_Click(object sender, EventArgs e)
        {
            activeForm.Hide();
            this.Show();
        }
    }
}
