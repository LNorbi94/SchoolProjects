namespace Homerseklet
{
    partial class homerseklet
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
            this.be = new System.Windows.Forms.DataGridView();
            this.feltolt = new System.Windows.Forms.Button();
            this.legmelegebb = new System.Windows.Forms.Button();
            this.tizfok = new System.Windows.Forms.Button();
            this.volte = new System.Windows.Forms.Button();
            this.atlaghomerseklet = new System.Windows.Forms.Button();
            this.be2 = new System.Windows.Forms.ListBox();
            this.volteertek = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.be)).BeginInit();
            this.SuspendLayout();
            // 
            // be
            // 
            this.be.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.be.ColumnHeadersVisible = false;
            this.be.Location = new System.Drawing.Point(25, 24);
            this.be.Name = "be";
            this.be.RowHeadersVisible = false;
            this.be.Size = new System.Drawing.Size(504, 224);
            this.be.TabIndex = 0;
            // 
            // feltolt
            // 
            this.feltolt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.feltolt.Location = new System.Drawing.Point(25, 279);
            this.feltolt.Name = "feltolt";
            this.feltolt.Size = new System.Drawing.Size(151, 33);
            this.feltolt.TabIndex = 1;
            this.feltolt.Text = "Feltöltés és Kiírás";
            this.feltolt.UseVisualStyleBackColor = true;
            this.feltolt.Click += new System.EventHandler(this.feltolt_Click);
            // 
            // legmelegebb
            // 
            this.legmelegebb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.legmelegebb.Location = new System.Drawing.Point(136, 328);
            this.legmelegebb.Name = "legmelegebb";
            this.legmelegebb.Size = new System.Drawing.Size(210, 33);
            this.legmelegebb.TabIndex = 2;
            this.legmelegebb.Text = "Legmelegebb mért érték";
            this.legmelegebb.UseVisualStyleBackColor = true;
            this.legmelegebb.Click += new System.EventHandler(this.legmelegebb_Click);
            // 
            // tizfok
            // 
            this.tizfok.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tizfok.Location = new System.Drawing.Point(195, 279);
            this.tizfok.Name = "tizfok";
            this.tizfok.Size = new System.Drawing.Size(151, 33);
            this.tizfok.TabIndex = 3;
            this.tizfok.Text = "10 fok alatt";
            this.tizfok.UseVisualStyleBackColor = true;
            this.tizfok.Click += new System.EventHandler(this.tizfok_Click);
            // 
            // volte
            // 
            this.volte.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.volte.Location = new System.Drawing.Point(364, 279);
            this.volte.Name = "volte";
            this.volte.Size = new System.Drawing.Size(151, 33);
            this.volte.TabIndex = 4;
            this.volte.Text = "Volt-e ilyen";
            this.volte.UseVisualStyleBackColor = true;
            this.volte.Click += new System.EventHandler(this.volte_Click);
            // 
            // atlaghomerseklet
            // 
            this.atlaghomerseklet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.atlaghomerseklet.Location = new System.Drawing.Point(364, 328);
            this.atlaghomerseklet.Name = "atlaghomerseklet";
            this.atlaghomerseklet.Size = new System.Drawing.Size(151, 33);
            this.atlaghomerseklet.TabIndex = 5;
            this.atlaghomerseklet.Text = "Átlaghőmérséklet";
            this.atlaghomerseklet.UseVisualStyleBackColor = true;
            this.atlaghomerseklet.Click += new System.EventHandler(this.atlaghomerseklet_Click);
            // 
            // be2
            // 
            this.be2.FormattingEnabled = true;
            this.be2.Location = new System.Drawing.Point(561, 24);
            this.be2.Name = "be2";
            this.be2.Size = new System.Drawing.Size(308, 342);
            this.be2.TabIndex = 6;
            // 
            // volteertek
            // 
            this.volteertek.Location = new System.Drawing.Point(415, 253);
            this.volteertek.Name = "volteertek";
            this.volteertek.Size = new System.Drawing.Size(100, 20);
            this.volteertek.TabIndex = 7;
            // 
            // homerseklet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 411);
            this.Controls.Add(this.volteertek);
            this.Controls.Add(this.be2);
            this.Controls.Add(this.atlaghomerseklet);
            this.Controls.Add(this.volte);
            this.Controls.Add(this.tizfok);
            this.Controls.Add(this.legmelegebb);
            this.Controls.Add(this.feltolt);
            this.Controls.Add(this.be);
            this.Name = "homerseklet";
            this.Text = "Hőmérséklet";
            ((System.ComponentModel.ISupportInitialize)(this.be)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView be;
        private System.Windows.Forms.Button feltolt;
        private System.Windows.Forms.Button legmelegebb;
        private System.Windows.Forms.Button tizfok;
        private System.Windows.Forms.Button volte;
        private System.Windows.Forms.Button atlaghomerseklet;
        private System.Windows.Forms.ListBox be2;
        private System.Windows.Forms.TextBox volteertek;
    }
}

