using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace X_PASS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Data.password = textBox1.Text;
                if (Data.password.Length < 8 && Data.password.Length > 0)
                {
                    if (Data.language == "ru")
                    {
                        throw new Exception(Data.password + " это плохой пароль. Попробуйте ввести больше 8 символов");
                    }
                    else if(Data.language == "en")
                    {
                        throw new Exception(Data.password + " is bad password. Try enter more than 8 characters");
                    }
                }
                if (Data.password.Length == 0)
                {
                    if (Data.language == "ru")
                    {
                        throw new Exception("Пожалуйста введите ваш пароль");
                    }
                    else if (Data.language == "en")
                    {
                        throw new Exception("Please enter your password");
                    }
                }
                Main main = new Main();
                main.Owner = this;
                this.Hide();
                main.ShowDialog();
                this.Show();
                Close();
            }
            catch(Exception ex1)
            {
                if (Data.language == "ru")
                {
                    MessageBox.Show(ex1.Message, "ОШИБКА Создания пароля");
                }
                else if (Data.language == "en")
                {
                    MessageBox.Show(ex1.Message, "ERROR Creating password");
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //Алгоритм считывания конфиг файла
            StreamReader streamReader = new StreamReader("Config.config");
            string line = streamReader.ReadLine();
            int i = 0;
            while (line != null) 
            {
                i++;
                //Выбор языка из конфиг файла
                if (i == 1)
                {
                    if (line == "Language=\"en\"")
                    {
                        Data.language = "en";
                    }
                    else if(line == "Language=\"ru\"")
                    {
                        Data.language = "ru";
                    }
                    else
                    {
                        Data.language = "en";
                    }    
                }
                //Выбор столцов из конфиг файла
                if (i == 2)
                {
                    //пофиксить баг, если конфиг файл слетит
                    Data.dataGridColumns.AddRange(line.Split('=')[1].Replace("\"", "").Split(','));
                }
                //Выбор ширины столцов из конфиг файла
                if (i == 3)
                {
                    if (line.Split('=')[1].Replace("\"", "").Split(',').Length != 0)
                    {
                        for (int j = 0; j < line.Split('=')[1].Replace("\"", "").Split(',').Length; j++)
                        {
                            Data.dataGridColumnsWidth.Add(Int32.Parse(line.Split('=')[1].Replace("\"", "").Split(',')[j]));
                        }
                    }
                }
                line = streamReader.ReadLine();
            }
            streamReader.Close();

            //Изменение текста в Form1
            if (Data.language == "en")
            {
                button2.Text = "RU";
                label1.Text = "Enter your password";
                button1.Text = "Enter";
            }
            else if(Data.language == "ru")
            {
                button2.Text = "EN";
                label1.Text = "Введите ваш пароль";
                button1.Text = "Ввод";
            }
        }
        //Смена языка у кнопки в меню
        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "RU")
            {
                label1.Text = "Введите ваш пароль";
                button1.Text = "Ввод";
                button2.Text = "EN";
                Data.language = "ru";
            }
            else if (button2.Text == "EN")
            {
                label1.Text = "Enter your password";
                button1.Text = "Enter";
                button2.Text = "RU";
                Data.language = "en";
            }
            textBox1.Focus();
        }
        //Закрытие формы Form1
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //ИЗМЕНЕНИЕ КОНФИГ ФАЙЛА
            StreamWriter streamWriter = new StreamWriter("Config.config", false);
            streamWriter.WriteLine("Language=" + "\"" + Data.language + "\"");
            string dataGridName = "";
            for (int i = 0; i < Data.dataGridColumns.Count; i++)
            {
                if (Data.dataGridColumns.Count == 0)
                {
                    dataGridName = "\"TestColumn\"";
                }
                else if (Data.dataGridColumns.Count == 1)
                {
                    if (i == Data.dataGridColumns.Count - 1)
                    {
                        dataGridName = "\"" + Data.dataGridColumns[i] + "\"";
                    }
                }
                else if(Data.dataGridColumns.Count == 2)
                {
                    if (i == Data.dataGridColumns.Count - 1)
                    {
                        dataGridName = "\"" + Data.dataGridColumns[i];
                    }
                    else if (i == Data.dataGridColumns.Count - 1)
                    {
                        dataGridName = dataGridName + Data.dataGridColumns[i] + "\"";
                    }
                }
                else
                {
                    if (i == 0)
                    {
                        dataGridName = "\"" + Data.dataGridColumns[i] + ",";
                    }
                    else if (i == Data.dataGridColumns.Count - 1)
                    {
                        dataGridName = dataGridName + Data.dataGridColumns[i] + "\"";
                    }
                    else
                    {
                        dataGridName = dataGridName + Data.dataGridColumns[i] + ",";
                    }
                }
            }
            streamWriter.WriteLine("DataGridColumns=" + dataGridName);
            string strDataGridWidth = "";
            for (int i = 0; i < Data.dataGridColumnsWidth.Count; i++)
            {
                if (Data.dataGridColumnsWidth.Count == 0)
                {
                    strDataGridWidth = "\"100\"";
                }
                else if (Data.dataGridColumnsWidth.Count == 1)
                {
                    if (i == Data.dataGridColumnsWidth.Count - 1)
                    {
                        strDataGridWidth = "\"" + Data.dataGridColumnsWidth[i] + "\"";
                    }
                }
                else if (Data.dataGridColumnsWidth.Count == 2)
                {
                    if (i == Data.dataGridColumnsWidth.Count - 1)
                    {
                        strDataGridWidth = "\"" + Data.dataGridColumns[i];
                    }
                    else if (i == Data.dataGridColumnsWidth.Count - 1)
                    {
                        strDataGridWidth = strDataGridWidth + Data.dataGridColumnsWidth[i] + "\"";
                    }
                }
                else
                {
                    if (i == 0)
                    {
                        strDataGridWidth = "\"" + Data.dataGridColumnsWidth[i] + ",";
                    }
                    else if (i == Data.dataGridColumnsWidth.Count - 1)
                    {
                        strDataGridWidth = strDataGridWidth + Data.dataGridColumnsWidth[i] + "\"";
                    }
                    else
                    {
                        strDataGridWidth = strDataGridWidth + Data.dataGridColumnsWidth[i] + ",";
                    }
                }
            }
            streamWriter.WriteLine("DataGridColumnsWidth=" + strDataGridWidth);
            streamWriter.Close();
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    Data.password = textBox1.Text;
                    if (Data.password.Length < 8 && Data.password.Length > 0)
                    {
                        if (Data.language == "ru")
                        {
                            throw new Exception(Data.password + " это плохой пароль. Попробуйте ввести больше 8 символов");
                        }
                        else if (Data.language == "en")
                        {
                            throw new Exception(Data.password + " is bad password. Try enter more than 8 characters");
                        }
                    }
                    if (Data.password.Length == 0)
                    {
                        if (Data.language == "ru")
                        {
                            throw new Exception("Пожалуйста введите ваш пароль");
                        }
                        else if (Data.language == "en")
                        {
                            throw new Exception("Please enter your password");
                        }
                    }
                    Main main = new Main();
                    main.Owner = this;
                    this.Hide();
                    main.ShowDialog();
                    this.Show();
                    Close();
                }
                catch (Exception ex1)
                {
                    if (Data.language == "ru")
                    {
                        MessageBox.Show(ex1.Message, "ОШИБКА Создания пароля");
                    }
                    else if (Data.language == "en")
                    {
                        MessageBox.Show(ex1.Message, "ERROR Creating password");
                    }
                }
            }
        }
    }
}
