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
            this.tBhany = new System.Windows.Forms.TextBox();
            this.lb_hany = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mehet
            // 
            this.mehet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.mehet.Location = new System.Drawing.Point(100, 100);
            this.mehet.Name = "mehet";
            this.mehet.Size = new System.Drawing.Size(75, 23);
            this.mehet.TabIndex = 0;
            this.mehet.Text = "Mehet!";
            this.mehet.UseVisualStyleBackColor = true;
            this.mehet.Click += new System.EventHandler(this.mehet_Click);
            // 
            // tBhany
            // 
            this.tBhany.Location = new System.Drawing.Point(88, 54);
            this.tBhany.Name = "tBhany";
            this.tBhany.Size = new System.Drawing.Size(100, 20);
            this.tBhany.TabIndex = 1;
            // 
            // lb_hany
            // 
            this.lb_hany.AutoSize = true;
            this.lb_hany.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_hany.Location = new System.Drawing.Point(22, 27);
            this.lb_hany.Name = "lb_hany";
            this.lb_hany.Size = new System.Drawing.Size(243, 17);
            this.lb_hany.TabIndex = 2;
            this.lb_hany.Text = "Hányadik lekérdezést futassam?";
            // 
            // sqllek
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 170);
            this.Controls.Add(this.lb_hany);
            this.Controls.Add(this.tBhany);
            this.Controls.Add(this.mehet);
            this.Name = "sqllek";
            this.Text = "SqlLekérdezés";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button mehet;
        private System.Windows.Forms.TextBox tBhany;
        private System.Windows.Forms.Label lb_hany;
    }
}

