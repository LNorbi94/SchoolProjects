namespace lestar_dolgozat03
{
    partial class orok_dolg
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
            this.rB_daralo = new System.Windows.Forms.RadioButton();
            this.gB_ember = new System.Windows.Forms.GroupBox();
            this.rB_metszo = new System.Windows.Forms.RadioButton();
            this.rB_hordo = new System.Windows.Forms.RadioButton();
            this.lb_nev = new System.Windows.Forms.Label();
            this.lb_valtozik = new System.Windows.Forms.Label();
            this.lb_emberadat = new System.Windows.Forms.Label();
            this.lb_erk = new System.Windows.Forms.Label();
            this.tB_nev = new System.Windows.Forms.TextBox();
            this.tB_erk = new System.Windows.Forms.TextBox();
            this.tB_valtozik = new System.Windows.Forms.TextBox();
            this.tB_adat = new System.Windows.Forms.TextBox();
            this.bt_mehet = new System.Windows.Forms.Button();
            this.lb_megj = new System.Windows.Forms.Label();
            this.gB_ember.SuspendLayout();
            this.SuspendLayout();
            // 
            // rB_daralo
            // 
            this.rB_daralo.AutoSize = true;
            this.rB_daralo.Location = new System.Drawing.Point(17, 22);
            this.rB_daralo.Name = "rB_daralo";
            this.rB_daralo.Size = new System.Drawing.Size(62, 17);
            this.rB_daralo.TabIndex = 0;
            this.rB_daralo.TabStop = true;
            this.rB_daralo.Text = "Daráló";
            this.rB_daralo.UseVisualStyleBackColor = true;
            this.rB_daralo.CheckedChanged += new System.EventHandler(this.rB_daralo_EnabledChanged);
            // 
            // gB_ember
            // 
            this.gB_ember.Controls.Add(this.rB_hordo);
            this.gB_ember.Controls.Add(this.rB_metszo);
            this.gB_ember.Controls.Add(this.rB_daralo);
            this.gB_ember.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gB_ember.Location = new System.Drawing.Point(42, 27);
            this.gB_ember.Name = "gB_ember";
            this.gB_ember.Size = new System.Drawing.Size(200, 100);
            this.gB_ember.TabIndex = 1;
            this.gB_ember.TabStop = false;
            this.gB_ember.Text = "Emberek";
            // 
            // rB_metszo
            // 
            this.rB_metszo.AutoSize = true;
            this.rB_metszo.Location = new System.Drawing.Point(17, 45);
            this.rB_metszo.Name = "rB_metszo";
            this.rB_metszo.Size = new System.Drawing.Size(65, 17);
            this.rB_metszo.TabIndex = 1;
            this.rB_metszo.TabStop = true;
            this.rB_metszo.Text = "Metsző";
            this.rB_metszo.UseVisualStyleBackColor = true;
            this.rB_metszo.CheckedChanged += new System.EventHandler(this.rB_daralo_EnabledChanged);
            // 
            // rB_hordo
            // 
            this.rB_hordo.AutoSize = true;
            this.rB_hordo.Location = new System.Drawing.Point(17, 68);
            this.rB_hordo.Name = "rB_hordo";
            this.rB_hordo.Size = new System.Drawing.Size(59, 17);
            this.rB_hordo.TabIndex = 2;
            this.rB_hordo.TabStop = true;
            this.rB_hordo.Text = "Hordó";
            this.rB_hordo.UseVisualStyleBackColor = true;
            this.rB_hordo.CheckedChanged += new System.EventHandler(this.rB_daralo_EnabledChanged);
            // 
            // lb_nev
            // 
            this.lb_nev.AutoSize = true;
            this.lb_nev.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_nev.Location = new System.Drawing.Point(56, 214);
            this.lb_nev.Name = "lb_nev";
            this.lb_nev.Size = new System.Drawing.Size(41, 17);
            this.lb_nev.TabIndex = 2;
            this.lb_nev.Text = "Név:";
            // 
            // lb_valtozik
            // 
            this.lb_valtozik.AutoSize = true;
            this.lb_valtozik.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_valtozik.Location = new System.Drawing.Point(3, 300);
            this.lb_valtozik.Name = "lb_valtozik";
            this.lb_valtozik.Size = new System.Drawing.Size(94, 17);
            this.lb_valtozik.TabIndex = 3;
            this.lb_valtozik.Text = "Berúgott-e?";
            // 
            // lb_emberadat
            // 
            this.lb_emberadat.AutoSize = true;
            this.lb_emberadat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_emberadat.Location = new System.Drawing.Point(303, 175);
            this.lb_emberadat.Name = "lb_emberadat";
            this.lb_emberadat.Size = new System.Drawing.Size(106, 17);
            this.lb_emberadat.TabIndex = 4;
            this.lb_emberadat.Text = "Ember Adata:";
            // 
            // lb_erk
            // 
            this.lb_erk.AutoSize = true;
            this.lb_erk.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_erk.Location = new System.Drawing.Point(26, 255);
            this.lb_erk.Name = "lb_erk";
            this.lb_erk.Size = new System.Drawing.Size(71, 17);
            this.lb_erk.TabIndex = 5;
            this.lb_erk.Text = "Érkezés:";
            // 
            // tB_nev
            // 
            this.tB_nev.Location = new System.Drawing.Point(103, 214);
            this.tB_nev.Name = "tB_nev";
            this.tB_nev.Size = new System.Drawing.Size(139, 20);
            this.tB_nev.TabIndex = 6;
            // 
            // tB_erk
            // 
            this.tB_erk.Location = new System.Drawing.Point(103, 255);
            this.tB_erk.Name = "tB_erk";
            this.tB_erk.Size = new System.Drawing.Size(139, 20);
            this.tB_erk.TabIndex = 7;
            // 
            // tB_valtozik
            // 
            this.tB_valtozik.Location = new System.Drawing.Point(142, 297);
            this.tB_valtozik.Name = "tB_valtozik";
            this.tB_valtozik.Size = new System.Drawing.Size(100, 20);
            this.tB_valtozik.TabIndex = 8;
            // 
            // tB_adat
            // 
            this.tB_adat.Location = new System.Drawing.Point(306, 211);
            this.tB_adat.Name = "tB_adat";
            this.tB_adat.Size = new System.Drawing.Size(290, 20);
            this.tB_adat.TabIndex = 9;
            // 
            // bt_mehet
            // 
            this.bt_mehet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_mehet.Location = new System.Drawing.Point(306, 285);
            this.bt_mehet.Name = "bt_mehet";
            this.bt_mehet.Size = new System.Drawing.Size(103, 32);
            this.bt_mehet.TabIndex = 10;
            this.bt_mehet.Text = "Mehet!";
            this.bt_mehet.UseVisualStyleBackColor = true;
            this.bt_mehet.Click += new System.EventHandler(this.bt_mehet_Click);
            // 
            // lb_megj
            // 
            this.lb_megj.AutoSize = true;
            this.lb_megj.Location = new System.Drawing.Point(3, 320);
            this.lb_megj.Name = "lb_megj";
            this.lb_megj.Size = new System.Drawing.Size(139, 13);
            this.lb_megj.TabIndex = 11;
            this.lb_megj.Text = "(0= hamis, minden más igaz)";
            // 
            // orok_dolg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 356);
            this.Controls.Add(this.lb_megj);
            this.Controls.Add(this.bt_mehet);
            this.Controls.Add(this.tB_adat);
            this.Controls.Add(this.tB_valtozik);
            this.Controls.Add(this.tB_erk);
            this.Controls.Add(this.tB_nev);
            this.Controls.Add(this.lb_erk);
            this.Controls.Add(this.lb_emberadat);
            this.Controls.Add(this.lb_valtozik);
            this.Controls.Add(this.lb_nev);
            this.Controls.Add(this.gB_ember);
            this.Name = "orok_dolg";
            this.Text = "Öröklődés dolgozat";
            this.gB_ember.ResumeLayout(false);
            this.gB_ember.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rB_daralo;
        private System.Windows.Forms.GroupBox gB_ember;
        private System.Windows.Forms.RadioButton rB_hordo;
        private System.Windows.Forms.RadioButton rB_metszo;
        private System.Windows.Forms.Label lb_nev;
        private System.Windows.Forms.Label lb_valtozik;
        private System.Windows.Forms.Label lb_emberadat;
        private System.Windows.Forms.Label lb_erk;
        private System.Windows.Forms.TextBox tB_nev;
        private System.Windows.Forms.TextBox tB_erk;
        private System.Windows.Forms.TextBox tB_valtozik;
        private System.Windows.Forms.TextBox tB_adat;
        private System.Windows.Forms.Button bt_mehet;
        private System.Windows.Forms.Label lb_megj;
    }
}

