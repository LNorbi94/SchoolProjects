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
            this.bt_verembe = new System.Windows.Forms.Button();
            this.eredeti = new System.Windows.Forms.TextBox();
            this.megcserelt = new System.Windows.Forms.TextBox();
            this.bt_kilep = new System.Windows.Forms.Button();
            this.bt_verembol = new System.Windows.Forms.Button();
            this.dg = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dg)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_eredeti
            // 
            this.lb_eredeti.AutoSize = true;
            this.lb_eredeti.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_eredeti.Location = new System.Drawing.Point(39, 39);
            this.lb_eredeti.Name = "lb_eredeti";
            this.lb_eredeti.Size = new System.Drawing.Size(121, 17);
            this.lb_eredeti.TabIndex = 0;
            this.lb_eredeti.Text = "Eredeti szöveg:";
            // 
            // lb_cserelt
            // 
            this.lb_cserelt.AutoSize = true;
            this.lb_cserelt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_cserelt.Location = new System.Drawing.Point(12, 189);
            this.lb_cserelt.Name = "lb_cserelt";
            this.lb_cserelt.Size = new System.Drawing.Size(148, 17);
            this.lb_cserelt.TabIndex = 1;
            this.lb_cserelt.Text = "Megcserélt szöveg:";
            // 
            // bt_verembe
            // 
            this.bt_verembe.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_verembe.Location = new System.Drawing.Point(567, 28);
            this.bt_verembe.Name = "bt_verembe";
            this.bt_verembe.Size = new System.Drawing.Size(98, 31);
            this.bt_verembe.TabIndex = 2;
            this.bt_verembe.Text = "Verembe!";
            this.bt_verembe.UseVisualStyleBackColor = true;
            this.bt_verembe.Click += new System.EventHandler(this.bt_mehet_Click);
            // 
            // eredeti
            // 
            this.eredeti.Location = new System.Drawing.Point(177, 39);
            this.eredeti.Name = "eredeti";
            this.eredeti.Size = new System.Drawing.Size(360, 20);
            this.eredeti.TabIndex = 3;
            // 
            // megcserelt
            // 
            this.megcserelt.Location = new System.Drawing.Point(177, 186);
            this.megcserelt.Name = "megcserelt";
            this.megcserelt.Size = new System.Drawing.Size(360, 20);
            this.megcserelt.TabIndex = 4;
            // 
            // bt_kilep
            // 
            this.bt_kilep.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_kilep.Location = new System.Drawing.Point(567, 255);
            this.bt_kilep.Name = "bt_kilep";
            this.bt_kilep.Size = new System.Drawing.Size(98, 32);
            this.bt_kilep.TabIndex = 5;
            this.bt_kilep.Text = "Kilépés";
            this.bt_kilep.UseVisualStyleBackColor = true;
            this.bt_kilep.Click += new System.EventHandler(this.bt_kilep_Click);
            // 
            // bt_verembol
            // 
            this.bt_verembol.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_verembol.Location = new System.Drawing.Point(567, 186);
            this.bt_verembol.Name = "bt_verembol";
            this.bt_verembol.Size = new System.Drawing.Size(98, 31);
            this.bt_verembol.TabIndex = 6;
            this.bt_verembol.Text = "Veremből!";
            this.bt_verembol.UseVisualStyleBackColor = true;
            this.bt_verembol.Click += new System.EventHandler(this.bt_verembol_Click);
            // 
            // dg
            // 
            this.dg.AllowUserToAddRows = false;
            this.dg.AllowUserToDeleteRows = false;
            this.dg.AllowUserToResizeColumns = false;
            this.dg.AllowUserToResizeRows = false;
            this.dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg.Location = new System.Drawing.Point(15, 74);
            this.dg.Name = "dg";
            this.dg.Size = new System.Drawing.Size(650, 67);
            this.dg.TabIndex = 7;
            // 
            // frm_verem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 299);
            this.Controls.Add(this.dg);
            this.Controls.Add(this.bt_verembol);
            this.Controls.Add(this.bt_kilep);
            this.Controls.Add(this.megcserelt);
            this.Controls.Add(this.eredeti);
            this.Controls.Add(this.bt_verembe);
            this.Controls.Add(this.lb_cserelt);
            this.Controls.Add(this.lb_eredeti);
            this.Name = "frm_verem";
            this.Text = "Verem";
            this.Load += new System.EventHandler(this.frm_verem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_eredeti;
        private System.Windows.Forms.Label lb_cserelt;
        private System.Windows.Forms.Button bt_verembe;
        private System.Windows.Forms.TextBox eredeti;
        private System.Windows.Forms.TextBox megcserelt;
        private System.Windows.Forms.Button bt_kilep;
        private System.Windows.Forms.Button bt_verembol;
        private System.Windows.Forms.DataGridView dg;
    }
}

