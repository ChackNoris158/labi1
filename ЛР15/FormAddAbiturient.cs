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
    public partial class FormAddAbiturient : Form
    { Абитуриенты result = new Абитуриенты();
      
        public FormAddAbiturient()
        {
            InitializeComponent();
            label7.Visible = false;
        }
        private void FormAddAbiturient_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {        
            if (textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "")
            {
                label7.Visible = true;
                label7.Text = "Заполните поля\'Фамилия\',\'Имя\',\'Отчество\' и \'Статус\'";
            }
            else if (textBox2.Text.ToCharArray().All(w => ((w >= 'a' && w <= 'я') || (w >= 'A' && w <= 'Я') || w == ' ')) == false)
            {
                label7.Visible = true;
                label7.Text = "Поля 'ФИО' может содержать только кириллицу и пробелы";
            }
            else
            {
                label7.Visible = true;
                label7.Text = "Добавлено успешно";
                result.Фамилия = textBox2.Text;
                result.Имя = textBox3.Text;
                result.Отчество = textBox4.Text;
                result.Статус = textBox5.Text;
                result.Город = textBox6.Text;
                ((Form1)Owner).db.Абитуриенты.Add(result);
                ((Form1)Owner).db.SaveChanges();
                ((Form1)Owner).sheetabiturients = ((Form1)Owner).db.Абитуриенты.OrderBy(о => о.Код_абитуриента).ToList();
                ((Form1)Owner).dataGridView1.DataSource = ((Form1)Owner).sheetabiturients;
                this.Close();
            }
        }
    }
}
