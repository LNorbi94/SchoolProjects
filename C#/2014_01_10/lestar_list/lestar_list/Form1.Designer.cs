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
            this.bt_mehet.Location = new System.Drawing.Point(12, 17);
            this.bt_mehet.Name = "bt_mehet";
            this.bt_mehet.Size = new System.Drawing.Size(75, 23);
            this.bt_mehet.TabIndex = 1;
            this.bt_mehet.Text = "Mehet!";
            this.bt_mehet.UseVisualStyleBackColor = true;
            this.bt_mehet.Click += new System.EventHandler(this.bt_mehet_Click);
            // 
            // osztalyzatok
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 421);
            this.Controls.Add(this.bt_mehet);
            this.Controls.Add(this.be);
            this.Name = "osztalyzatok";
            this.Text = "Osztályzatok";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox be;
        private System.Windows.Forms.Button bt_mehet;
    }
}

