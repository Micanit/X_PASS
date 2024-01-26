using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace X_PASS
{
    public partial class AddColumn : Form
    {
        public AddColumn()
        {
            InitializeComponent();
        }

        //Нажатие на Enter Column Name
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                textBox1.Focus();
                listBox1.Items.Add(textBox1.Text);
                Data.dataGridColumnsWidth.Add(100);
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                textBox1.Text = "";
            }
            else 
            {
                if (Data.language == "en")
                {
                    MessageBox.Show("Enter name column.", "Error");
                }
                else if (Data.language == "ru")
                {
                    MessageBox.Show("Введите название столбца.", "Ошибка");
                }
            }
        }
        //Стрелка вверх
        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > 0)
            {
                string oldItemText = listBox1.Items[listBox1.SelectedIndex - 1].ToString();
                int oldColumnsWidth = Data.dataGridColumnsWidth[listBox1.SelectedIndex - 1];
                listBox1.Items[listBox1.SelectedIndex - 1] = listBox1.Items[listBox1.SelectedIndex].ToString();
                Data.dataGridColumnsWidth[listBox1.SelectedIndex - 1] = Data.dataGridColumnsWidth[listBox1.SelectedIndex];
                listBox1.Items[listBox1.SelectedIndex] = oldItemText;
                Data.dataGridColumnsWidth[listBox1.SelectedIndex] = oldColumnsWidth;
                listBox1.SelectedIndex--;
            }
        }
        //Стрелка вниз
        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < listBox1.Items.Count - 1)
            {
                string oldItemText = listBox1.Items[listBox1.SelectedIndex + 1].ToString();
                int oldColumnsWidth = Data.dataGridColumnsWidth[listBox1.SelectedIndex + 1];
                listBox1.Items[listBox1.SelectedIndex + 1] = listBox1.Items[listBox1.SelectedIndex].ToString();
                Data.dataGridColumnsWidth[listBox1.SelectedIndex + 1] = Data.dataGridColumnsWidth[listBox1.SelectedIndex];
                listBox1.Items[listBox1.SelectedIndex] = oldItemText;
                Data.dataGridColumnsWidth[listBox1.SelectedIndex] = oldColumnsWidth;
                listBox1.SelectedIndex++;
            }
        }
        //Сохранение столбца
        private void button4_Click(object sender, EventArgs e)
        {
            Data.dataGridColumns.Clear();
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                Data.dataGridColumns.Add(listBox1.Items[i].ToString());
            }
            this.Close();
        }
        //Запуск формы
        private void AddColumn_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < Data.dataGridColumns.Count; i++)
            {
                listBox1.Items.Add(Data.dataGridColumns[i]);
            }
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
            if (Data.language == "en")
            {
                this.Text = "Columns";
                label1.Text = "Column name";
                label2.Text = "Columns location";
                button1.Text = "Enter";
                button4.Text = "Enter";
            }
            else if (Data.language == "ru")
            {
                this.Text = "Столбцы";
                label1.Text = "Название столбца";
                label2.Text = "Расположение столбцов";
                button1.Text = "Ввод";
                button4.Text = "Ввод";
            }
        }
        //Кнопка удаления
        private void deleteColumnButton_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                Data.dataGridColumnsWidth.RemoveAt(listBox1.SelectedIndex);
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
            }
        }
        //Сохранение через нажатие Enter в textBox1
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox1.Text.Length > 0)
                {
                    textBox1.Focus();
                    listBox1.Items.Add(textBox1.Text);
                    Data.dataGridColumnsWidth.Add(100);
                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                }
                else
                {
                    if (Data.language == "en")
                    {
                        MessageBox.Show("Enter name column.", "Error");
                    }
                    else if(Data.language == "ru")
                    {
                        MessageBox.Show("Введите название столбца.", "Ошибка");
                    }
                }
            }
        }
    }
}
