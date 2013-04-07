namespace SmartTextBox
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.userControlTextBox3 = new DataLift.userControlTextBox();
            this.userControlTextBox2 = new DataLift.userControlTextBox();
            this.userControlTextBox1 = new DataLift.userControlTextBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 72);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 3;
            // 
            // userControlTextBox3
            // 
            this.userControlTextBox3.BorderColor = System.Drawing.Color.LightGray;
            this.userControlTextBox3.BorderSize = 1;
            this.userControlTextBox3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.userControlTextBox3.DisplayFocusBorder = true;
            this.userControlTextBox3.FocusBorderColor = System.Drawing.Color.Blue;
            this.userControlTextBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userControlTextBox3.Location = new System.Drawing.Point(13, 43);
            this.userControlTextBox3.Margin = new System.Windows.Forms.Padding(4);
            this.userControlTextBox3.MaxLength = 1;
            this.userControlTextBox3.Name = "userControlTextBox3";
            this.userControlTextBox3.Size = new System.Drawing.Size(39, 22);
            this.userControlTextBox3.TabIndex = 2;
            this.userControlTextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.userControlTextBox3.ValidationCustomChars = "1234567";
            this.userControlTextBox3.ValidationType = DataLift.ValidationType.CustomChars;
            this.userControlTextBox3.WordSpill = false;
            // 
            // userControlTextBox2
            // 
            this.userControlTextBox2.BorderColor = System.Drawing.Color.LightGray;
            this.userControlTextBox2.BorderSize = 1;
            this.userControlTextBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.userControlTextBox2.DisplayFocusBorder = true;
            this.userControlTextBox2.FocusBorderColor = System.Drawing.Color.Blue;
            this.userControlTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userControlTextBox2.Location = new System.Drawing.Point(171, 13);
            this.userControlTextBox2.Margin = new System.Windows.Forms.Padding(4);
            this.userControlTextBox2.MaxLength = 32767;
            this.userControlTextBox2.Name = "userControlTextBox2";
            this.userControlTextBox2.Size = new System.Drawing.Size(100, 22);
            this.userControlTextBox2.TabIndex = 1;
            this.userControlTextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.userControlTextBox2.ValidationCustomChars = "";
            this.userControlTextBox2.ValidationType = DataLift.ValidationType.AlphaNumericOnly;
            this.userControlTextBox2.WordSpill = false;
            // 
            // userControlTextBox1
            // 
            this.userControlTextBox1.BorderColor = System.Drawing.Color.LightGray;
            this.userControlTextBox1.BorderSize = 1;
            this.userControlTextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.userControlTextBox1.DisplayFocusBorder = true;
            this.userControlTextBox1.FocusBorderColor = System.Drawing.Color.Blue;
            this.userControlTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userControlTextBox1.Location = new System.Drawing.Point(13, 13);
            this.userControlTextBox1.Margin = new System.Windows.Forms.Padding(4);
            this.userControlTextBox1.MaxLength = 10;
            this.userControlTextBox1.Name = "userControlTextBox1";
            this.userControlTextBox1.Size = new System.Drawing.Size(150, 22);
            this.userControlTextBox1.TabIndex = 0;
            this.userControlTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.userControlTextBox1.ValidationCustomChars = "";
            this.userControlTextBox1.ValidationType = DataLift.ValidationType.AlphaNumericOnly;
            this.userControlTextBox1.WordSpill = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.userControlTextBox3);
            this.Controls.Add(this.userControlTextBox2);
            this.Controls.Add(this.userControlTextBox1);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataLift.userControlTextBox userControlTextBox1;
        private DataLift.userControlTextBox userControlTextBox2;
        private DataLift.userControlTextBox userControlTextBox3;
        private System.Windows.Forms.TextBox textBox1;
    }
}

