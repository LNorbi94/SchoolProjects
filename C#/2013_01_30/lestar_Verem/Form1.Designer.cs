namespace Verem
{
    partial class frm_verem
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
            this.lb_eredeti = new System.Windows.Forms.Label();
            this.lb_cserelt = new System.Windows.Forms.Label();
            this.bt_mehet = new System.Windows.Forms.Button();
            this.eredeti = new System.Windows.Forms.TextBox();
            this.megcserelt = new System.Windows.Forms.TextBox();
            this.bt_kilep = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb_eredeti
            // 
            this.lb_eredeti.AutoSize = true;
            this.lb_eredeti.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_eredeti.Location = new System.Drawing.Point(43, 46);
            this.lb_eredeti.Name = "lb_eredeti";
            this.lb_eredeti.Size = new System.Drawing.Size(121, 17);
            this.lb_eredeti.TabIndex = 0;
            this.lb_eredeti.Text = "Eredeti szöveg:";
            this.lb_eredeti.Click += new System.EventHandler(this.label1_Click);
            // 
            // lb_cserelt
            // 
            this.lb_cserelt.AutoSize = true;
            this.lb_cserelt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_cserelt.Location = new System.Drawing.Point(43, 125);
            this.lb_cserelt.Name = "lb_cserelt";
            this.lb_cserelt.Size = new System.Drawing.Size(148, 17);
            this.lb_cserelt.TabIndex = 1;
            this.lb_cserelt.Text = "Megcserélt szöveg:";
            // 
            // bt_mehet
            // 
            this.bt_mehet.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_mehet.Location = new System.Drawing.Point(46, 221);
            this.bt_mehet.Name = "bt_mehet";
            this.bt_mehet.Size = new System.Drawing.Size(98, 32);
            this.bt_mehet.TabIndex = 2;
            this.bt_mehet.Text = "Mehet!";
            this.bt_mehet.UseVisualStyleBackColor = true;
            this.bt_mehet.Click += new System.EventHandler(this.bt_mehet_Click);
            // 
            // eredeti
            // 
            this.eredeti.Location = new System.Drawing.Point(46, 82);
            this.eredeti.Name = "eredeti";
            this.eredeti.Size = new System.Drawing.Size(360, 20);
            this.eredeti.TabIndex = 3;
            // 
            // megcserelt
            // 
            this.megcserelt.Location = new System.Drawing.Point(46, 166);
            this.megcserelt.Name = "megcserelt";
            this.megcserelt.Size = new System.Drawing.Size(360, 20);
            this.megcserelt.TabIndex = 4;
            // 
            // bt_kilep
            // 
            this.bt_kilep.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_kilep.Location = new System.Drawing.Point(308, 221);
            this.bt_kilep.Name = "bt_kilep";
            this.bt_kilep.Size = new System.Drawing.Size(98, 32);
            this.bt_kilep.TabIndex = 5;
            this.bt_kilep.Text = "Kilépés";
            this.bt_kilep.UseVisualStyleBackColor = true;
            this.bt_kilep.Click += new System.EventHandler(this.bt_kilep_Click);
            // 
            // frm_verem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 299);
            this.Controls.Add(this.bt_kilep);
            this.Controls.Add(this.megcserelt);
            this.Controls.Add(this.eredeti);
            this.Controls.Add(this.bt_mehet);
            this.Controls.Add(this.lb_cserelt);
            this.Controls.Add(this.lb_eredeti);
            this.Name = "frm_verem";
            this.Text = "Verem";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_eredeti;
        private System.Windows.Forms.Label lb_cserelt;
        private System.Windows.Forms.Button bt_mehet;
        private System.Windows.Forms.TextBox eredeti;
        private System.Windows.Forms.TextBox megcserelt;
        private System.Windows.Forms.Button bt_kilep;
    }
}

