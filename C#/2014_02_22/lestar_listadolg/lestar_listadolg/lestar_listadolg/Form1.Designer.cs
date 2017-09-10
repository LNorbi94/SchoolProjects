namespace lestar_listadolg
{
    partial class lestar_listadolg
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
            this.bt_feltolt = new System.Windows.Forms.Button();
            this.ki = new System.Windows.Forms.ListBox();
            this.bt_osszes = new System.Windows.Forms.Button();
            this.bt_ervenytelen = new System.Windows.Forms.Button();
            this.bt_legtobb = new System.Windows.Forms.Button();
            this.bt_voltetobb = new System.Windows.Forms.Button();
            this.bt_legm = new System.Windows.Forms.Button();
            this.bt_legalabb = new System.Windows.Forms.Button();
            this.bt_sort = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // be
            // 
            this.be.FormattingEnabled = true;
            this.be.Location = new System.Drawing.Point(25, 32);
            this.be.Name = "be";
            this.be.Size = new System.Drawing.Size(341, 420);
            this.be.TabIndex = 0;
            // 
            // bt_feltolt
            // 
            this.bt_feltolt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_feltolt.Location = new System.Drawing.Point(372, 32);
            this.bt_feltolt.Name = "bt_feltolt";
            this.bt_feltolt.Size = new System.Drawing.Size(201, 35);
            this.bt_feltolt.TabIndex = 1;
            this.bt_feltolt.Text = "Feltöltés";
            this.bt_feltolt.UseVisualStyleBackColor = true;
            this.bt_feltolt.Click += new System.EventHandler(this.button1_Click);
            // 
            // ki
            // 
            this.ki.FormattingEnabled = true;
            this.ki.Location = new System.Drawing.Point(579, 32);
            this.ki.Name = "ki";
            this.ki.Size = new System.Drawing.Size(341, 420);
            this.ki.TabIndex = 2;
            // 
            // bt_osszes
            // 
            this.bt_osszes.Enabled = false;
            this.bt_osszes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_osszes.Location = new System.Drawing.Point(372, 73);
            this.bt_osszes.Name = "bt_osszes";
            this.bt_osszes.Size = new System.Drawing.Size(201, 35);
            this.bt_osszes.TabIndex = 3;
            this.bt_osszes.Text = "Összes érvényes szavazat";
            this.bt_osszes.UseVisualStyleBackColor = true;
            this.bt_osszes.Click += new System.EventHandler(this.bt_osszes_Click);
            // 
            // bt_ervenytelen
            // 
            this.bt_ervenytelen.Enabled = false;
            this.bt_ervenytelen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_ervenytelen.Location = new System.Drawing.Point(372, 114);
            this.bt_ervenytelen.Name = "bt_ervenytelen";
            this.bt_ervenytelen.Size = new System.Drawing.Size(201, 35);
            this.bt_ervenytelen.TabIndex = 4;
            this.bt_ervenytelen.Text = "Érvénytelen szavazatok átlaga";
            this.bt_ervenytelen.UseVisualStyleBackColor = true;
            this.bt_ervenytelen.Click += new System.EventHandler(this.bt_ervenytelen_Click);
            // 
            // bt_legtobb
            // 
            this.bt_legtobb.Enabled = false;
            this.bt_legtobb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_legtobb.Location = new System.Drawing.Point(372, 155);
            this.bt_legtobb.Name = "bt_legtobb";
            this.bt_legtobb.Size = new System.Drawing.Size(201, 35);
            this.bt_legtobb.TabIndex = 5;
            this.bt_legtobb.Text = "A legtöbb érvényes szavazatot kapta";
            this.bt_legtobb.UseVisualStyleBackColor = true;
            this.bt_legtobb.Click += new System.EventHandler(this.bt_legtobb_Click);
            // 
            // bt_voltetobb
            // 
            this.bt_voltetobb.Enabled = false;
            this.bt_voltetobb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_voltetobb.Location = new System.Drawing.Point(372, 196);
            this.bt_voltetobb.Name = "bt_voltetobb";
            this.bt_voltetobb.Size = new System.Drawing.Size(201, 35);
            this.bt_voltetobb.TabIndex = 6;
            this.bt_voltetobb.Text = "Volt-e 10nél több érvénytelen?";
            this.bt_voltetobb.UseVisualStyleBackColor = true;
            this.bt_voltetobb.Click += new System.EventHandler(this.bt_voltetobb_Click);
            // 
            // bt_legm
            // 
            this.bt_legm.Enabled = false;
            this.bt_legm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_legm.Location = new System.Drawing.Point(372, 237);
            this.bt_legm.Name = "bt_legm";
            this.bt_legm.Size = new System.Drawing.Size(201, 35);
            this.bt_legm.TabIndex = 7;
            this.bt_legm.Text = "Legmagasabb szavazatszám érvénytelen nélkül";
            this.bt_legm.UseVisualStyleBackColor = true;
            this.bt_legm.Click += new System.EventHandler(this.button6_Click);
            // 
            // bt_legalabb
            // 
            this.bt_legalabb.Enabled = false;
            this.bt_legalabb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_legalabb.Location = new System.Drawing.Point(372, 278);
            this.bt_legalabb.Name = "bt_legalabb";
            this.bt_legalabb.Size = new System.Drawing.Size(201, 35);
            this.bt_legalabb.TabIndex = 8;
            this.bt_legalabb.Text = "Legalább 50 érvényes szavazat";
            this.bt_legalabb.UseVisualStyleBackColor = true;
            this.bt_legalabb.Click += new System.EventHandler(this.bt_legalabb_Click);
            // 
            // bt_sort
            // 
            this.bt_sort.Enabled = false;
            this.bt_sort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bt_sort.Location = new System.Drawing.Point(372, 319);
            this.bt_sort.Name = "bt_sort";
            this.bt_sort.Size = new System.Drawing.Size(201, 35);
            this.bt_sort.TabIndex = 9;
            this.bt_sort.Text = "Versenyzők sorrendje";
            this.bt_sort.UseVisualStyleBackColor = true;
            this.bt_sort.Click += new System.EventHandler(this.bt_sort_Click);
            // 
            // lestar_listadolg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 500);
            this.Controls.Add(this.bt_sort);
            this.Controls.Add(this.bt_legalabb);
            this.Controls.Add(this.bt_legm);
            this.Controls.Add(this.bt_voltetobb);
            this.Controls.Add(this.bt_legtobb);
            this.Controls.Add(this.bt_ervenytelen);
            this.Controls.Add(this.bt_osszes);
            this.Controls.Add(this.ki);
            this.Controls.Add(this.bt_feltolt);
            this.Controls.Add(this.be);
            this.Name = "lestar_listadolg";
            this.Text = "Alkotói verseny";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox be;
        private System.Windows.Forms.Button bt_feltolt;
        private System.Windows.Forms.ListBox ki;
        private System.Windows.Forms.Button bt_osszes;
        private System.Windows.Forms.Button bt_ervenytelen;
        private System.Windows.Forms.Button bt_legtobb;
        private System.Windows.Forms.Button bt_voltetobb;
        private System.Windows.Forms.Button bt_legm;
        private System.Windows.Forms.Button bt_legalabb;
        private System.Windows.Forms.Button bt_sort;
    }
}

