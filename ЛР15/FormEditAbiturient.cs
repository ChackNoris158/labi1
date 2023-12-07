using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ЛР15
{
    public partial class FormEditAbiturient : Form
    {
        Абитуриенты item;
        public FormEditAbiturient(Абитуриенты itm)
        {
            item = itm;
            InitializeComponent();
            label7.Visible = false;
            textBox1.Text = item.Код_абитуриента.ToString();
            textBox2.Text = item.Фамилия.ToString();
            textBox3.Text = item.Имя.ToString();
            textBox4.Text = item.Отчество.ToString();
            textBox5.Text = item.Статус.ToString();
            textBox6.Text = item.Город.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "")
            {
                label7.Visible = true;
                label7.Text = "Заполните поля \"Фамилия\', \'Имя\" и \"Отчество\'";
            }
            else if (textBox2.Text.ToCharArray().All(w => ((w >= 'a' && w <= 'я') || (w >= 'A' && w <= 'Я') || w == ' ')) == false)
            {
                label7.Visible = true;
                label7.Text = "Поле 'ФИО' может содержать только кириллицу и пробелы";
            }
            else
            {
                try
                {
              
                var result = ((Form1)Owner).db.Абитуриенты.SingleOrDefault(w => w.Код_абитуриента == item.Код_абитуриента);
                result.Фамилия = textBox2.Text.ToString();
                result.Имя = textBox3.Text.ToString();
                result.Отчество = textBox4.Text.ToString();
                result.Статус = textBox5.Text.ToString(); result.Город = textBox6.Text.ToString();
                ((Form1)Owner).db.SaveChanges();
                ((Form1)Owner).sheetabiturients = ((Form1)Owner).db.Абитуриенты.OrderBy(о => о.Код_абитуриента).ToList();
                ((Form1)Owner).dataGridView1.DataSource =
                ((Form1)Owner).sheetabiturients;
                this.Close();
                }
                catch
                {



                }


            }
        }

        private void FormEditAbiturient_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
