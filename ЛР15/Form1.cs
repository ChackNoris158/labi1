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
    public partial class Form1 : Form
    {
        public List<Абитуриенты> sheetabiturients;
        public Ip521_SegaAndGeraEntities db;
        public Form1()
        {
            InitializeComponent();
            db = new Ip521_SegaAndGeraEntities();
            sheetabiturients = db.Абитуриенты.OrderBy(o => o.Код_абитуриента).ToList();
            dataGridView1.DataSource = sheetabiturients;
            dataGridView1.ReadOnly = true;
            if (dataGridView1.RowCount == 0) label1.Visible = true;
            else label1.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns[0].HeaderText = "№";
            dataGridView1.Columns[0].Width = 30;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "") 
            {
                switch (comboBox1.SelectedIndex) 
                {
                    case 0:
                        dataGridView1.DataSource =
                        sheetabiturients.Where(р => р.Код_абитуриента.ToString() == textBox1.Text.ToString()).ToList(); break;
                    case 1:
                        dataGridView1.DataSource =
                        sheetabiturients.Where(p => p.Фамилия.ToString().Contains(textBox1.Text.ToString())).ToList(); break;
                    case 2:
                        dataGridView1.DataSource =
                        sheetabiturients.Where(p => p.Имя.ToString().Contains(textBox1.Text.ToString())).ToList(); break;
                    case 3:
                        dataGridView1.DataSource =
                        sheetabiturients.Where(p => p.Отчество.ToString().Contains(textBox1.Text.ToString())).ToList(); break;
                    case 4:
                        dataGridView1.DataSource =
                        sheetabiturients.Where(p => p.Статус.ToString().Contains(textBox1.Text.ToString())).ToList(); break;
                    case 5:
                        dataGridView1.DataSource =
                        sheetabiturients.Where(p => p.Город.ToString().Contains(textBox1.Text.ToString())).ToList(); break;
                }
            }
            else
            {
                dataGridView1.DataSource = sheetabiturients;
            }
            dataGridView1.Update();
            if (dataGridView1.RowCount == 0) label1.Visible = true;
            else label1.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.Count == 1)
            {
                FormAddAbiturient addAbit = new FormAddAbiturient();
                addAbit.Owner = this; addAbit.Show();
            }
            else Application.OpenForms[1].Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.Count == 1)
            {
                Абитуриенты item = sheetabiturients.First(w => w.Код_абитуриента.ToString() == dataGridView1.SelectedCells[0].OwningRow.Cells[0].Value.ToString());
                FormEditAbiturient edAbit = new FormEditAbiturient(item);
                edAbit.Owner = this;
                edAbit.Show();
            }
            else Application.OpenForms[1].Focus();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
