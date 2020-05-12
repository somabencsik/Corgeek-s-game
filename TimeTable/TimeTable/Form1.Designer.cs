namespace TimeTable
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.OpenFileButton = new System.Windows.Forms.Button();
            this.listBoxLeft = new System.Windows.Forms.ListBox();
            this.listBoxRight = new System.Windows.Forms.ListBox();
            this.sendItemToRightBtn = new System.Windows.Forms.Button();
            this.sendItemToLeftBtn = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.targyakKivalasztBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.ScriptBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // OpenFileButton
            // 
            this.OpenFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenFileButton.Font = new System.Drawing.Font("Century Gothic", 10.01739F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.OpenFileButton.ForeColor = System.Drawing.Color.White;
            this.OpenFileButton.Location = new System.Drawing.Point(46, 235);
            this.OpenFileButton.Name = "OpenFileButton";
            this.OpenFileButton.Size = new System.Drawing.Size(144, 30);
            this.OpenFileButton.TabIndex = 0;
            this.OpenFileButton.Text = "File kiválasztása";
            this.OpenFileButton.UseVisualStyleBackColor = true;
            this.OpenFileButton.Click += new System.EventHandler(this.OpenFileButton_Click);
            // 
            // listBoxLeft
            // 
            this.listBoxLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(20)))), ((int)(((byte)(35)))));
            this.listBoxLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxLeft.Font = new System.Drawing.Font("Century Gothic", 11.26957F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listBoxLeft.ForeColor = System.Drawing.Color.White;
            this.listBoxLeft.FormattingEnabled = true;
            this.listBoxLeft.HorizontalScrollbar = true;
            this.listBoxLeft.ItemHeight = 22;
            this.listBoxLeft.Location = new System.Drawing.Point(46, 369);
            this.listBoxLeft.Name = "listBoxLeft";
            this.listBoxLeft.Size = new System.Drawing.Size(441, 222);
            this.listBoxLeft.TabIndex = 1;
            // 
            // listBoxRight
            // 
            this.listBoxRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(20)))), ((int)(((byte)(35)))));
            this.listBoxRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxRight.Font = new System.Drawing.Font("Century Gothic", 11.26957F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listBoxRight.ForeColor = System.Drawing.Color.White;
            this.listBoxRight.FormattingEnabled = true;
            this.listBoxRight.HorizontalScrollbar = true;
            this.listBoxRight.ItemHeight = 22;
            this.listBoxRight.Location = new System.Drawing.Point(596, 369);
            this.listBoxRight.Name = "listBoxRight";
            this.listBoxRight.Size = new System.Drawing.Size(441, 222);
            this.listBoxRight.TabIndex = 2;
            // 
            // sendItemToRightBtn
            // 
            this.sendItemToRightBtn.FlatAppearance.BorderSize = 0;
            this.sendItemToRightBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sendItemToRightBtn.Font = new System.Drawing.Font("Webdings", 36.31305F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.sendItemToRightBtn.ForeColor = System.Drawing.Color.White;
            this.sendItemToRightBtn.Location = new System.Drawing.Point(509, 409);
            this.sendItemToRightBtn.Margin = new System.Windows.Forms.Padding(0);
            this.sendItemToRightBtn.Name = "sendItemToRightBtn";
            this.sendItemToRightBtn.Size = new System.Drawing.Size(75, 63);
            this.sendItemToRightBtn.TabIndex = 3;
            this.sendItemToRightBtn.Text = "8";
            this.sendItemToRightBtn.UseVisualStyleBackColor = true;
            this.sendItemToRightBtn.Click += new System.EventHandler(this.sendItemToRightBtn_Click);
            // 
            // sendItemToLeftBtn
            // 
            this.sendItemToLeftBtn.FlatAppearance.BorderSize = 0;
            this.sendItemToLeftBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sendItemToLeftBtn.Font = new System.Drawing.Font("Webdings", 36.31305F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.sendItemToLeftBtn.ForeColor = System.Drawing.Color.White;
            this.sendItemToLeftBtn.Location = new System.Drawing.Point(509, 472);
            this.sendItemToLeftBtn.Margin = new System.Windows.Forms.Padding(0);
            this.sendItemToLeftBtn.Name = "sendItemToLeftBtn";
            this.sendItemToLeftBtn.Size = new System.Drawing.Size(75, 63);
            this.sendItemToLeftBtn.TabIndex = 4;
            this.sendItemToLeftBtn.Text = "7";
            this.sendItemToLeftBtn.UseVisualStyleBackColor = true;
            this.sendItemToLeftBtn.Click += new System.EventHandler(this.sendItemToLeftBtn_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // targyakKivalasztBtn
            // 
            this.targyakKivalasztBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.targyakKivalasztBtn.Font = new System.Drawing.Font("Century Gothic", 10.01739F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.targyakKivalasztBtn.ForeColor = System.Drawing.Color.White;
            this.targyakKivalasztBtn.Location = new System.Drawing.Point(921, 605);
            this.targyakKivalasztBtn.Name = "targyakKivalasztBtn";
            this.targyakKivalasztBtn.Size = new System.Drawing.Size(116, 68);
            this.targyakKivalasztBtn.TabIndex = 14;
            this.targyakKivalasztBtn.Text = "Tárgyak kiválasztása";
            this.targyakKivalasztBtn.UseVisualStyleBackColor = true;
            this.targyakKivalasztBtn.Click += new System.EventHandler(this.targyakKivalasztBtn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 11.26957F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(42, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(627, 22);
            this.label5.TabIndex = 15;
            this.label5.Text = "2. Válaszd ki a mintatanterv tárgyait tartalmazó file-t! (AllCourse.txt)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 11.26957F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(42, 295);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(618, 44);
            this.label6.TabIndex = 16;
            this.label6.Text = "3. Válaszd ki, hogy melyik tárgyakat szeretnéd az órarendbe tenni!\r\nA ctrl lenyom" +
    "va tartásával tudsz egyszerre több sort is kiválasztani.";
            // 
            // button1
            // 
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Webdings", 36.31305F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(937, 12);
            this.button1.Name = "button1";
            this.button1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button1.Size = new System.Drawing.Size(100, 86);
            this.button1.TabIndex = 34;
            this.button1.Text = "r";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.26957F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(42, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(847, 66);
            this.label1.TabIndex = 35;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // ScriptBtn
            // 
            this.ScriptBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ScriptBtn.Font = new System.Drawing.Font("Century Gothic", 10.01739F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ScriptBtn.ForeColor = System.Drawing.Color.White;
            this.ScriptBtn.Location = new System.Drawing.Point(46, 123);
            this.ScriptBtn.Name = "ScriptBtn";
            this.ScriptBtn.Size = new System.Drawing.Size(144, 30);
            this.ScriptBtn.TabIndex = 36;
            this.ScriptBtn.Text = "Script indítása";
            this.ScriptBtn.UseVisualStyleBackColor = true;
            this.ScriptBtn.Click += new System.EventHandler(this.ScriptBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(67)))), ((int)(((byte)(85)))));
            this.ClientSize = new System.Drawing.Size(1077, 695);
            this.Controls.Add(this.ScriptBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.targyakKivalasztBtn);
            this.Controls.Add(this.sendItemToLeftBtn);
            this.Controls.Add(this.sendItemToRightBtn);
            this.Controls.Add(this.listBoxRight);
            this.Controls.Add(this.listBoxLeft);
            this.Controls.Add(this.OpenFileButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Form1";
            this.Text = "Órarendgeneráló";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OpenFileButton;
        private System.Windows.Forms.ListBox listBoxLeft;
        private System.Windows.Forms.ListBox listBoxRight;
        private System.Windows.Forms.Button sendItemToRightBtn;
        private System.Windows.Forms.Button sendItemToLeftBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button targyakKivalasztBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ScriptBtn;
    }
}

