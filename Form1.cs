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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Bunifu.Framework.UI;

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

       

        public Form1()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
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
                    if (switchDark.Value == true)
                    {
                        currentButton.BackColor = Color.FromArgb(46, 51, 73);
                    }
                    else currentButton.BackColor = Color.PaleTurquoise;

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
            childForm.BackColor = this.BackColor;
            foreach (Control c in childForm.Controls)
            {
                if (c.HasChildren)
                {
                    foreach (Control control in c.Controls)
                    {
                        if (control.GetType()!=typeof(DataGridView))
                        {
                            control.BackColor = this.BackColor;
                            control.ForeColor = this.ForeColor;
                        }
                     
                    }
                }
            }
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
                    btn.BackColor = this.BackColor;

                }
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            switchDark.Value = true;
            OpenChildForm(new FormDashboard(), btnDashboard);

        }

        private void BtnFermer_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void BtnPatient_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormPatient(), sender);
        }

        private void BtnRendezVous_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormRendezVous(), sender);
        }
        

        private void BtnAbout_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormAbout(), sender);

        }

        private void BtnDashboard_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormDashboard(), sender);

        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void PanelMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SwitchDark_OnValueChange(object sender, EventArgs e)
        {
            if (switchDark.Value == true)
            {
                this.panelTitleBar.BackColor = Color.FromArgb(24, 30, 54);
                this.panelLogo.BackColor = Color.FromArgb(24, 30, 54);
                this.panelMain.BackColor = Color.FromArgb(24, 30, 54);
                this.panelMenu.BackColor = Color.FromArgb(24, 30, 54);
                foreach (Control c in this.panelMenu.Controls)
                {
                    if (c.GetType()==typeof(Button)|| c.GetType() == typeof(Panel)|| c.GetType() == typeof(PictureBox))
                    {
                        c.BackColor= Color.FromArgb(24, 30, 54);
                        c.ForeColor = Color.FromArgb(0, 126, 249);

                    }
                }
                this.BackColor = Color.FromArgb(24, 30, 54);
                this.ForeColor = Color.LightCyan;

                this.label2.BackColor =Color.FromArgb(24, 30, 54);
                this.btnFermer.ForeColor = Color.LightCyan;
                if (activeForm != null)
                {
                    this.activeForm.BackColor = Color.FromArgb(24, 30, 54);
                    foreach (Control c in this.activeForm.Controls)
                    {
                        if (c.HasChildren)
                        {
                            foreach (Control control    in c.Controls)
                            {
                                if (control.GetType() != typeof(DataGridView))
                                {
                                    control.BackColor = Color.FromArgb(24, 30, 54);
                                    control.ForeColor = Color.LightCyan;
                                }

                                    
                            }

                        }
                       

                    }
                }


            }
            else
            {
                this.panelTitleBar.BackColor = Color.LightCyan;
                this.panelLogo.BackColor = Color.LightCyan;
                this.panelMain.BackColor = Color.LightCyan;
                this.panelMenu.BackColor = Color.LightCyan;
                foreach (Control c in this.panelMenu.Controls)
                {
                    if (c.GetType() == typeof(Button) || c.GetType() == typeof(Panel) || c.GetType() == typeof(PictureBox))
                    {
                        c.BackColor = Color.LightCyan;
                        c.ForeColor = Color.Black;

                    }
                }
                this.BackColor = Color.LightCyan;
                this.ForeColor = Color.Black;
                this.label2.BackColor = Color.LightCyan;
                this.btnFermer.ForeColor = Color.DarkRed;
                if (activeForm != null)
                {
                    this.activeForm.BackColor = Color.LightCyan;
                    foreach (Control c in this.activeForm.Controls)
                    {
                        if (c.HasChildren)
                        {
                            foreach (Control control in c.Controls)
                            {
                                if (control.GetType() != typeof(DataGridView))
                                {
                                    control.BackColor = Color.LightCyan;
                                    control.ForeColor = Color.Black;
                                }
                              

                                
                            }
                        }
                    }
                }


            }
        }
    }
}
