namespace WindowsFormsApplication1
{
    partial class access
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
            this.adb_kiv = new System.Windows.Forms.Button();
            this.be = new System.Windows.Forms.ListBox();
            this.tablak = new System.Windows.Forms.ListBox();
            this.mezok = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // adb_kiv
            // 
            this.adb_kiv.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.adb_kiv.Location = new System.Drawing.Point(65, 82);
            this.adb_kiv.Name = "adb_kiv";
            this.adb_kiv.Size = new System.Drawing.Size(190, 33);
            this.adb_kiv.TabIndex = 0;
            this.adb_kiv.Text = "Adatbázis kiválasztása";
            this.adb_kiv.UseVisualStyleBackColor = true;
            this.adb_kiv.Click += new System.EventHandler(this.button1_Click);
            // 
            // be
            // 
            this.be.FormattingEnabled = true;
            this.be.Location = new System.Drawing.Point(37, 234);
            this.be.Name = "be";
            this.be.Size = new System.Drawing.Size(670, 277);
            this.be.TabIndex = 1;
            this.be.Visible = false;
            // 
            // tablak
            // 
            this.tablak.FormattingEnabled = true;
            this.tablak.Location = new System.Drawing.Point(313, 22);
            this.tablak.Name = "tablak";
            this.tablak.Size = new System.Drawing.Size(153, 199);
            this.tablak.TabIndex = 2;
            this.tablak.Visible = false;
            this.tablak.SelectedValueChanged += new System.EventHandler(this.tablak_SelectedValueChanged);
            // 
            // mezok
            // 
            this.mezok.FormattingEnabled = true;
            this.mezok.Location = new System.Drawing.Point(554, 22);
            this.mezok.Name = "mezok";
            this.mezok.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.mezok.Size = new System.Drawing.Size(153, 199);
            this.mezok.TabIndex = 3;
            this.mezok.Visible = false;
            this.mezok.SelectedValueChanged += new System.EventHandler(this.mezok_SelectedValueChanged);
            // 
            // access
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 548);
            this.Controls.Add(this.mezok);
            this.Controls.Add(this.tablak);
            this.Controls.Add(this.be);
            this.Controls.Add(this.adb_kiv);
            this.Name = "access";
            this.Text = "Access adatbázis";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button adb_kiv;
        private System.Windows.Forms.ListBox be;
        private System.Windows.Forms.ListBox tablak;
        private System.Windows.Forms.ListBox mezok;
    }
}

