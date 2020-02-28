using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calc_Windows
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBoxOperator.SelectedIndex = 0;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            double a, b;
            if (!double.TryParse(inputData1.Text, out a) || !double.TryParse(inputData2.Text, out b))
            {
                result.Text = "Invalid Input.";
                return;
            }
            switch (comboBoxOperator.Text)
            {
                case "+":
                    result.Text = $"{a + b}";
                    break;
                case "-":
                    result.Text = $"{a - b}";
                    break;
                case "*":
                    result.Text = $"{a * b}";
                    break;
                case "/":
                    if ( b == 0 )
                    {
                        result.Text = "Invalid Input.";
                        break;
                    }
                    result.Text = $"{a / b}";
                    break;
            }
        }
    }
}
