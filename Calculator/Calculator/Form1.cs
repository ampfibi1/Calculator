using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModernButton;

namespace Calculator
{
    public partial class Form1 : Form
    {

        //Field
        Double result = 0;
        string operation = string.Empty;
        string fstNum, secNum;
        bool enterValue = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void myModernButton17_Click(object sender, EventArgs e)
        {

        }

        private void BtnMathOperation_Click(object sender, EventArgs e)
        {
            if (result != 0) BtnEqual.PerformClick();
            else result = Double.Parse(TxtDisplay1.Text);

            MyModernButton button = (MyModernButton)sender;
            operation = button.Text;
            enterValue = true;
            if(TxtDisplay1.Text != "0")
            {
                TxtDisplay2.Text = fstNum = $"{result}{operation}";
                TxtDisplay1.Text = string.Empty;
            }
        }
        private void BtnEqual_Click(object sender, EventArgs e)
        {
            secNum = TxtDisplay1.Text;
            TxtDisplay2.Text = $"{TxtDisplay2.Text}{TxtDisplay1.Text}=";
            if (TxtDisplay1.Text != string.Empty)
            {
                if (TxtDisplay1.Text == "0") TxtDisplay2.Text = string.Empty;
                switch (operation)
                {
                    case "+":
                        TxtDisplay1.Text = (result + Double.Parse(TxtDisplay1.Text)).ToString();
                        RtBoxDisplayHistory.AppendText($"{fstNum}{secNum}={TxtDisplay1.Text}\n");
                        break;
                    case "-":
                        TxtDisplay1.Text = (result - Double.Parse(TxtDisplay1.Text)).ToString();
                        RtBoxDisplayHistory.AppendText($"{fstNum}{secNum}={TxtDisplay1.Text}\n");
                        break;
                    case "×":
                        TxtDisplay1.Text = (result * Double.Parse(TxtDisplay1.Text)).ToString();
                        RtBoxDisplayHistory.AppendText($"{fstNum}{secNum}={TxtDisplay1.Text}\n");
                        break;
                    case "÷":
                        TxtDisplay1.Text = (result / Double.Parse(TxtDisplay1.Text)).ToString();
                        RtBoxDisplayHistory.AppendText($"{fstNum}{secNum}={TxtDisplay1.Text}\n");
                        break;
                    default:TxtDisplay2.Text = $"{TxtDisplay1.Text}=";
                        break;
                }
                result = Double.Parse(TxtDisplay1.Text);
                operation = string.Empty;
            }
        }
        private void BtnHistory_Click(object sender, EventArgs e)
        {
            PnlHistory.Height = (PnlHistory.Height == 5) ? 345 : 5;
        }
        private void BtnClearHistory_Click(object sender, EventArgs e)
        {
            RtBoxDisplayHistory.Clear();
            if (RtBoxDisplayHistory.Text == string.Empty)
                RtBoxDisplayHistory.Text = "there's no history yet";
        }
        private void btnBackSpace_Click(object sender, EventArgs e)
        {
            if (TxtDisplay1.Text.Length > 0)
                TxtDisplay1.Text = TxtDisplay1.Text.Remove(TxtDisplay1.Text.Length-1,1);
            if (TxtDisplay1.Text == string.Empty)
                TxtDisplay1.Text = "0";
        }
        private void BtnC_Click(object sender, EventArgs e)
        {
            TxtDisplay1.Text = "0";
            TxtDisplay2.Text = string.Empty;
            result = 0;
        }

        private void BtnOperations_Click(object sender, EventArgs e)
        {
            MyModernButton button = (MyModernButton)sender;
            operation = button.Text;
            switch (operation)
            {
                case "√x":
                    TxtDisplay2.Text = $"√({TxtDisplay1.Text})";
                    TxtDisplay1.Text = Convert.ToString(Math.Sqrt(Double.Parse(TxtDisplay1.Text)));
                    break;
                case "^2":
                    TxtDisplay2.Text = $"{TxtDisplay1.Text}^2";
                    TxtDisplay1.Text = Convert.ToString(Convert.ToDouble(TxtDisplay1.Text)* Convert.ToDouble(TxtDisplay1.Text));
                    break;
                case "1/x":
                    TxtDisplay2.Text = $"1/{TxtDisplay1.Text}";
                    TxtDisplay1.Text = Convert.ToString(1.0/Convert.ToDouble(TxtDisplay1.Text));
                    break;
                case "%":
                    TxtDisplay2.Text = $"%({TxtDisplay1.Text})";
                    TxtDisplay1.Text = Convert.ToString(Convert.ToDouble(TxtDisplay1.Text)/100.00);
                    break;
                case "±":
                    TxtDisplay2.Text = $"±({TxtDisplay1.Text})";
                    TxtDisplay1.Text = Convert.ToString(-1.0*Convert.ToDouble(TxtDisplay1.Text));
                    break;
            }
            RtBoxDisplayHistory.AppendText($"{TxtDisplay2.Text}={TxtDisplay1.Text}\n");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnNum_Click(object sender, EventArgs e)
        {
            if (TxtDisplay1.Text == "0" || enterValue)
                TxtDisplay1.Text = string.Empty;
            enterValue = false;

            MyModernButton button = (MyModernButton)sender;
            if (button.Text == ".")
            {
                if (TxtDisplay1.Text.Contains("."))
                {
                    TxtDisplay1.Text += button.Text;
                }
            }
            else TxtDisplay1.Text += button.Text;
        }
    }
}
