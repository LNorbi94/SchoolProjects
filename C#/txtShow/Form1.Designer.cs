namespace WindowsFormsApplication2
{
    partial class txtShow
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
            this.main = new System.Windows.Forms.DataGridView();
            this.upload = new System.Windows.Forms.Button();
            this.results = new System.Windows.Forms.DataGridView();
            this.quit = new System.Windows.Forms.Button();
            this.tb_search = new System.Windows.Forms.TextBox();
            this.searching = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.gB = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.results)).BeginInit();
            this.gB.SuspendLayout();
            this.SuspendLayout();
            // 
            // main
            // 
            this.main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.main.Location = new System.Drawing.Point(17, 74);
            this.main.Name = "main";
            this.main.Size = new System.Drawing.Size(1096, 399);
            this.main.TabIndex = 0;
            // 
            // upload
            // 
            this.upload.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.upload.Location = new System.Drawing.Point(793, 25);
            this.upload.Name = "upload";
            this.upload.Size = new System.Drawing.Size(152, 35);
            this.upload.TabIndex = 1;
            this.upload.Text = "Feltöltés";
            this.upload.UseVisualStyleBackColor = true;
            this.upload.Click += new System.EventHandler(this.feltolt_Click);
            // 
            // results
            // 
            this.results.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.results.Location = new System.Drawing.Point(17, 491);
            this.results.Name = "results";
            this.results.Size = new System.Drawing.Size(1096, 250);
            this.results.TabIndex = 2;
            // 
            // quit
            // 
            this.quit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.quit.Location = new System.Drawing.Point(961, 25);
            this.quit.Name = "quit";
            this.quit.Size = new System.Drawing.Size(152, 35);
            this.quit.TabIndex = 3;
            this.quit.Text = "Kilépés";
            this.quit.UseVisualStyleBackColor = true;
            this.quit.Click += new System.EventHandler(this.quit_Click);
            // 
            // tb_search
            // 
            this.tb_search.Location = new System.Drawing.Point(36, 65);
            this.tb_search.Name = "tb_search";
            this.tb_search.Size = new System.Drawing.Size(290, 20);
            this.tb_search.TabIndex = 4;
            // 
            // searching
            // 
            this.searching.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.searching.Location = new System.Drawing.Point(423, 49);
            this.searching.Name = "searching";
            this.searching.Size = new System.Drawing.Size(152, 35);
            this.searching.TabIndex = 5;
            this.searching.Text = "Keresés";
            this.searching.UseVisualStyleBackColor = true;
            this.searching.Click += new System.EventHandler(this.searching_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Keresett érték:";
            // 
            // gB
            // 
            this.gB.Controls.Add(this.label1);
            this.gB.Controls.Add(this.searching);
            this.gB.Controls.Add(this.tb_search);
            this.gB.Location = new System.Drawing.Point(17, -23);
            this.gB.Name = "gB";
            this.gB.Size = new System.Drawing.Size(591, 91);
            this.gB.TabIndex = 8;
            this.gB.TabStop = false;
            this.gB.Text = "groupBox1";
            this.gB.Visible = false;
            // 
            // txtShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1142, 767);
            this.Controls.Add(this.gB);
            this.Controls.Add(this.quit);
            this.Controls.Add(this.results);
            this.Controls.Add(this.upload);
            this.Controls.Add(this.main);
            this.Name = "txtShow";
            this.Text = "txtShow";
            ((System.ComponentModel.ISupportInitialize)(this.main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.results)).EndInit();
            this.gB.ResumeLayout(false);
            this.gB.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView main;
        private System.Windows.Forms.Button upload;
        private System.Windows.Forms.DataGridView results;
        private System.Windows.Forms.Button quit;
        private System.Windows.Forms.TextBox tb_search;
        private System.Windows.Forms.Button searching;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gB;
    }
}

