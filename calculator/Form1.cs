using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{
    public partial class Form1 : Form
    {
        double effective_rate = 0.68;

        private void button1_Click(object sender, EventArgs e)
        {
            double loan_amount = Convert.ToInt32(textBox1.Text); //Сумма займа
            double loan_term = Convert.ToInt32(textBox2.Text); //Срок займа
            double total_payout = loan_amount + loan_amount * 0.0068*25;
            textBox1.Text = Convert.ToString(total_payout);
        }

        public Form1()
        {
            InitializeComponent();
        }
    }
}
