using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Properties
{
    public partial class Calculate : Form
    {
        static int rightans = 0;
        string CorrctAns_ch = "答案正确！";
        string WrongAns_ch = "答案错误……" +
            "正确答案是";
        string CorrctAns_en = "You are right!";
        string WrongAns_en = "You are wrong..." +
            "Correct Answer is";

        public Calculate()
        {
            InitializeComponent();
        }

        public void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtName_Enter(object sender, EventArgs e)
        {
            Answer.ForeColor = Color.White;
            Answer.BackColor = Color.Blue;
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            Answer.BackColor = Color.White;
            Answer.ForeColor = Color.Black;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string userans = this.Answer.Text;
            double ans = Express.showans();
            string answer=null;
            answer += ans;
            if (userans.Equals(answer))
            {
                MessageBox.Show(CorrctAns_ch);
                rightans++;
            }
            else
            {
                string wrong = WrongAns_ch;
                wrong += ans;
                MessageBox.Show(wrong);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
           Answer.Text = "";
           Answer.Focus();
        }

        private void Calculate_Load(object sender, EventArgs e)
        {

        }

        static public int rightnum()
        {
            return rightans;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            express.Text = "";
            string ex = Express.show();
            express.Text = ex;
        }

        private void express_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Result re = new Result();
            re.Show();
            this.Close();
        }
    }
}
