namespace lestar_majuserettsegi
{
    partial class valasztasok
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
            this.feltolt = new System.Windows.Forms.Button();
            this.be = new System.Windows.Forms.ListBox();
            this.elso = new System.Windows.Forms.Button();
            this.masodik = new System.Windows.Forms.Button();
            this.harmadik = new System.Windows.Forms.Button();
            this.negyedik = new System.Windows.Forms.Button();
            this.otodik = new System.Windows.Forms.Button();
            this.tB = new System.Windows.Forms.TextBox();
            this.hatodik = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // feltolt
            // 
            this.feltolt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.feltolt.Location = new System.Drawing.Point(539, 12);
            this.feltolt.Name = "feltolt";
            this.feltolt.Size = new System.Drawing.Size(161, 26);
            this.feltolt.TabIndex = 0;
            this.feltolt.Text = "Feltöltés";
            this.feltolt.UseVisualStyleBackColor = true;
            this.feltolt.Click += new System.EventHandler(this.button1_Click);
            // 
            // be
            // 
            this.be.FormattingEnabled = true;
            this.be.Location = new System.Drawing.Point(12, 12);
            this.be.Name = "be";
            this.be.Size = new System.Drawing.Size(507, 381);
            this.be.TabIndex = 1;
            // 
            // elso
            // 
            this.elso.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.elso.Location = new System.Drawing.Point(539, 44);
            this.elso.Name = "elso";
            this.elso.Size = new System.Drawing.Size(161, 26);
            this.elso.TabIndex = 2;
            this.elso.Text = "Képviselőjelöltek száma";
            this.elso.UseVisualStyleBackColor = true;
            this.elso.Click += new System.EventHandler(this.elso_Click);
            // 
            // masodik
            // 
            this.masodik.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.masodik.Location = new System.Drawing.Point(539, 76);
            this.masodik.Name = "masodik";
            this.masodik.Size = new System.Drawing.Size(161, 26);
            this.masodik.TabIndex = 4;
            this.masodik.Text = "Szavazatok száma";
            this.masodik.UseVisualStyleBackColor = true;
            this.masodik.Click += new System.EventHandler(this.masodik_Click);
            // 
            // harmadik
            // 
            this.harmadik.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.harmadik.Location = new System.Drawing.Point(539, 136);
            this.harmadik.Name = "harmadik";
            this.harmadik.Size = new System.Drawing.Size(161, 26);
            this.harmadik.TabIndex = 5;
            this.harmadik.Text = "Részvételi arány";
            this.harmadik.UseVisualStyleBackColor = true;
            this.harmadik.Click += new System.EventHandler(this.harmadik_Click);
            // 
            // negyedik
            // 
            this.negyedik.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.negyedik.Location = new System.Drawing.Point(539, 168);
            this.negyedik.Name = "negyedik";
            this.negyedik.Size = new System.Drawing.Size(161, 26);
            this.negyedik.TabIndex = 6;
            this.negyedik.Text = "Pártok aránya";
            this.negyedik.UseVisualStyleBackColor = true;
            this.negyedik.Click += new System.EventHandler(this.negyedik_Click);
            // 
            // otodik
            // 
            this.otodik.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.otodik.Location = new System.Drawing.Point(539, 200);
            this.otodik.Name = "otodik";
            this.otodik.Size = new System.Drawing.Size(161, 26);
            this.otodik.TabIndex = 7;
            this.otodik.Text = "Legtöbb szavazat";
            this.otodik.UseVisualStyleBackColor = true;
            this.otodik.Click += new System.EventHandler(this.otodik_Click);
            // 
            // tB
            // 
            this.tB.Location = new System.Drawing.Point(539, 110);
            this.tB.Name = "tB";
            this.tB.Size = new System.Drawing.Size(161, 20);
            this.tB.TabIndex = 9;
            // 
            // hatodik
            // 
            this.hatodik.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.hatodik.Location = new System.Drawing.Point(539, 232);
            this.hatodik.Name = "hatodik";
            this.hatodik.Size = new System.Drawing.Size(161, 26);
            this.hatodik.TabIndex = 8;
            this.hatodik.Text = "Kerületek";
            this.hatodik.UseVisualStyleBackColor = true;
            this.hatodik.Click += new System.EventHandler(this.hatodik_Click);
            // 
            // valasztasok
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 410);
            this.Controls.Add(this.tB);
            this.Controls.Add(this.hatodik);
            this.Controls.Add(this.otodik);
            this.Controls.Add(this.negyedik);
            this.Controls.Add(this.harmadik);
            this.Controls.Add(this.masodik);
            this.Controls.Add(this.elso);
            this.Controls.Add(this.be);
            this.Controls.Add(this.feltolt);
            this.Name = "valasztasok";
            this.Text = "Választások";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button feltolt;
        private System.Windows.Forms.ListBox be;
        private System.Windows.Forms.Button elso;
        private System.Windows.Forms.Button masodik;
        private System.Windows.Forms.Button harmadik;
        private System.Windows.Forms.Button negyedik;
        private System.Windows.Forms.Button otodik;
        private System.Windows.Forms.TextBox tB;
        private System.Windows.Forms.Button hatodik;
    }
}

