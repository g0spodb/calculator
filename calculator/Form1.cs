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
        double effective_rate;//эффективная ставка

        private void button1_Click(object sender, EventArgs e)
        {
            double loan_summa = Convert.ToInt32(textBox1.Text); //Сумма займа
            double loan_srok = Convert.ToInt32(textBox2.Text); //Срок займа
            int nakopitelno = 0;//накопительно
            using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
            {
                sw.WriteLine();
            }
            for (int i=1;i<=loan_srok;i++)
            {
            if (i <=5)
            {
                    effective_rate += 0.009;//эффективная ставка
                    nakopitelno += 90; //накопительно
                    using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                    {
                        sw.WriteLine("День" + i + " |  Ставка = " + effective_rate * 100 + "%" + "|    %(накопительно) = " + nakopitelno + "Р" +  "|     Сумма выплаты = " + (loan_summa + nakopitelno) + "Р");
                    }
                    
            }
            if (i >5 & i<= 10)
            {
                    effective_rate += 0.007;
                    nakopitelno += 70;
                    using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                    {
                        sw.WriteLine("День" + i + " |  Ставка = " + effective_rate * 100 + "%" + "|    %(накопительно) = " + nakopitelno + "Р" + "|     Сумма выплаты = " + (loan_summa + nakopitelno) + "Р");
                    }

                }
            if (i > 10)
            {
                    effective_rate += 0.006;
                    nakopitelno += 60;
                    using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                    {
                        sw.WriteLine("День" + i + "|  Ставка = " + effective_rate * 100 + "%" + "|    %(накопительно) = " + nakopitelno + "Р"  + "|     Сумма выплаты = " + (loan_summa + nakopitelno) + "Р");
                    }

                }
            
            }
            effective_rate /= loan_srok;
            double procent_amount = loan_summa * effective_rate * loan_srok;//Сумма процентов
            double total_payout = procent_amount + loan_summa;//общая сумма выплаты
            if (total_payout > loan_summa * 2.5) MessageBox.Show("размер выплаты по микрозайму не может превышать 2, 5 - кратного размера суммы займа");
            MessageBox.Show("Общая сумма выплаты " + Convert.ToString(total_payout) + " \n Сумма процентов " + procent_amount + " \n Эффективная ставка " + effective_rate*100 + "%");
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
