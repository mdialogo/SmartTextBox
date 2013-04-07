using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace DataLift
{
    public enum ValidationType
    {
        None,
        NumericOnly,
        AlphaOnly,
        AlphaNumericOnly,
        AmountOnly,
        CustomChars
    }

    public partial class userControlTextBox : UserControl
    {
        private TextBox textBox;
        private Color borderColor = Color.LightGray;
        private Color origBordercolor;
        private int borderSize = 1;
        private Color focusBorderColor = Color.Blue;
        private bool displayFocusBorder = true;
        private int numErrors = 0;
        private ValidationType validationType = ValidationType.AlphaNumericOnly;
        private String validationCustChars = "";

        // constructor
        public userControlTextBox()
        {
            InitializeComponent();

            textBox = new TextBox();
            this.textBox.BorderStyle = BorderStyle.None;
            this.textBox.CharacterCasing = CharacterCasing.Upper;
            this.textBox.AutoSize = false;
            this.textBox.KeyPress += new KeyPressEventHandler(PerformDataValidation);
            this.textBox.KeyPress += new KeyPressEventHandler(textBox_KeyPress);

            this.Controls.Add(textBox);
            InvalidateSize();
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control currentControl = ((Control)sender).Parent;
            if (wordSpill && currentControl.Text.Length >= this.MaxLength)
            {
                string lastWord = currentControl.Text.Substring(currentControl.Text.LastIndexOf(" ") + 1);
                currentControl.Text = currentControl.Text.Substring(0, currentControl.Text.LastIndexOf(" ") + 1);
                Control nextControl = currentControl.Parent.GetNextControl(currentControl, true);
                nextControl.Text = lastWord + e.KeyChar;
                nextControl.Focus();
                SendKeys.SendWait("{RIGHT}");
                e.Handled = true;
            }
        }

        void PerformDataValidation(object sender, KeyPressEventArgs e)
        {
            switch (validationType)
            {
                case ValidationType.None:
                    break;
                case ValidationType.NumericOnly:
                    e.Handled = (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar));
                    break;
                case ValidationType.AlphaOnly:
                    e.Handled = (!Char.IsLetter(e.KeyChar));
                    break;
                case ValidationType.AlphaNumericOnly:
                    break;
                case ValidationType.CustomChars:
                    e.Handled = (!Char.IsControl(e.KeyChar) && !validationCustChars.ToUpper().Contains(e.KeyChar.ToString().ToUpper()));
                    break;
            }
            if (e.Handled)
                numErrors++;
            else
                numErrors = 0;

            if (numErrors >= 3)
                this.toolTip1.Show("Enter " + ValidationTypeExtension.ToString(validationType, validationCustChars), this.textBox);
            else
                this.toolTip1.Hide(this.textBox);
        }

        // properties
        public TextBox InnerTextBox
        {
            get { return textBox; }
        }
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                Invalidate();
            }
        }
        public int BorderSize
        {
            get { return borderSize; }
            set
            {
                borderSize = value;
                Invalidate();
            }
        }
        public override Color BackColor
        {
            get
            {
                return this.textBox.BackColor;
            }
            set
            {
                this.textBox.BackColor = value;
            }
        }
        public Color FocusBorderColor
        {
            get { return focusBorderColor; }
            set { focusBorderColor = value; }
        }
        public bool DisplayFocusBorder
        {
            get { return displayFocusBorder; }
            set { displayFocusBorder = value; }
        }
        public override string Text
        {
            get
            {
                return this.textBox.Text;
            }
            set
            {
                this.textBox.Text = value;
            }
        }
        public int MaxLength
        {
            get { return this.textBox.MaxLength; }
            set { this.textBox.MaxLength = value; }
        }
        public HorizontalAlignment TextAlign
        {
            get { return this.textBox.TextAlign; }
            set { this.textBox.TextAlign = value; }
        }
        public ValidationType ValidationType
        {
            get { return validationType; }
            set { validationType = value; }
        }
        public String ValidationCustomChars
        {
            get { return validationCustChars; }
            set { validationCustChars = value; }
        }
        public CharacterCasing CharacterCasing
        {
            get { return textBox.CharacterCasing; }
            set { textBox.CharacterCasing = value; }
        }
        private bool wordSpill = false;
        public bool WordSpill
        {
            get { return wordSpill; }
            set { wordSpill = value; }
        }

        // events
        private void userControlTextBox_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle
                , borderColor, borderSize, ButtonBorderStyle.Solid
                , borderColor, borderSize, ButtonBorderStyle.Solid
                , borderColor, borderSize, ButtonBorderStyle.Solid
                , borderColor, borderSize, ButtonBorderStyle.Solid);
        }
        private void userControlTextBox_Resize(object sender, EventArgs e)
        {
            InvalidateSize();
        }
        private void InvalidateSize()
        {
            textBox.Size = new Size(this.Width - 4, this.Height - 4);
            textBox.Location = new Point(2, 2);
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
                SendKeys.SendWait("{TAB}");
            else if (keyData == (Keys.Shift | Keys.Enter))
                SendKeys.SendWait("+{TAB}");
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public event KeyEventHandler TextBoxKeyUp
        {
            add
            {
                this.textBox.KeyUp += value;
            }
            remove
            {
                this.textBox.KeyUp -= value;
            }
        }
        public event KeyEventHandler TextBoxKeyDown
        {
            add
            {
                this.textBox.KeyDown += value;
            }
            remove
            {
                this.textBox.KeyDown -= value;
            }
        }
        public event KeyPressEventHandler TextBoxKeyPress
        {
            add
            {
                this.textBox.KeyPress += value;
            }
            remove
            {
                this.textBox.KeyPress -= value;
            }
        }

        protected override void OnEnter(EventArgs e)
        {
            this.textBox.SelectionStart = 0;
            this.textBox.SelectionLength = textBox.TextLength;

            if (DisplayFocusBorder)
            {
                //save orig color;
                origBordercolor = borderColor;
                borderSize = 2;
                borderColor = focusBorderColor;
                Invalidate();
            }
            base.OnEnter(e);
        }
        protected override void OnLeave(EventArgs e)
        {
            if (DisplayFocusBorder)
            {
                borderSize = 1;
                borderColor = origBordercolor;
                Invalidate();
            }
            this.toolTip1.Hide(this.textBox);
            base.OnLeave(e);
        }
    }

    public static class ValidationTypeExtension
    {
        public static string ToString(ValidationType validationType, string customChars)
        {
            string result = "";
            switch (validationType)
            {
                case ValidationType.None:
                    result = "None";
                    break;
                case ValidationType.NumericOnly:
                    result = "Numeric Only";
                    break;
                case ValidationType.AlphaOnly:
                    result = "Alpha Only";
                    break;
                case ValidationType.AlphaNumericOnly:
                    result = "Alpha-numeric Only";
                    break;
                case ValidationType.AmountOnly:
                    result = "Amout Only";
                    break;
                case ValidationType.CustomChars:
                    foreach (char c in customChars)
                        result += (customChars.EndsWith(c.ToString()) ? "or " + c.ToString() : c.ToString() + ", ");
                    result += " Only";
                    break;
            }
            return result;
        }
    }
}
