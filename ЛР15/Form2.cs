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
    public partial class Form2 : Form
    {
        public List<view> viewzayav = new List<view>();
        public Ip521_SegaAndGeraEntities db;
        public List<Заявления> sheetabiturients;

        public Form2()
        {
            InitializeComponent();
            db = new Ip521_SegaAndGeraEntities();
            sheetabiturients = db.Заявления.OrderBy(o => o.Код_заявления).ToList();
            dataGridView1.DataSource = sheetabiturients;
            dataGridView1.ReadOnly = true;
            if (dataGridView1.RowCount == 0) label1.Visible = true;
            else label1.Visible = false;

            viewzayav = db.Абитуриенты.
                Join(db.Заявления, а => а.Код_абитуриента, з => з.Код_абитуриента, (а, з) => new { а, з })
.Join(db.Специальности, зс => зс.з.Код_специальности, с => с.Код_специальности, (зс, с) =>
new { зс, с })
.AsEnumerable()
.Select(x => new view(
x.зс.з.Код_заявления,
x.зс.а.Фамилия,
x.с.Название,
x.зс.з.Статус))
.OrderBy(o => o.Код_заявления).ToList();

            dataGridView1.DataSource = viewzayav.ToList();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.Count == 1)
            {
                FormAddZayav addAbit = new FormAddZayav();
                addAbit.Owner = this; addAbit.Show();
            }
            else Application.OpenForms[2].Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count == 1)
            {
                if (Application.OpenForms.Count == 1)
                {
                    view item = viewzayav
                        .First(w => w.Код_заявления.ToString() == dataGridView1
                        .SelectedCells[0].OwningRow.Cells[0].Value.ToString());
                    FormEditZayav edZayav = new FormEditZayav(item);
                    edZayav.Owner = this;
                    edZayav.Show();
                }
                else Application.OpenForms[2].Focus();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //dataGridView1.Columns[5].Visible = false;
            //dataGridView1.Columns[6].Visible = false;
            //dataGridView1.Columns[4].Visible = false;
            //dataGridView1.Columns[7].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    public class view
    {

        public view(int id, string ab, string sp, string s)
        {
            this.Код_заявления = id;
            this.Фамилия = ab;
            this.Название = sp;
            this.Статус = s;

        }
        public int Код_заявления { get; set; }
        public string Фамилия { get; set; }
        public string Название { get; set; }
        public string Статус { get; set; }
    }
}
