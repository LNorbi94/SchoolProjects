namespace lestar_lamdbavektor
{
    partial class Form1
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
            this.elemek = new System.Windows.Forms.ListBox();
            this.lb_elem = new System.Windows.Forms.Label();
            this.bt_otnel = new System.Windows.Forms.Button();
            this.bt_otven = new System.Windows.Forms.Button();
            this.bt_ot = new System.Windows.Forms.Button();
            this.bt_otvennel = new System.Windows.Forms.Button();
            this.bt_kettohat = new System.Windows.Forms.Button();
            this.bt_paros = new System.Windows.Forms.Button();
            this.bt_parosutolso = new System.Windows.Forms.Button();
            this.bt_parossz = new System.Windows.Forms.Button();
            this.bt_negyzet = new System.Windows.Forms.Button();
            this.bt_kob = new System.Windows.Forms.Button();
            this.bt_osszeg = new System.Windows.Forms.Button();
            this.bt_negyzeto = new System.Windows.Forms.Button();
            this.bt_paroso = new System.Windows.Forms.Button();
            this.bt_atlag = new System.Windows.Forms.Button();
            this.bt_patlag = new System.Windows.Forms.Button();
            this.bt_parosszam = new System.Windows.Forms.Button();
            this.bt_legn = new System.Windows.Forms.Button();
            this.bt_legnhely = new System.Windows.Forms.Button();
            this.bt_legnp = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.ki = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // feltolt
            // 
            this.feltolt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.feltolt.Location = new System.Drawing.Point(31, 192);
            this.feltolt.Name = "feltolt";
            this.feltolt.Size = new System.Drawing.Size(134, 30);
            this.feltolt.TabIndex = 0;
            this.feltolt.Text = "Feltöltés";
            this.feltolt.UseVisualStyleBackColor = true;
            this.feltolt.Click += new System.EventHandler(this.button1_Click);
            // 
            // elemek
            // 
            this.elemek.FormattingEnabled = true;
            this.elemek.Location = new System.Drawing.Point(31, 68);
            this.elemek.Name = "elemek";
            this.elemek.Size = new System.Drawing.Size(49, 95);
            this.elemek.TabIndex = 1;
            // 
            // lb_elem
            // 
            this.lb_elem.AutoSize = true;
            this.lb_elem.Location = new System.Drawing.Point(28, 25);
            this.lb_elem.Name = "lb_elem";
            this.lb_elem.Size = new System.Drawing.Size(83, 13);
            this.lb_elem.TabIndex = 2;
            this.lb_elem.Text = "A vektor elemei:";
            // 
            // bt_otnel
            // 
            this.bt_otnel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_otnel.Location = new System.Drawing.Point(206, 25);
            this.bt_otnel.Name = "bt_otnel";
            this.bt_otnel.Size = new System.Drawing.Size(246, 30);
            this.bt_otnel.TabIndex = 3;
            this.bt_otnel.Text = "Az első ötnél nagyobb érték";
            this.bt_otnel.UseVisualStyleBackColor = true;
            this.bt_otnel.Click += new System.EventHandler(this.bt_otnel_Click);
            // 
            // bt_otven
            // 
            this.bt_otven.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_otven.Location = new System.Drawing.Point(206, 61);
            this.bt_otven.Name = "bt_otven";
            this.bt_otven.Size = new System.Drawing.Size(246, 30);
            this.bt_otven.TabIndex = 4;
            this.bt_otven.Text = "Az első ötvennél nagyobb érték";
            this.bt_otven.UseVisualStyleBackColor = true;
            this.bt_otven.Click += new System.EventHandler(this.button2_Click);
            // 
            // bt_ot
            // 
            this.bt_ot.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_ot.Location = new System.Drawing.Point(206, 97);
            this.bt_ot.Name = "bt_ot";
            this.bt_ot.Size = new System.Drawing.Size(246, 30);
            this.bt_ot.TabIndex = 5;
            this.bt_ot.Text = "Az ötnél nagyobb értékek";
            this.bt_ot.UseVisualStyleBackColor = true;
            this.bt_ot.Click += new System.EventHandler(this.bt_ot_Click);
            // 
            // bt_otvennel
            // 
            this.bt_otvennel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_otvennel.Location = new System.Drawing.Point(206, 133);
            this.bt_otvennel.Name = "bt_otvennel";
            this.bt_otvennel.Size = new System.Drawing.Size(246, 30);
            this.bt_otvennel.TabIndex = 6;
            this.bt_otvennel.Text = "Az ötvennél nagyobb értékek";
            this.bt_otvennel.UseVisualStyleBackColor = true;
            this.bt_otvennel.Click += new System.EventHandler(this.bt_otvennel_Click);
            // 
            // bt_kettohat
            // 
            this.bt_kettohat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_kettohat.Location = new System.Drawing.Point(206, 169);
            this.bt_kettohat.Name = "bt_kettohat";
            this.bt_kettohat.Size = new System.Drawing.Size(246, 30);
            this.bt_kettohat.TabIndex = 7;
            this.bt_kettohat.Text = "Kettő és hat közötti számok";
            this.bt_kettohat.UseVisualStyleBackColor = true;
            this.bt_kettohat.Click += new System.EventHandler(this.bt_kettohat_Click);
            // 
            // bt_paros
            // 
            this.bt_paros.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_paros.Location = new System.Drawing.Point(206, 205);
            this.bt_paros.Name = "bt_paros";
            this.bt_paros.Size = new System.Drawing.Size(246, 30);
            this.bt_paros.TabIndex = 8;
            this.bt_paros.Text = "Az első páros szám";
            this.bt_paros.UseVisualStyleBackColor = true;
            this.bt_paros.Click += new System.EventHandler(this.button6_Click);
            // 
            // bt_parosutolso
            // 
            this.bt_parosutolso.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_parosutolso.Location = new System.Drawing.Point(206, 241);
            this.bt_parosutolso.Name = "bt_parosutolso";
            this.bt_parosutolso.Size = new System.Drawing.Size(246, 30);
            this.bt_parosutolso.TabIndex = 9;
            this.bt_parosutolso.Text = "Az utolsó páros szám";
            this.bt_parosutolso.UseVisualStyleBackColor = true;
            this.bt_parosutolso.Click += new System.EventHandler(this.bt_parosutolso_Click);
            // 
            // bt_parossz
            // 
            this.bt_parossz.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_parossz.Location = new System.Drawing.Point(206, 277);
            this.bt_parossz.Name = "bt_parossz";
            this.bt_parossz.Size = new System.Drawing.Size(246, 30);
            this.bt_parossz.TabIndex = 10;
            this.bt_parossz.Text = "Páros számok";
            this.bt_parossz.UseVisualStyleBackColor = true;
            this.bt_parossz.Click += new System.EventHandler(this.bt_parossz_Click);
            // 
            // bt_negyzet
            // 
            this.bt_negyzet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_negyzet.Location = new System.Drawing.Point(206, 313);
            this.bt_negyzet.Name = "bt_negyzet";
            this.bt_negyzet.Size = new System.Drawing.Size(246, 30);
            this.bt_negyzet.TabIndex = 11;
            this.bt_negyzet.Text = "A számok négyzetei";
            this.bt_negyzet.UseVisualStyleBackColor = true;
            this.bt_negyzet.Click += new System.EventHandler(this.bt_negyzet_Click);
            // 
            // bt_kob
            // 
            this.bt_kob.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_kob.Location = new System.Drawing.Point(206, 349);
            this.bt_kob.Name = "bt_kob";
            this.bt_kob.Size = new System.Drawing.Size(246, 30);
            this.bt_kob.TabIndex = 12;
            this.bt_kob.Text = "A számok köbei";
            this.bt_kob.UseVisualStyleBackColor = true;
            this.bt_kob.Click += new System.EventHandler(this.button10_Click);
            // 
            // bt_osszeg
            // 
            this.bt_osszeg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_osszeg.Location = new System.Drawing.Point(479, 25);
            this.bt_osszeg.Name = "bt_osszeg";
            this.bt_osszeg.Size = new System.Drawing.Size(217, 30);
            this.bt_osszeg.TabIndex = 13;
            this.bt_osszeg.Text = "Számok összege";
            this.bt_osszeg.UseVisualStyleBackColor = true;
            this.bt_osszeg.Click += new System.EventHandler(this.button11_Click);
            // 
            // bt_negyzeto
            // 
            this.bt_negyzeto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_negyzeto.Location = new System.Drawing.Point(479, 61);
            this.bt_negyzeto.Name = "bt_negyzeto";
            this.bt_negyzeto.Size = new System.Drawing.Size(217, 30);
            this.bt_negyzeto.TabIndex = 14;
            this.bt_negyzeto.Text = "Számok négyzetösszege";
            this.bt_negyzeto.UseVisualStyleBackColor = true;
            this.bt_negyzeto.Click += new System.EventHandler(this.bt_negyzeto_Click);
            // 
            // bt_paroso
            // 
            this.bt_paroso.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_paroso.Location = new System.Drawing.Point(479, 97);
            this.bt_paroso.Name = "bt_paroso";
            this.bt_paroso.Size = new System.Drawing.Size(217, 30);
            this.bt_paroso.TabIndex = 15;
            this.bt_paroso.Text = "Páros számok összege";
            this.bt_paroso.UseVisualStyleBackColor = true;
            this.bt_paroso.Click += new System.EventHandler(this.bt_paroso_Click);
            // 
            // bt_atlag
            // 
            this.bt_atlag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_atlag.Location = new System.Drawing.Point(479, 133);
            this.bt_atlag.Name = "bt_atlag";
            this.bt_atlag.Size = new System.Drawing.Size(217, 30);
            this.bt_atlag.TabIndex = 16;
            this.bt_atlag.Text = "Számok átlaga";
            this.bt_atlag.UseVisualStyleBackColor = true;
            this.bt_atlag.Click += new System.EventHandler(this.bt_atlag_Click);
            // 
            // bt_patlag
            // 
            this.bt_patlag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_patlag.Location = new System.Drawing.Point(479, 169);
            this.bt_patlag.Name = "bt_patlag";
            this.bt_patlag.Size = new System.Drawing.Size(217, 30);
            this.bt_patlag.TabIndex = 17;
            this.bt_patlag.Text = "Páros számok átlaga";
            this.bt_patlag.UseVisualStyleBackColor = true;
            this.bt_patlag.Click += new System.EventHandler(this.bt_patlag_Click);
            // 
            // bt_parosszam
            // 
            this.bt_parosszam.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_parosszam.Location = new System.Drawing.Point(479, 205);
            this.bt_parosszam.Name = "bt_parosszam";
            this.bt_parosszam.Size = new System.Drawing.Size(217, 30);
            this.bt_parosszam.TabIndex = 18;
            this.bt_parosszam.Text = "Páros számok száma";
            this.bt_parosszam.UseVisualStyleBackColor = true;
            this.bt_parosszam.Click += new System.EventHandler(this.bt_parosszam_Click);
            // 
            // bt_legn
            // 
            this.bt_legn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_legn.Location = new System.Drawing.Point(479, 241);
            this.bt_legn.Name = "bt_legn";
            this.bt_legn.Size = new System.Drawing.Size(217, 30);
            this.bt_legn.TabIndex = 19;
            this.bt_legn.Text = "Legnagyobb szám";
            this.bt_legn.UseVisualStyleBackColor = true;
            this.bt_legn.Click += new System.EventHandler(this.bt_legn_Click);
            // 
            // bt_legnhely
            // 
            this.bt_legnhely.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_legnhely.Location = new System.Drawing.Point(479, 277);
            this.bt_legnhely.Name = "bt_legnhely";
            this.bt_legnhely.Size = new System.Drawing.Size(217, 30);
            this.bt_legnhely.TabIndex = 20;
            this.bt_legnhely.Text = "Legnagyobb szám helye";
            this.bt_legnhely.UseVisualStyleBackColor = true;
            this.bt_legnhely.Click += new System.EventHandler(this.bt_legnhely_Click);
            // 
            // bt_legnp
            // 
            this.bt_legnp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_legnp.Location = new System.Drawing.Point(479, 313);
            this.bt_legnp.Name = "bt_legnp";
            this.bt_legnp.Size = new System.Drawing.Size(217, 30);
            this.bt_legnp.TabIndex = 21;
            this.bt_legnp.Text = "Legnagyobb páros szám";
            this.bt_legnp.UseVisualStyleBackColor = true;
            this.bt_legnp.Click += new System.EventHandler(this.bt_legnp_Click);
            // 
            // button20
            // 
            this.button20.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button20.Location = new System.Drawing.Point(479, 349);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(217, 30);
            this.button20.TabIndex = 22;
            this.button20.Text = "Legnagyobb negatív szám";
            this.button20.UseVisualStyleBackColor = true;
            this.button20.Click += new System.EventHandler(this.button20_Click);
            // 
            // ki
            // 
            this.ki.FormattingEnabled = true;
            this.ki.Location = new System.Drawing.Point(714, 24);
            this.ki.Name = "ki";
            this.ki.Size = new System.Drawing.Size(152, 355);
            this.ki.TabIndex = 23;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 401);
            this.Controls.Add(this.ki);
            this.Controls.Add(this.button20);
            this.Controls.Add(this.bt_legnp);
            this.Controls.Add(this.bt_legnhely);
            this.Controls.Add(this.bt_legn);
            this.Controls.Add(this.bt_parosszam);
            this.Controls.Add(this.bt_patlag);
            this.Controls.Add(this.bt_atlag);
            this.Controls.Add(this.bt_paroso);
            this.Controls.Add(this.bt_negyzeto);
            this.Controls.Add(this.bt_osszeg);
            this.Controls.Add(this.bt_kob);
            this.Controls.Add(this.bt_negyzet);
            this.Controls.Add(this.bt_parossz);
            this.Controls.Add(this.bt_parosutolso);
            this.Controls.Add(this.bt_paros);
            this.Controls.Add(this.bt_kettohat);
            this.Controls.Add(this.bt_otvennel);
            this.Controls.Add(this.bt_ot);
            this.Controls.Add(this.bt_otven);
            this.Controls.Add(this.bt_otnel);
            this.Controls.Add(this.lb_elem);
            this.Controls.Add(this.elemek);
            this.Controls.Add(this.feltolt);
            this.Name = "Form1";
            this.Text = "Lamdba - vektor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button feltolt;
        private System.Windows.Forms.ListBox elemek;
        private System.Windows.Forms.Label lb_elem;
        private System.Windows.Forms.Button bt_otnel;
        private System.Windows.Forms.Button bt_otven;
        private System.Windows.Forms.Button bt_ot;
        private System.Windows.Forms.Button bt_otvennel;
        private System.Windows.Forms.Button bt_kettohat;
        private System.Windows.Forms.Button bt_paros;
        private System.Windows.Forms.Button bt_parosutolso;
        private System.Windows.Forms.Button bt_parossz;
        private System.Windows.Forms.Button bt_negyzet;
        private System.Windows.Forms.Button bt_kob;
        private System.Windows.Forms.Button bt_osszeg;
        private System.Windows.Forms.Button bt_negyzeto;
        private System.Windows.Forms.Button bt_paroso;
        private System.Windows.Forms.Button bt_atlag;
        private System.Windows.Forms.Button bt_patlag;
        private System.Windows.Forms.Button bt_parosszam;
        private System.Windows.Forms.Button bt_legn;
        private System.Windows.Forms.Button bt_legnhely;
        private System.Windows.Forms.Button bt_legnp;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.ListBox ki;
    }
}

