namespace lestar_iskola
{
    partial class iskola
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
            this.button1 = new System.Windows.Forms.Button();
            this.tizenegya = new System.Windows.Forms.Button();
            this.hianyzas = new System.Windows.Forms.Button();
            this.kilep = new System.Windows.Forms.Button();
            this.tanulodg = new System.Windows.Forms.DataGridView();
            this.tanulok = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.adg = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.tanulodg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adg)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(23, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(226, 31);
            this.button1.TabIndex = 0;
            this.button1.Text = "Feltöltés és megjelenítés";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tizenegya
            // 
            this.tizenegya.Enabled = false;
            this.tizenegya.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tizenegya.Location = new System.Drawing.Point(282, 31);
            this.tizenegya.Name = "tizenegya";
            this.tizenegya.Size = new System.Drawing.Size(226, 31);
            this.tizenegya.TabIndex = 1;
            this.tizenegya.Text = "11/A kiválogatása";
            this.tizenegya.UseVisualStyleBackColor = true;
            this.tizenegya.Click += new System.EventHandler(this.tizenegya_Click);
            // 
            // hianyzas
            // 
            this.hianyzas.Enabled = false;
            this.hianyzas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.hianyzas.Location = new System.Drawing.Point(514, 31);
            this.hianyzas.Name = "hianyzas";
            this.hianyzas.Size = new System.Drawing.Size(226, 31);
            this.hianyzas.TabIndex = 2;
            this.hianyzas.Text = "Szétválogatás hiányzás alapján";
            this.hianyzas.UseVisualStyleBackColor = true;
            this.hianyzas.Click += new System.EventHandler(this.hianyzas_Click);
            // 
            // kilep
            // 
            this.kilep.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.kilep.Location = new System.Drawing.Point(855, 31);
            this.kilep.Name = "kilep";
            this.kilep.Size = new System.Drawing.Size(90, 31);
            this.kilep.TabIndex = 3;
            this.kilep.Text = "Kilépés";
            this.kilep.UseVisualStyleBackColor = true;
            this.kilep.Click += new System.EventHandler(this.kilep_Click);
            // 
            // tanulodg
            // 
            this.tanulodg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tanulodg.Location = new System.Drawing.Point(23, 136);
            this.tanulodg.Name = "tanulodg";
            this.tanulodg.ReadOnly = true;
            this.tanulodg.RowHeadersWidth = 60;
            this.tanulodg.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.tanulodg.Size = new System.Drawing.Size(453, 498);
            this.tanulodg.TabIndex = 4;
            // 
            // tanulok
            // 
            this.tanulok.AutoSize = true;
            this.tanulok.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.tanulok.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tanulok.Location = new System.Drawing.Point(164, 92);
            this.tanulok.Name = "tanulok";
            this.tanulok.Size = new System.Drawing.Size(144, 24);
            this.tanulok.TabIndex = 5;
            this.tanulok.Text = "Az iskola tanulói";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(676, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "A 11.A osztály";
            // 
            // adg
            // 
            this.adg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adg.Location = new System.Drawing.Point(513, 136);
            this.adg.Name = "adg";
            this.adg.RowHeadersWidth = 50;
            this.adg.Size = new System.Drawing.Size(453, 445);
            this.adg.TabIndex = 7;
            // 
            // iskola
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(984, 663);
            this.Controls.Add(this.adg);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tanulok);
            this.Controls.Add(this.tanulodg);
            this.Controls.Add(this.kilep);
            this.Controls.Add(this.hianyzas);
            this.Controls.Add(this.tizenegya);
            this.Controls.Add(this.button1);
            this.Location = new System.Drawing.Point(20, 20);
            this.Name = "iskola";
            this.Text = "Iskola";
            ((System.ComponentModel.ISupportInitialize)(this.tanulodg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.adg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button tizenegya;
        private System.Windows.Forms.Button hianyzas;
        private System.Windows.Forms.Button kilep;
        private System.Windows.Forms.DataGridView tanulodg;
        private System.Windows.Forms.Label tanulok;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView adg;
    }
}

