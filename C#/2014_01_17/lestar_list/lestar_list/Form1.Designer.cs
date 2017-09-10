namespace lestar_list
{
    partial class osztalyzatok
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
            this.be = new System.Windows.Forms.ListBox();
            this.bt_mehet = new System.Windows.Forms.Button();
            this.ki = new System.Windows.Forms.ListBox();
            this.bt_atl = new System.Windows.Forms.Button();
            this.bt_legjobb = new System.Windows.Forms.Button();
            this.bt_jeles = new System.Windows.Forms.Button();
            this.bt_peldas = new System.Windows.Forms.Button();
            this.bt_hanyag = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // be
            // 
            this.be.FormattingEnabled = true;
            this.be.Location = new System.Drawing.Point(12, 57);
            this.be.Name = "be";
            this.be.Size = new System.Drawing.Size(240, 329);
            this.be.TabIndex = 0;
            // 
            // bt_mehet
            // 
            this.bt_mehet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_mehet.Location = new System.Drawing.Point(12, 17);
            this.bt_mehet.Name = "bt_mehet";
            this.bt_mehet.Size = new System.Drawing.Size(122, 23);
            this.bt_mehet.TabIndex = 1;
            this.bt_mehet.Text = "Mehet!";
            this.bt_mehet.UseVisualStyleBackColor = true;
            this.bt_mehet.Click += new System.EventHandler(this.bt_mehet_Click);
            // 
            // ki
            // 
            this.ki.FormattingEnabled = true;
            this.ki.Location = new System.Drawing.Point(521, 57);
            this.ki.Name = "ki";
            this.ki.Size = new System.Drawing.Size(240, 329);
            this.ki.TabIndex = 2;
            // 
            // bt_atl
            // 
            this.bt_atl.Enabled = false;
            this.bt_atl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_atl.Location = new System.Drawing.Point(293, 124);
            this.bt_atl.Name = "bt_atl";
            this.bt_atl.Size = new System.Drawing.Size(185, 28);
            this.bt_atl.TabIndex = 3;
            this.bt_atl.Text = "Átlagszámítás";
            this.bt_atl.UseVisualStyleBackColor = true;
            this.bt_atl.Click += new System.EventHandler(this.bt_atl_Click);
            // 
            // bt_legjobb
            // 
            this.bt_legjobb.Enabled = false;
            this.bt_legjobb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_legjobb.Location = new System.Drawing.Point(293, 167);
            this.bt_legjobb.Name = "bt_legjobb";
            this.bt_legjobb.Size = new System.Drawing.Size(185, 28);
            this.bt_legjobb.TabIndex = 4;
            this.bt_legjobb.Text = "Legjobb tanuló";
            this.bt_legjobb.UseVisualStyleBackColor = true;
            this.bt_legjobb.Click += new System.EventHandler(this.bt_legjobb_Click);
            // 
            // bt_jeles
            // 
            this.bt_jeles.Enabled = false;
            this.bt_jeles.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_jeles.Location = new System.Drawing.Point(293, 211);
            this.bt_jeles.Name = "bt_jeles";
            this.bt_jeles.Size = new System.Drawing.Size(185, 28);
            this.bt_jeles.TabIndex = 5;
            this.bt_jeles.Text = "Jeles átlagúak";
            this.bt_jeles.UseVisualStyleBackColor = true;
            this.bt_jeles.Click += new System.EventHandler(this.bt_jeles_Click);
            // 
            // bt_peldas
            // 
            this.bt_peldas.Enabled = false;
            this.bt_peldas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_peldas.Location = new System.Drawing.Point(293, 251);
            this.bt_peldas.Name = "bt_peldas";
            this.bt_peldas.Size = new System.Drawing.Size(185, 28);
            this.bt_peldas.TabIndex = 6;
            this.bt_peldas.Text = "Példás m/sz";
            this.bt_peldas.UseVisualStyleBackColor = true;
            this.bt_peldas.Click += new System.EventHandler(this.bt_peldas_Click);
            // 
            // bt_hanyag
            // 
            this.bt_hanyag.Enabled = false;
            this.bt_hanyag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_hanyag.Location = new System.Drawing.Point(293, 297);
            this.bt_hanyag.Name = "bt_hanyag";
            this.bt_hanyag.Size = new System.Drawing.Size(185, 28);
            this.bt_hanyag.TabIndex = 7;
            this.bt_hanyag.Text = "Volt hanyag szorgalmú?";
            this.bt_hanyag.UseVisualStyleBackColor = true;
            this.bt_hanyag.Click += new System.EventHandler(this.bt_hanyag_Click);
            // 
            // osztalyzatok
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 421);
            this.Controls.Add(this.bt_hanyag);
            this.Controls.Add(this.bt_peldas);
            this.Controls.Add(this.bt_jeles);
            this.Controls.Add(this.bt_legjobb);
            this.Controls.Add(this.bt_atl);
            this.Controls.Add(this.ki);
            this.Controls.Add(this.bt_mehet);
            this.Controls.Add(this.be);
            this.Name = "osztalyzatok";
            this.Text = "Osztályzatok";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox be;
        private System.Windows.Forms.Button bt_mehet;
        private System.Windows.Forms.ListBox ki;
        private System.Windows.Forms.Button bt_atl;
        private System.Windows.Forms.Button bt_legjobb;
        private System.Windows.Forms.Button bt_jeles;
        private System.Windows.Forms.Button bt_peldas;
        private System.Windows.Forms.Button bt_hanyag;
    }
}

