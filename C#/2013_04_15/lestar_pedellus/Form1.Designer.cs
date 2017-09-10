namespace lestar_pedellus
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lb_pont = new System.Windows.Forms.Label();
            this.p_hatter = new System.Windows.Forms.Panel();
            this.lb_Pontc = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::lestar_pedellus.Properties.Resources.haz;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(900, 580);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lb_pont
            // 
            this.lb_pont.AutoSize = true;
            this.lb_pont.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_pont.ForeColor = System.Drawing.Color.Maroon;
            this.lb_pont.Location = new System.Drawing.Point(817, 435);
            this.lb_pont.Name = "lb_pont";
            this.lb_pont.Size = new System.Drawing.Size(23, 25);
            this.lb_pont.TabIndex = 1;
            this.lb_pont.Text = "0";
            // 
            // p_hatter
            // 
            this.p_hatter.BackColor = System.Drawing.Color.Maroon;
            this.p_hatter.Location = new System.Drawing.Point(349, 170);
            this.p_hatter.Name = "p_hatter";
            this.p_hatter.Size = new System.Drawing.Size(292, 308);
            this.p_hatter.TabIndex = 2;
            // 
            // lb_Pontc
            // 
            this.lb_Pontc.AutoSize = true;
            this.lb_Pontc.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_Pontc.Location = new System.Drawing.Point(706, 435);
            this.lb_Pontc.Name = "lb_Pontc";
            this.lb_Pontc.Size = new System.Drawing.Size(58, 25);
            this.lb_Pontc.TabIndex = 3;
            this.lb_Pontc.Text = "Pont:";
            // 
            // iskola
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 553);
            this.Controls.Add(this.lb_Pontc);
            this.Controls.Add(this.p_hatter);
            this.Controls.Add(this.lb_pont);
            this.Controls.Add(this.pictureBox1);
            this.Name = "iskola";
            this.Text = "Iskola";
            this.Load += new System.EventHandler(this.iskola_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lb_pont;
        private System.Windows.Forms.Panel p_hatter;
        private System.Windows.Forms.Label lb_Pontc;
    }
}

