using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{
    public partial class Form1 : Form
    {
        string writePath = @"hta.txt";
        double effective_rate;

        private void button1_Click(object sender, EventArgs e)
        {
            double loan_amount = Convert.ToInt32(textBox1.Text); //Сумма займа
            double loan_term = Convert.ToInt32(textBox2.Text); //Срок займа
            int cumulatively = 0;
            using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
            {
                sw.WriteLine();
            }
            for (int i=1;i<=loan_term;i++)
            {
            if (i <=5)
            {
                    effective_rate += 0.009;//эффективная ставка
                    cumulatively += 90; //накопительно
                    using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                    {
                        sw.WriteLine("День" + i + " |  Ставка = " + effective_rate * 100 + "%" + "|    %(накопительно) = " + cumulatively + "|     Сумма выплаты = " + (loan_amount + cumulatively));
                    }
                    
            }
            if (i >5 & i<= 10)
            {
                    effective_rate += 0.007;
                    cumulatively += 70;
                    using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                    {
                        sw.WriteLine("День" + i + " |  Ставка = " + effective_rate * 100 + "%" + "|    %(накопительно) = " + cumulatively + "|     Сумма выплаты = " + (loan_amount + cumulatively));
                    }

                }
            if (i > 10)
            {
                    effective_rate += 0.006;
                    cumulatively += 60;
                    using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                    {
                        sw.WriteLine("День" + i + "|  Ставка = " + effective_rate * 100 + "%" + "|    %(накопительно) = " + cumulatively + "|     Сумма выплаты = " + (loan_amount + cumulatively));
                    }

                }
            
            }
            effective_rate /= loan_term;
            double interest_amount = loan_amount * effective_rate * loan_term;
            double total_payout = interest_amount + loan_amount;
            MessageBox.Show("Общая сумма выплаты " + Convert.ToString(total_payout) + " \n Сумма процентов " + interest_amount + " \n Эффективная ставка " + effective_rate*100 + "%");
        }
        public Form1()
        {
            InitializeComponent();
        }
    }
}
