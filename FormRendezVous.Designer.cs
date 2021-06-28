namespace GestionCabinetMedical
{
    partial class FormRendezVous
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gb3 = new System.Windows.Forms.GroupBox();
            this.dgRendezVous = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gb2 = new System.Windows.Forms.GroupBox();
            this.btnImporter = new System.Windows.Forms.Button();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.btnExporter = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.gb1 = new System.Windows.Forms.GroupBox();
            this.txtObservation = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.cmbMinutes = new System.Windows.Forms.ComboBox();
            this.cmbHours = new System.Windows.Forms.ComboBox();
            this.lblHeureRV = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lblnote = new System.Windows.Forms.Label();
            this.lblCodePatient = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.dtpDateRV = new System.Windows.Forms.DateTimePicker();
            this.lblDateRV = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lblObservation = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.txtCodePatient = new System.Windows.Forms.TextBox();
            this.gb3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRendezVous)).BeginInit();
            this.gb2.SuspendLayout();
            this.gb1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb3
            // 
            this.gb3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gb3.Controls.Add(this.dgRendezVous);
            this.gb3.Location = new System.Drawing.Point(9, 283);
            this.gb3.Margin = new System.Windows.Forms.Padding(4);
            this.gb3.Name = "gb3";
            this.gb3.Padding = new System.Windows.Forms.Padding(4);
            this.gb3.Size = new System.Drawing.Size(1064, 364);
            this.gb3.TabIndex = 49;
            this.gb3.TabStop = false;
            // 
            // dgRendezVous
            // 
            this.dgRendezVous.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgRendezVous.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgRendezVous.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.dgRendezVous.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgRendezVous.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Corbel", 11.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgRendezVous.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgRendezVous.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRendezVous.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column4,
            this.Column6,
            this.Column8});
            this.dgRendezVous.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgRendezVous.Location = new System.Drawing.Point(8, 17);
            this.dgRendezVous.Margin = new System.Windows.Forms.Padding(4);
            this.dgRendezVous.Name = "dgRendezVous";
            this.dgRendezVous.Size = new System.Drawing.Size(1050, 339);
            this.dgRendezVous.TabIndex = 39;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Code Patient";
            this.Column1.Name = "Column1";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Date Rendez-vous";
            this.Column4.Name = "Column4";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Heure Rendez-vous";
            this.Column6.Name = "Column6";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Observation";
            this.Column8.Name = "Column8";
            // 
            // gb2
            // 
            this.gb2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb2.Controls.Add(this.btnImporter);
            this.gb2.Controls.Add(this.btnAjouter);
            this.gb2.Controls.Add(this.btnExporter);
            this.gb2.Controls.Add(this.btnSupprimer);
            this.gb2.Font = new System.Drawing.Font("Corbel", 11.25F);
            this.gb2.Location = new System.Drawing.Point(768, 13);
            this.gb2.Margin = new System.Windows.Forms.Padding(4);
            this.gb2.Name = "gb2";
            this.gb2.Padding = new System.Windows.Forms.Padding(4);
            this.gb2.Size = new System.Drawing.Size(305, 262);
            this.gb2.TabIndex = 48;
            this.gb2.TabStop = false;
            // 
            // btnImporter
            // 
            this.btnImporter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImporter.FlatAppearance.BorderColor = System.Drawing.Color.DarkOrange;
            this.btnImporter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImporter.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnImporter.ForeColor = System.Drawing.Color.DarkOrange;
            this.btnImporter.Location = new System.Drawing.Point(20, 143);
            this.btnImporter.Margin = new System.Windows.Forms.Padding(4);
            this.btnImporter.Name = "btnImporter";
            this.btnImporter.Size = new System.Drawing.Size(263, 42);
            this.btnImporter.TabIndex = 44;
            this.btnImporter.Text = "Importer";
            this.btnImporter.UseVisualStyleBackColor = true;
            this.btnImporter.Click += new System.EventHandler(this.BtnImporter_Click);
            // 
            // btnAjouter
            // 
            this.btnAjouter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAjouter.FlatAppearance.BorderColor = System.Drawing.Color.DarkOrange;
            this.btnAjouter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAjouter.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAjouter.ForeColor = System.Drawing.Color.DarkOrange;
            this.btnAjouter.Location = new System.Drawing.Point(20, 41);
            this.btnAjouter.Margin = new System.Windows.Forms.Padding(4);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(263, 42);
            this.btnAjouter.TabIndex = 40;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = true;
            this.btnAjouter.Click += new System.EventHandler(this.BtnAjouter_Click);
            // 
            // btnExporter
            // 
            this.btnExporter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExporter.FlatAppearance.BorderColor = System.Drawing.Color.DarkOrange;
            this.btnExporter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExporter.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnExporter.ForeColor = System.Drawing.Color.DarkOrange;
            this.btnExporter.Location = new System.Drawing.Point(20, 193);
            this.btnExporter.Margin = new System.Windows.Forms.Padding(4);
            this.btnExporter.Name = "btnExporter";
            this.btnExporter.Size = new System.Drawing.Size(263, 42);
            this.btnExporter.TabIndex = 41;
            this.btnExporter.Text = "Exporter";
            this.btnExporter.UseVisualStyleBackColor = true;
            this.btnExporter.Click += new System.EventHandler(this.BtnExporter_Click);
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSupprimer.FlatAppearance.BorderColor = System.Drawing.Color.DarkOrange;
            this.btnSupprimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupprimer.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupprimer.ForeColor = System.Drawing.Color.DarkOrange;
            this.btnSupprimer.Location = new System.Drawing.Point(20, 91);
            this.btnSupprimer.Margin = new System.Windows.Forms.Padding(4);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(263, 42);
            this.btnSupprimer.TabIndex = 43;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = true;
            this.btnSupprimer.Click += new System.EventHandler(this.BtnSupprimer_Click);
            // 
            // gb1
            // 
            this.gb1.Controls.Add(this.txtCodePatient);
            this.gb1.Controls.Add(this.txtObservation);
            this.gb1.Controls.Add(this.cmbMinutes);
            this.gb1.Controls.Add(this.cmbHours);
            this.gb1.Controls.Add(this.lblHeureRV);
            this.gb1.Controls.Add(this.lblnote);
            this.gb1.Controls.Add(this.lblCodePatient);
            this.gb1.Controls.Add(this.dtpDateRV);
            this.gb1.Controls.Add(this.lblDateRV);
            this.gb1.Controls.Add(this.lblObservation);
            this.gb1.Font = new System.Drawing.Font("Corbel", 11.25F);
            this.gb1.Location = new System.Drawing.Point(9, 13);
            this.gb1.Margin = new System.Windows.Forms.Padding(4);
            this.gb1.Name = "gb1";
            this.gb1.Padding = new System.Windows.Forms.Padding(4);
            this.gb1.Size = new System.Drawing.Size(751, 262);
            this.gb1.TabIndex = 47;
            this.gb1.TabStop = false;
            this.gb1.Enter += new System.EventHandler(this.Gb1_Enter);
            // 
            // txtObservation
            // 
            this.txtObservation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.txtObservation.BorderColorFocused = System.Drawing.Color.DarkOrange;
            this.txtObservation.BorderColorIdle = System.Drawing.Color.DarkOrange;
            this.txtObservation.BorderColorMouseHover = System.Drawing.Color.DarkOrange;
            this.txtObservation.BorderThickness = 2;
            this.txtObservation.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtObservation.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservation.ForeColor = System.Drawing.Color.White;
            this.txtObservation.isPassword = false;
            this.txtObservation.Location = new System.Drawing.Point(513, 42);
            this.txtObservation.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtObservation.Name = "txtObservation";
            this.txtObservation.Size = new System.Drawing.Size(216, 168);
            this.txtObservation.TabIndex = 52;
            this.txtObservation.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // cmbMinutes
            // 
            this.cmbMinutes.FormattingEnabled = true;
            this.cmbMinutes.Location = new System.Drawing.Point(286, 173);
            this.cmbMinutes.Name = "cmbMinutes";
            this.cmbMinutes.Size = new System.Drawing.Size(106, 26);
            this.cmbMinutes.TabIndex = 50;
            // 
            // cmbHours
            // 
            this.cmbHours.FormattingEnabled = true;
            this.cmbHours.Location = new System.Drawing.Point(172, 173);
            this.cmbHours.Name = "cmbHours";
            this.cmbHours.Size = new System.Drawing.Size(108, 26);
            this.cmbHours.TabIndex = 49;
            // 
            // lblHeureRV
            // 
            this.lblHeureRV.AutoSize = true;
            this.lblHeureRV.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeureRV.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblHeureRV.Location = new System.Drawing.Point(26, 177);
            this.lblHeureRV.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHeureRV.Name = "lblHeureRV";
            this.lblHeureRV.Size = new System.Drawing.Size(136, 18);
            this.lblHeureRV.TabIndex = 48;
            this.lblHeureRV.Text = "Heure Rendez-vous*";
            // 
            // lblnote
            // 
            this.lblnote.AutoSize = true;
            this.lblnote.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnote.ForeColor = System.Drawing.Color.Red;
            this.lblnote.Location = new System.Drawing.Point(26, 228);
            this.lblnote.Name = "lblnote";
            this.lblnote.Size = new System.Drawing.Size(267, 17);
            this.lblnote.TabIndex = 47;
            this.lblnote.Text = "NB : les champs contains \"*\" sont obligatoire";
            this.lblnote.Visible = false;
            // 
            // lblCodePatient
            // 
            this.lblCodePatient.AutoSize = true;
            this.lblCodePatient.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodePatient.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblCodePatient.Location = new System.Drawing.Point(26, 51);
            this.lblCodePatient.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCodePatient.Name = "lblCodePatient";
            this.lblCodePatient.Size = new System.Drawing.Size(95, 18);
            this.lblCodePatient.TabIndex = 3;
            this.lblCodePatient.Text = "Code Patient*";
            // 
            // dtpDateRV
            // 
            this.dtpDateRV.CalendarFont = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateRV.CalendarMonthBackground = System.Drawing.Color.LightSlateGray;
            this.dtpDateRV.Font = new System.Drawing.Font("Corbel", 11.25F);
            this.dtpDateRV.Location = new System.Drawing.Point(172, 111);
            this.dtpDateRV.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.dtpDateRV.Name = "dtpDateRV";
            this.dtpDateRV.Size = new System.Drawing.Size(220, 26);
            this.dtpDateRV.TabIndex = 31;
            // 
            // lblDateRV
            // 
            this.lblDateRV.AutoSize = true;
            this.lblDateRV.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateRV.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblDateRV.Location = new System.Drawing.Point(26, 117);
            this.lblDateRV.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDateRV.Name = "lblDateRV";
            this.lblDateRV.Size = new System.Drawing.Size(128, 18);
            this.lblDateRV.TabIndex = 2;
            this.lblDateRV.Text = "Date Rendez-vous*";
            // 
            // lblObservation
            // 
            this.lblObservation.AutoSize = true;
            this.lblObservation.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblObservation.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblObservation.Location = new System.Drawing.Point(411, 51);
            this.lblObservation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblObservation.Name = "lblObservation";
            this.lblObservation.Size = new System.Drawing.Size(83, 18);
            this.lblObservation.TabIndex = 7;
            this.lblObservation.Text = "Observation";
            // 
            // txtCodePatient
            // 
            this.txtCodePatient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.txtCodePatient.Location = new System.Drawing.Point(172, 51);
            this.txtCodePatient.Name = "txtCodePatient";
            this.txtCodePatient.Size = new System.Drawing.Size(220, 26);
            this.txtCodePatient.TabIndex = 54;
            this.txtCodePatient.TextChanged += new System.EventHandler(this.TxtCodePatient_TextChanged);
            // 
            // FormRendezVous
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1086, 660);
            this.Controls.Add(this.gb3);
            this.Controls.Add(this.gb2);
            this.Controls.Add(this.gb1);
            this.Font = new System.Drawing.Font("Corbel", 11.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1086, 660);
            this.Name = "FormRendezVous";
            this.Text = "Rendez Vous";
            this.Load += new System.EventHandler(this.FormRendezVous_Load);
            this.gb3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgRendezVous)).EndInit();
            this.gb2.ResumeLayout(false);
            this.gb1.ResumeLayout(false);
            this.gb1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb3;
        private System.Windows.Forms.DataGridView dgRendezVous;
        private System.Windows.Forms.GroupBox gb2;
        private System.Windows.Forms.Button btnImporter;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Button btnExporter;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.GroupBox gb1;
        private System.Windows.Forms.Label lblnote;
        private Bunifu.Framework.UI.BunifuCustomLabel lblCodePatient;
        private System.Windows.Forms.DateTimePicker dtpDateRV;
        private Bunifu.Framework.UI.BunifuCustomLabel lblDateRV;
        private System.Windows.Forms.ComboBox cmbMinutes;
        private System.Windows.Forms.ComboBox cmbHours;
        private Bunifu.Framework.UI.BunifuCustomLabel lblHeureRV;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtObservation;
        private Bunifu.Framework.UI.BunifuCustomLabel lblObservation;
        private System.Windows.Forms.TextBox txtCodePatient;
    }
}