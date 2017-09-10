namespace lestar_statikussor
{
    partial class frm_stat
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
            this.bt_uj = new System.Windows.Forms.Button();
            this.dg_ki = new System.Windows.Forms.DataGridView();
            this.lb_cl = new System.Windows.Forms.Label();
            this.bt_berak = new System.Windows.Forms.Button();
            this.bt_kivesz = new System.Windows.Forms.Button();
            this.lb_utoljara = new System.Windows.Forms.Label();
            this.bt_kilep = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dg_ki)).BeginInit();
            this.SuspendLayout();
            // 
            // bt_uj
            // 
            this.bt_uj.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_uj.Location = new System.Drawing.Point(329, 107);
            this.bt_uj.Name = "bt_uj";
            this.bt_uj.Size = new System.Drawing.Size(103, 28);
            this.bt_uj.TabIndex = 0;
            this.bt_uj.Text = "Új";
            this.bt_uj.UseVisualStyleBackColor = true;
            this.bt_uj.Click += new System.EventHandler(this.bt_uj_Click);
            // 
            // dg_ki
            // 
            this.dg_ki.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_ki.ColumnHeadersVisible = false;
            this.dg_ki.Location = new System.Drawing.Point(152, 161);
            this.dg_ki.Name = "dg_ki";
            this.dg_ki.ReadOnly = true;
            this.dg_ki.RowHeadersVisible = false;
            this.dg_ki.Size = new System.Drawing.Size(443, 78);
            this.dg_ki.TabIndex = 1;
            // 
            // lb_cl
            // 
            this.lb_cl.AutoSize = true;
            this.lb_cl.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_cl.Location = new System.Drawing.Point(282, 50);
            this.lb_cl.Name = "lb_cl";
            this.lb_cl.Size = new System.Drawing.Size(198, 37);
            this.lb_cl.TabIndex = 2;
            this.lb_cl.Text = "Ciklikus Sor";
            // 
            // bt_berak
            // 
            this.bt_berak.Enabled = false;
            this.bt_berak.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_berak.Location = new System.Drawing.Point(101, 271);
            this.bt_berak.Name = "bt_berak";
            this.bt_berak.Size = new System.Drawing.Size(103, 28);
            this.bt_berak.TabIndex = 3;
            this.bt_berak.Text = "Berak";
            this.bt_berak.UseVisualStyleBackColor = true;
            this.bt_berak.Click += new System.EventHandler(this.bt_berak_Click);
            // 
            // bt_kivesz
            // 
            this.bt_kivesz.Enabled = false;
            this.bt_kivesz.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_kivesz.Location = new System.Drawing.Point(225, 271);
            this.bt_kivesz.Name = "bt_kivesz";
            this.bt_kivesz.Size = new System.Drawing.Size(103, 28);
            this.bt_kivesz.TabIndex = 4;
            this.bt_kivesz.Text = "Kivesz";
            this.bt_kivesz.UseVisualStyleBackColor = true;
            this.bt_kivesz.Click += new System.EventHandler(this.bt_kivesz_Click);
            // 
            // lb_utoljara
            // 
            this.lb_utoljara.AutoSize = true;
            this.lb_utoljara.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_utoljara.Location = new System.Drawing.Point(350, 281);
            this.lb_utoljara.Name = "lb_utoljara";
            this.lb_utoljara.Size = new System.Drawing.Size(155, 18);
            this.lb_utoljara.TabIndex = 5;
            this.lb_utoljara.Text = "Az utoljára kivett elem:";
            // 
            // bt_kilep
            // 
            this.bt_kilep.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_kilep.Location = new System.Drawing.Point(622, 311);
            this.bt_kilep.Name = "bt_kilep";
            this.bt_kilep.Size = new System.Drawing.Size(115, 61);
            this.bt_kilep.TabIndex = 6;
            this.bt_kilep.Text = "Kilépés";
            this.bt_kilep.UseVisualStyleBackColor = true;
            this.bt_kilep.Click += new System.EventHandler(this.bt_kilep_Click);
            // 
            // frm_stat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(773, 398);
            this.Controls.Add(this.bt_kilep);
            this.Controls.Add(this.lb_utoljara);
            this.Controls.Add(this.bt_kivesz);
            this.Controls.Add(this.bt_berak);
            this.Controls.Add(this.lb_cl);
            this.Controls.Add(this.dg_ki);
            this.Controls.Add(this.bt_uj);
            this.Name = "frm_stat";
            this.Text = "Statikus sor";
            this.Load += new System.EventHandler(this.frm_stat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg_ki)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_uj;
        private System.Windows.Forms.DataGridView dg_ki;
        private System.Windows.Forms.Label lb_cl;
        private System.Windows.Forms.Button bt_berak;
        private System.Windows.Forms.Button bt_kivesz;
        private System.Windows.Forms.Label lb_utoljara;
        private System.Windows.Forms.Button bt_kilep;
    }
}

