using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Properties;

namespace WindowsFormsApp1
{
    public partial class Result : Form
    {
        public Result()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string num = null, num2 = null, num3 = null;
            int n3;
            num += Express.shownum();
            label4.Text = num;
            num2 += Calculate.rightnum();
            label6.Text = num2;
            n3 = Express.shownum() - Calculate.rightnum();
            num3 += n3;
            label5.Text = num3;


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
