namespace lestar_proba
{
    partial class lestar_nevnap
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.bt_feltoltes = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tb = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.honap = new System.Windows.Forms.TextBox();
            this.nap = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(46, 32);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(379, 472);
            this.listBox1.TabIndex = 0;
            // 
            // bt_feltoltes
            // 
            this.bt_feltoltes.Location = new System.Drawing.Point(472, 32);
            this.bt_feltoltes.Name = "bt_feltoltes";
            this.bt_feltoltes.Size = new System.Drawing.Size(75, 23);
            this.bt_feltoltes.TabIndex = 1;
            this.bt_feltoltes.Text = "Feltöltés";
            this.bt_feltoltes.UseVisualStyleBackColor = true;
            this.bt_feltoltes.Click += new System.EventHandler(this.bt_feltoltes_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(472, 77);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "2.";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(472, 117);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "3.";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tb
            // 
            this.tb.Location = new System.Drawing.Point(563, 117);
            this.tb.Name = "tb";
            this.tb.Size = new System.Drawing.Size(100, 20);
            this.tb.TabIndex = 4;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(472, 162);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "4.";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // honap
            // 
            this.honap.Location = new System.Drawing.Point(563, 165);
            this.honap.Name = "honap";
            this.honap.Size = new System.Drawing.Size(59, 20);
            this.honap.TabIndex = 6;
            // 
            // nap
            // 
            this.nap.Location = new System.Drawing.Point(628, 165);
            this.nap.Name = "nap";
            this.nap.Size = new System.Drawing.Size(59, 20);
            this.nap.TabIndex = 7;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(472, 207);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 8;
            this.button4.Text = "5.";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(472, 245);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 9;
            this.button5.Text = "6.";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // lestar_nevnap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 519);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.nap);
            this.Controls.Add(this.honap);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.tb);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bt_feltoltes);
            this.Controls.Add(this.listBox1);
            this.Name = "lestar_nevnap";
            this.Text = "Névnapok";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button bt_feltoltes;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tb;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox honap;
        private System.Windows.Forms.TextBox nap;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}

