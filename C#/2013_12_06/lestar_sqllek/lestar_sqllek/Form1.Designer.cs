namespace lestar_sqllek
{
    partial class sqllek
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
            this.mehet = new System.Windows.Forms.Button();
            this.lb_hany = new System.Windows.Forms.Label();
            this.lek = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.be = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // mehet
            // 
            this.mehet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.mehet.Location = new System.Drawing.Point(270, 27);
            this.mehet.Name = "mehet";
            this.mehet.Size = new System.Drawing.Size(185, 28);
            this.mehet.TabIndex = 0;
            this.mehet.Text = "Adatbázis kiválasztása";
            this.mehet.UseVisualStyleBackColor = true;
            this.mehet.Click += new System.EventHandler(this.mehet_Click);
            // 
            // lb_hany
            // 
            this.lb_hany.AutoSize = true;
            this.lb_hany.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_hany.Location = new System.Drawing.Point(28, 27);
            this.lb_hany.Name = "lb_hany";
            this.lb_hany.Size = new System.Drawing.Size(226, 17);
            this.lb_hany.TabIndex = 2;
            this.lb_hany.Text = "Melyik lekérdezést futtassam?";
            // 
            // lek
            // 
            this.lek.FormattingEnabled = true;
            this.lek.Location = new System.Drawing.Point(31, 397);
            this.lek.Name = "lek";
            this.lek.Size = new System.Drawing.Size(549, 21);
            this.lek.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(461, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 28);
            this.button1.TabIndex = 4;
            this.button1.Text = "Mehet!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // be
            // 
            this.be.FormattingEnabled = true;
            this.be.Location = new System.Drawing.Point(31, 72);
            this.be.Name = "be";
            this.be.Size = new System.Drawing.Size(549, 303);
            this.be.TabIndex = 5;
            // 
            // sqllek
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 441);
            this.Controls.Add(this.be);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lek);
            this.Controls.Add(this.lb_hany);
            this.Controls.Add(this.mehet);
            this.Name = "sqllek";
            this.Text = "SqlLekérdezés";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button mehet;
        private System.Windows.Forms.Label lb_hany;
        private System.Windows.Forms.ComboBox lek;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox be;
    }
}

