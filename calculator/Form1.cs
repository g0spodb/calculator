using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
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
                        sw.WriteLine("День" + i + " |  Ставка = " + effective_rate * 100 + "%" + "|    %(накопительно) = " + cumulatively + "Р" +  "|     Сумма выплаты = " + (loan_amount + cumulatively) + "Р");
                    }
                    
            }
            if (i >5 & i<= 10)
            {
                    effective_rate += 0.007;
                    cumulatively += 70;
                    using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                    {
                        sw.WriteLine("День" + i + " |  Ставка = " + effective_rate * 100 + "%" + "|    %(накопительно) = " + cumulatively + "Р" + "|     Сумма выплаты = " + (loan_amount + cumulatively) + "Р");
                    }

                }
            if (i > 10)
            {
                    effective_rate += 0.006;
                    cumulatively += 60;
                    using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                    {
                        sw.WriteLine("День" + i + "|  Ставка = " + effective_rate * 100 + "%" + "|    %(накопительно) = " + cumulatively + "Р"  + "|     Сумма выплаты = " + (loan_amount + cumulatively) + "Р");
                    }

                }
            
            }
            effective_rate /= loan_term;
            double interest_amount = loan_amount * effective_rate * loan_term;
            double total_payout = interest_amount + loan_amount;
            if (total_payout > loan_amount * 2.5) MessageBox.Show("размер выплаты по микрозайму не может превышать 2, 5 - кратного размера суммы займа");
            MessageBox.Show("Общая сумма выплаты " + Convert.ToString(total_payout) + " \n Сумма процентов " + interest_amount + " \n Эффективная ставка " + effective_rate*100 + "%");
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int amount = Convert.ToInt32(textBox1.Text);
                if (amount > 500000) MessageBox.Show("предельный размер долговой нагрузки на одно физическое лицо не может превышать 500 тыс. руб.");
                
            }
            catch{ }
        }
    }
}
