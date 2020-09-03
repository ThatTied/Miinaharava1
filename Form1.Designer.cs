namespace WindowsFormsMiinaharava
{
    partial class Miinaharava
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Miinaharava));
            this.helpponappi = new System.Windows.Forms.Button();
            this.keskivaikeanappi = new System.Windows.Forms.Button();
            this.vaikeanappi = new System.Windows.Forms.Button();
            this.vaikeustasotext = new System.Windows.Forms.Label();
            this.miinaTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // helpponappi
            // 
            this.helpponappi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.helpponappi.Location = new System.Drawing.Point(116, 57);
            this.helpponappi.Name = "helpponappi";
            this.helpponappi.Size = new System.Drawing.Size(75, 23);
            this.helpponappi.TabIndex = 0;
            this.helpponappi.Text = "9x9 Ruudut";
            this.helpponappi.UseVisualStyleBackColor = false;
            this.helpponappi.Click += new System.EventHandler(this.Helpponappi_Click);
            // 
            // keskivaikeanappi
            // 
            this.keskivaikeanappi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.keskivaikeanappi.Location = new System.Drawing.Point(116, 86);
            this.keskivaikeanappi.Name = "keskivaikeanappi";
            this.keskivaikeanappi.Size = new System.Drawing.Size(75, 23);
            this.keskivaikeanappi.TabIndex = 1;
            this.keskivaikeanappi.Text = "16x16";
            this.keskivaikeanappi.UseVisualStyleBackColor = false;
            this.keskivaikeanappi.Click += new System.EventHandler(this.Keskivaikeanappi_Click);
            // 
            // vaikeanappi
            // 
            this.vaikeanappi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.vaikeanappi.Location = new System.Drawing.Point(116, 116);
            this.vaikeanappi.Name = "vaikeanappi";
            this.vaikeanappi.Size = new System.Drawing.Size(75, 23);
            this.vaikeanappi.TabIndex = 2;
            this.vaikeanappi.Text = "30x16";
            this.vaikeanappi.UseVisualStyleBackColor = false;
            this.vaikeanappi.Click += new System.EventHandler(this.Vaikeanappi_Click);
            // 
            // vaikeustasotext
            // 
            this.vaikeustasotext.AutoSize = true;
            this.vaikeustasotext.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vaikeustasotext.Location = new System.Drawing.Point(92, 23);
            this.vaikeustasotext.Name = "vaikeustasotext";
            this.vaikeustasotext.Size = new System.Drawing.Size(111, 20);
            this.vaikeustasotext.TabIndex = 3;
            this.vaikeustasotext.Text = "Vaikeustaso";
            // 
            // miinaTextBox
            // 
            this.miinaTextBox.Location = new System.Drawing.Point(10, 10);
            this.miinaTextBox.Name = "miinaTextBox";
            this.miinaTextBox.ReadOnly = true;
            this.miinaTextBox.Size = new System.Drawing.Size(40, 22);
            this.miinaTextBox.TabIndex = 4;
            this.miinaTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Miinaharava
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(323, 173);
            this.Controls.Add(this.miinaTextBox);
            this.Controls.Add(this.vaikeustasotext);
            this.Controls.Add(this.vaikeanappi);
            this.Controls.Add(this.keskivaikeanappi);
            this.Controls.Add(this.helpponappi);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Miinaharava";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button helpponappi;
        private System.Windows.Forms.Button keskivaikeanappi;
        private System.Windows.Forms.Button vaikeanappi;
        private System.Windows.Forms.Label vaikeustasotext;
        private System.Windows.Forms.TextBox miinaTextBox;
    }
}

