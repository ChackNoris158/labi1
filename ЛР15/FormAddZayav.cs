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
    public partial class FormAddZayav : Form
    {
        public Ip521_SegaAndGeraEntities db;
        public List<Абитуриенты> sheetabiturients;
        public List<Специальности> sheetspecs;

        public FormAddZayav()
        {
            InitializeComponent();
            db = new Ip521_SegaAndGeraEntities(); //настройка таблицы абитуриентов 
            sheetabiturients = db.Абитуриенты.OrderBy(o => o.Код_абитуриента).ToList(); dataGridView1.DataSource = sheetabiturients; dataGridView1.ReadOnly = true;
            if (dataGridView1.RowCount == 8) label1.Visible
            = true;
            else label1.Visible = false;
            dataGridView1.Columns[0].HeaderText = "";
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            //настройка таблицы специальностей
            sheetspecs = db.Специальности.OrderBy(o => o.Название).ToList(); dataGridView2.DataSource = sheetspecs; dataGridView2.ReadOnly = true;
            if (dataGridView2.RowCount == 0) label1.Visible = true;
            else label1.Visible = false;
            dataGridView2.Columns[0].Visible = false;
            dataGridView2.Columns[1].HeaderText = "Специальность";
            dataGridView2.Columns[2].Visible = false;
            dataGridView2.Columns[3].Visible = false; dataGridView2.Columns[4].Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count == 1 && dataGridView1.SelectedCells.Count == 1) 
            {
                if (textBox3.Text.Trim() != "")
                {
                    try 
                    {
                        Заявления result = new Заявления();
                        result.Код_абитуриента=Int32.Parse(dataGridView1
                        .SelectedCells[0].OwningRow.Cells[0].Value.ToString()); result.Код_специальности = Int32.Parse(dataGridView2
                        .SelectedCells[0].OwningRow.Cells[0].Value.ToString());
                        result.Статус = textBox3.Text; ((Form2)Owner).db.Заявления.Add(result); ((Form2)Owner).db.SaveChanges();
                        // блок кода для обновления таблицы
                        ((Form2)Owner).viewzayav = ((Form2)Owner).db.Абитуриенты.Join(((Form2)Owner).db.Заявления, a => a.Код_абитуриента,
                        з => з.Код_абитуриента,
                        (a, з) => new { a, з }).Join(((Form2)Owner).db.Специальности,зc => зc.з.Код_специальности, c => c.Код_специальности, (зc, с) => new { зc, с }).AsEnumerable()
                        .Select(x => new view(
                        x.зc.з.Код_заявления,
                        x.зc.a.Фамилия,
                        x.с.Название,
                        x.зc.з.Статус))
                        .OrderBy(o => o.Код_заявления).ToList(); 
                        ((Form2)Owner).label1.Visible = false; 
                        ((Form2)Owner).dataGridView1.DataSource=((Form2)Owner).viewzayav;  
                        ((Form2)Owner).dataGridView1.Refresh(); this.Close();
                        }
                    catch (Exception err)
                    {
                        label1.Visible = true;
                        label1.Text = "Ошибка ввода!\n" + err.Message;
                    }
                }
                else
                {
                    label1.Visible = true; label1.Text = "Укажите статус!";
                }               
            }               
            else               
            {                  
                label1.Visible = true;            
                label1.Text = "Выберите ровно одного абитуриента\n и ровно одну специальность!";
            }
        }
    }
}
