namespace TimeTable
{
    partial class midform
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
            this.mfLabel = new System.Windows.Forms.Label();
            this.utkMentesRadio = new System.Windows.Forms.RadioButton();
            this.osszesRadio = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mfLabel
            // 
            this.mfLabel.AutoSize = true;
            this.mfLabel.Font = new System.Drawing.Font("Century Gothic", 11.89565F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.mfLabel.ForeColor = System.Drawing.Color.White;
            this.mfLabel.Location = new System.Drawing.Point(28, 57);
            this.mfLabel.Name = "mfLabel";
            this.mfLabel.Size = new System.Drawing.Size(98, 23);
            this.mfLabel.TabIndex = 0;
            this.mfLabel.Text = "variaciok";
            // 
            // utkMentesRadio
            // 
            this.utkMentesRadio.AutoSize = true;
            this.utkMentesRadio.Font = new System.Drawing.Font("Century Gothic", 11.89565F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.utkMentesRadio.ForeColor = System.Drawing.Color.White;
            this.utkMentesRadio.Location = new System.Drawing.Point(31, 172);
            this.utkMentesRadio.Name = "utkMentesRadio";
            this.utkMentesRadio.Size = new System.Drawing.Size(650, 27);
            this.utkMentesRadio.TabIndex = 1;
            this.utkMentesRadio.TabStop = true;
            this.utkMentesRadio.Text = "Csak azokat a verziókat szeretném látni, amelyekben nincs ütközés";
            this.utkMentesRadio.UseVisualStyleBackColor = true;
            // 
            // osszesRadio
            // 
            this.osszesRadio.AutoSize = true;
            this.osszesRadio.Font = new System.Drawing.Font("Century Gothic", 11.89565F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.osszesRadio.ForeColor = System.Drawing.Color.White;
            this.osszesRadio.Location = new System.Drawing.Point(31, 134);
            this.osszesRadio.Name = "osszesRadio";
            this.osszesRadio.Size = new System.Drawing.Size(300, 27);
            this.osszesRadio.TabIndex = 2;
            this.osszesRadio.TabStop = true;
            this.osszesRadio.Text = "Minden verziót szeretnék látni";
            this.osszesRadio.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 11.89565F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(603, 233);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 52);
            this.button1.TabIndex = 3;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // midform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(67)))), ((int)(((byte)(85)))));
            this.ClientSize = new System.Drawing.Size(790, 340);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.osszesRadio);
            this.Controls.Add(this.utkMentesRadio);
            this.Controls.Add(this.mfLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "midform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "midform";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label mfLabel;
        private System.Windows.Forms.RadioButton utkMentesRadio;
        private System.Windows.Forms.RadioButton osszesRadio;
        private System.Windows.Forms.Button button1;
    }
}