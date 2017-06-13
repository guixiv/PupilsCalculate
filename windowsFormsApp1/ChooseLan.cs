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
    public partial class ChooseLanguage : Form
    {
        public ChooseLanguage()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_Click(object sender, EventArgs e)
        {

            
        }

        private void ChooseLanguage_Load(object sender, EventArgs e)
        {

        }

        private void botton1_Click(object sender, EventArgs e)
        {
            Calculate ca1 = new Calculate();
            ca1.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
            Calculate ca2 = new Calculate();
            ca2.Show();
            this.Close();
        }
    }
}
