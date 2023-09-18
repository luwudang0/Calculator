using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            CultureInfo ci = new CultureInfo("zh-CN");
            var timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(TimerTickHandler);
            timer.Start();
            this.txt.KeyDown += new KeyEventHandler(txt_KeyDown);
        }
        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnEqual_Click(sender, e);
            }
        }
        private void TimerTickHandler(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            string dayOfWeek = date.ToString("dddd");
            realTime.Text = date.ToString("F") + "  " + dayOfWeek;
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txt.Text += 1;
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            txt.Text += '+';
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            txt.Text += '-';
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            txt.Text += '*';
        }
        private void btnDivide_Click(object sender, EventArgs e)
        {
            txt.Text += '/';
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            txt.Text += '%';
        }
        private void btnSquare_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txt.Text, out int valInt))
            {
                txt.Text += $"*{valInt}";
            }
            else if (double.TryParse(txt.Text, out double valDouble))
            {
                txt.Text += $"*{valDouble}";
            }
            else
            {
                //好像这种方法是多余的，一般也就是int/double类型两种情况。
                MessageBox.Show($"{txt.Text}不能用于计算平方。");
            }
        }
        private void btnEqual_Click(object sender, EventArgs e)
        {
            txt.Text += '=';
            DataTable dt = new DataTable();
            var result = dt.Compute(txt.Text.Replace('=', ' '), "");
            // 将计算表达式写入【历史记录】中
            historyListBox.Items.Add(txt.Text + result);
            txt.Text = result.ToString();

            
        }

        private void btnDlelete_Click(object sender, EventArgs e)
        {
             txt.Text = txt.Text.Remove(txt.Text.Length - 1);   
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            txt.Text = null;
        }
        private void btn2_Click(object sender, EventArgs e)
        {
            txt.Text += 2;
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txt.Text += 3;
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txt.Text += 4;
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txt.Text += 5;
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txt.Text += 6;
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txt.Text += 7;
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txt.Text += 8;
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txt.Text += 9;
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            txt.Text += 0;
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            txt.Text += '.';
        }

        private void btnLeftBracket_Click(object sender, EventArgs e)
        {
            txt.Text += '(';
        }

        private void btnRightBracket_Click(object sender, EventArgs e)
        {
            txt.Text += ')';
        }

        private void btnSqrt_Click(object sender, EventArgs e)
        {
            //txt.Text += '';//todo
        }

        private void btnCopyResult_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txt.Text);
        }
    }
}
