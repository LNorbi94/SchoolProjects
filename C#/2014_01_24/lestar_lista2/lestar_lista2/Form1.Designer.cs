namespace lestar_lista2
{
    partial class list2
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
            this.bt_legn = new System.Windows.Forms.Button();
            this.keres = new System.Windows.Forms.Button();
            this.bt_csokken = new System.Windows.Forms.Button();
            this.bt_huszonharom = new System.Windows.Forms.Button();
            this.bt_torolegy = new System.Windows.Forms.Button();
            this.bt_torolketto = new System.Windows.Forms.Button();
            this.bt_osszes = new System.Windows.Forms.Button();
            this.bt_felett = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // feltolt
            // 
            this.feltolt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.feltolt.Location = new System.Drawing.Point(366, 12);
            this.feltolt.Name = "feltolt";
            this.feltolt.Size = new System.Drawing.Size(204, 30);
            this.feltolt.TabIndex = 0;
            this.feltolt.Text = "Feltöltés és megjelenítés";
            this.feltolt.UseVisualStyleBackColor = true;
            this.feltolt.Click += new System.EventHandler(this.button1_Click);
            // 
            // be
            // 
            this.be.FormattingEnabled = true;
            this.be.Location = new System.Drawing.Point(12, 12);
            this.be.Name = "be";
            this.be.Size = new System.Drawing.Size(338, 355);
            this.be.TabIndex = 1;
            // 
            // bt_legn
            // 
            this.bt_legn.Enabled = false;
            this.bt_legn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_legn.Location = new System.Drawing.Point(366, 48);
            this.bt_legn.Name = "bt_legn";
            this.bt_legn.Size = new System.Drawing.Size(204, 30);
            this.bt_legn.TabIndex = 2;
            this.bt_legn.Text = "Maximum";
            this.bt_legn.UseVisualStyleBackColor = true;
            this.bt_legn.Click += new System.EventHandler(this.bt_legn_Click);
            // 
            // keres
            // 
            this.keres.Enabled = false;
            this.keres.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.keres.Location = new System.Drawing.Point(366, 84);
            this.keres.Name = "keres";
            this.keres.Size = new System.Drawing.Size(204, 30);
            this.keres.TabIndex = 3;
            this.keres.Text = "Van-e 47?";
            this.keres.UseVisualStyleBackColor = true;
            this.keres.Click += new System.EventHandler(this.keres_Click);
            // 
            // bt_csokken
            // 
            this.bt_csokken.Enabled = false;
            this.bt_csokken.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_csokken.Location = new System.Drawing.Point(366, 120);
            this.bt_csokken.Name = "bt_csokken";
            this.bt_csokken.Size = new System.Drawing.Size(204, 30);
            this.bt_csokken.TabIndex = 4;
            this.bt_csokken.Text = "Csökkenő sorrend";
            this.bt_csokken.UseVisualStyleBackColor = true;
            this.bt_csokken.Click += new System.EventHandler(this.bt_csokken_Click);
            // 
            // bt_huszonharom
            // 
            this.bt_huszonharom.Enabled = false;
            this.bt_huszonharom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_huszonharom.Location = new System.Drawing.Point(366, 156);
            this.bt_huszonharom.Name = "bt_huszonharom";
            this.bt_huszonharom.Size = new System.Drawing.Size(204, 30);
            this.bt_huszonharom.TabIndex = 5;
            this.bt_huszonharom.Text = "Van-e 23?";
            this.bt_huszonharom.UseVisualStyleBackColor = true;
            this.bt_huszonharom.Click += new System.EventHandler(this.bt_huszonharom_Click);
            // 
            // bt_torolegy
            // 
            this.bt_torolegy.Enabled = false;
            this.bt_torolegy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_torolegy.Location = new System.Drawing.Point(366, 192);
            this.bt_torolegy.Name = "bt_torolegy";
            this.bt_torolegy.Size = new System.Drawing.Size(204, 30);
            this.bt_torolegy.TabIndex = 6;
            this.bt_torolegy.Text = "33 törlése";
            this.bt_torolegy.UseVisualStyleBackColor = true;
            this.bt_torolegy.Click += new System.EventHandler(this.bt_torolegy_Click);
            // 
            // bt_torolketto
            // 
            this.bt_torolketto.Enabled = false;
            this.bt_torolketto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_torolketto.Location = new System.Drawing.Point(366, 228);
            this.bt_torolketto.Name = "bt_torolketto";
            this.bt_torolketto.Size = new System.Drawing.Size(204, 30);
            this.bt_torolketto.TabIndex = 7;
            this.bt_torolketto.Text = "3. elem törlése";
            this.bt_torolketto.UseVisualStyleBackColor = true;
            this.bt_torolketto.Click += new System.EventHandler(this.bt_torolketto_Click);
            // 
            // bt_osszes
            // 
            this.bt_osszes.Enabled = false;
            this.bt_osszes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_osszes.Location = new System.Drawing.Point(366, 264);
            this.bt_osszes.Name = "bt_osszes";
            this.bt_osszes.Size = new System.Drawing.Size(204, 30);
            this.bt_osszes.TabIndex = 8;
            this.bt_osszes.Text = "Összes dobott pont";
            this.bt_osszes.UseVisualStyleBackColor = true;
            this.bt_osszes.Click += new System.EventHandler(this.bt_osszes_Click);
            // 
            // bt_felett
            // 
            this.bt_felett.Enabled = false;
            this.bt_felett.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_felett.Location = new System.Drawing.Point(366, 300);
            this.bt_felett.Name = "bt_felett";
            this.bt_felett.Size = new System.Drawing.Size(204, 30);
            this.bt_felett.TabIndex = 9;
            this.bt_felett.Text = "32 feletti dobások száma";
            this.bt_felett.UseVisualStyleBackColor = true;
            this.bt_felett.Click += new System.EventHandler(this.bt_felett_Click);
            // 
            // list2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 375);
            this.Controls.Add(this.bt_felett);
            this.Controls.Add(this.bt_osszes);
            this.Controls.Add(this.bt_torolketto);
            this.Controls.Add(this.bt_torolegy);
            this.Controls.Add(this.bt_huszonharom);
            this.Controls.Add(this.bt_csokken);
            this.Controls.Add(this.keres);
            this.Controls.Add(this.bt_legn);
            this.Controls.Add(this.be);
            this.Controls.Add(this.feltolt);
            this.Name = "list2";
            this.Text = "Lista";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button feltolt;
        private System.Windows.Forms.ListBox be;
        private System.Windows.Forms.Button bt_legn;
        private System.Windows.Forms.Button keres;
        private System.Windows.Forms.Button bt_csokken;
        private System.Windows.Forms.Button bt_huszonharom;
        private System.Windows.Forms.Button bt_torolegy;
        private System.Windows.Forms.Button bt_torolketto;
        private System.Windows.Forms.Button bt_osszes;
        private System.Windows.Forms.Button bt_felett;
    }
}

