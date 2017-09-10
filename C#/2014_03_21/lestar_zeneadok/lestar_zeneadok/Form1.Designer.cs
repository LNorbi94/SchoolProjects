namespace lestar_zeneadok
{
    partial class frm_zeneadok
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
            this.bt_fel = new System.Windows.Forms.Button();
            this.be = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.be_text = new System.Windows.Forms.ListBox();
            this.bt_eric = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bt_fel
            // 
            this.bt_fel.Location = new System.Drawing.Point(556, 22);
            this.bt_fel.Name = "bt_fel";
            this.bt_fel.Size = new System.Drawing.Size(75, 23);
            this.bt_fel.TabIndex = 0;
            this.bt_fel.Text = "Feltöltés";
            this.bt_fel.UseVisualStyleBackColor = true;
            this.bt_fel.Click += new System.EventHandler(this.bt_fel_Click);
            // 
            // be
            // 
            this.be.FormattingEnabled = true;
            this.be.Location = new System.Drawing.Point(246, 292);
            this.be.Name = "be";
            this.be.Size = new System.Drawing.Size(277, 95);
            this.be.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(556, 63);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "2. feladat";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // be_text
            // 
            this.be_text.FormattingEnabled = true;
            this.be_text.Location = new System.Drawing.Point(22, 22);
            this.be_text.Name = "be_text";
            this.be_text.Size = new System.Drawing.Size(501, 264);
            this.be_text.TabIndex = 3;
            // 
            // bt_eric
            // 
            this.bt_eric.Location = new System.Drawing.Point(556, 109);
            this.bt_eric.Name = "bt_eric";
            this.bt_eric.Size = new System.Drawing.Size(75, 23);
            this.bt_eric.TabIndex = 4;
            this.bt_eric.Text = "3. feladat";
            this.bt_eric.UseVisualStyleBackColor = true;
            this.bt_eric.Click += new System.EventHandler(this.bt_eric_Click);
            // 
            // frm_zeneadok
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 408);
            this.Controls.Add(this.bt_eric);
            this.Controls.Add(this.be_text);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.be);
            this.Controls.Add(this.bt_fel);
            this.Name = "frm_zeneadok";
            this.Text = "Zenei adók";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt_fel;
        private System.Windows.Forms.ListBox be;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox be_text;
        private System.Windows.Forms.Button bt_eric;
    }
}

