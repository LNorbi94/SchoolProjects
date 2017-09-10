namespace Horgaszverseny
{
    partial class horgaszverseny
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
            this.feltolt = new System.Windows.Forms.Button();
            this.legtobb = new System.Windows.Forms.Button();
            this.atlag = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // be
            // 
            this.be.FormattingEnabled = true;
            this.be.Location = new System.Drawing.Point(25, 22);
            this.be.Name = "be";
            this.be.Size = new System.Drawing.Size(379, 459);
            this.be.TabIndex = 0;
            // 
            // feltolt
            // 
            this.feltolt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.feltolt.Location = new System.Drawing.Point(535, 177);
            this.feltolt.Name = "feltolt";
            this.feltolt.Size = new System.Drawing.Size(170, 35);
            this.feltolt.TabIndex = 1;
            this.feltolt.Text = "Feltöltés és Kiírás";
            this.feltolt.UseVisualStyleBackColor = true;
            this.feltolt.Click += new System.EventHandler(this.feltolt_Click);
            // 
            // legtobb
            // 
            this.legtobb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.legtobb.Location = new System.Drawing.Point(535, 236);
            this.legtobb.Name = "legtobb";
            this.legtobb.Size = new System.Drawing.Size(170, 35);
            this.legtobb.TabIndex = 2;
            this.legtobb.Text = "Legtöbb hal (KG)";
            this.legtobb.UseVisualStyleBackColor = true;
            this.legtobb.Click += new System.EventHandler(this.legtobb_Click);
            // 
            // atlag
            // 
            this.atlag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.atlag.Location = new System.Drawing.Point(535, 293);
            this.atlag.Name = "atlag";
            this.atlag.Size = new System.Drawing.Size(170, 35);
            this.atlag.TabIndex = 3;
            this.atlag.Text = "Eltöltött idő átlaga";
            this.atlag.UseVisualStyleBackColor = true;
            this.atlag.Click += new System.EventHandler(this.atlag_Click);
            // 
            // horgaszverseny
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 512);
            this.Controls.Add(this.atlag);
            this.Controls.Add(this.legtobb);
            this.Controls.Add(this.feltolt);
            this.Controls.Add(this.be);
            this.Name = "horgaszverseny";
            this.Text = "Horgászverseny";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox be;
        private System.Windows.Forms.Button feltolt;
        private System.Windows.Forms.Button legtobb;
        private System.Windows.Forms.Button atlag;
    }
}

