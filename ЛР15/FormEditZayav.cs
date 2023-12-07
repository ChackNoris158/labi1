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
    public partial class FormEditZayav : Form
    {
        view item;
        public FormEditZayav(view itm)
        {
            InitializeComponent();
            item = itm;
            textBox1.Text = item.Код_заявления.ToString();
            textBox2.Text = item.Фамилия.ToString();
            textBox3.Text = item.Название.ToString();
            textBox4.Text = item.Статус.ToString();
        }
        private void FormEditZayav_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox4.Text.Trim() == "")
            {
                label7.Visible = true;
                label7.Text = "Заполните поле \'Диагноз\'";
            }else
            {
                var result = ((Form2)Owner).db.Заявления.SingleOrDefault(w =>w.Код_заявления == item.Код_заявления);
                result.Статус = textBox4.Text.ToString(); ((Form2)Owner).db.SaveChanges(); ((Form2)Owner).viewzayav =
                ((Form2)Owner).db.Абитуриенты.Join(((Form2)Owner).db.Заявления,
                a => a.Код_абитуриента, з => з.Код_абитуриента,
                (a, з) => new { a, з })
                .Join(((Form2)Owner).db.Специальности,
                зс => зс.з.Код_специальности, с => с.Код_специальности, (зс, с) => new { зс, с }).AsEnumerable()
.Select(x => new view(
x.зс.з.Код_заявления,
x.зс.a.Фамилия,
x.с.Название,
x.зс.з.Статус))
.OrderBy(о => о.Код_заявления).ToList(); ((Form2)Owner).dataGridView1.DataSource = ((Form2)Owner).viewzayav; ((Form2)Owner).dataGridView1.Refresh(); this.Close();


            }
        }
    }
}
