using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace X_PASS
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        //Запись текст из DataGrid в файл
        void WritingTextDataGridToTextFile()
        {
            try
            {
                Data.numWhenEncryptedPasswordStop = 0;
                StreamWriter streamWriter = new StreamWriter("Text.txt", false);
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        if (dataGridView1[j, i].Value == null || dataGridView1[j, i].Value.ToString() == "")
                        {
                            streamWriter.WriteLine();
                        }
                        else
                        {
                            string dataGridValue = dataGridView1[j, i].Value.ToString();
                            string encryptedText = ConvertingTextToEncryptedText(dataGridValue, Data.password);
                            streamWriter.WriteLine(encryptedText);
                        }
                    }
                }
                streamWriter.Close();
            }
            catch 
            {
                if (Data.language == "ru")
                {
                    MessageBox.Show("Введённые данные сохранить не удалось", "ОШИБКА");
                }
                else if (Data.language == "en")
                {
                    MessageBox.Show("The entered data could not be saved", "ERROR");
                }
                
            }
        }
        //Запись текст из файла в DataGrid
        void WritingTextFileToTextDataGrid()
        {
            Data.numWhenDecryptedPasswordStop = 0;
            //Подсчёт строк в текстовом файле.
            StreamReader streamReaderCountLine = new StreamReader("Text.txt");
            int countLineInFile = 0;
            string line;
            while ((line = streamReaderCountLine.ReadLine()) != null)
            {
                countLineInFile++;
            }
            streamReaderCountLine.Close();

            StreamReader mainStreamReader = new StreamReader("Text.txt");
            string encryptedUserText;
            int i = 0;
            int countColumnInFile = 0;
            if (dataGridView1.ColumnCount != 0)
            {
                countColumnInFile = countLineInFile / dataGridView1.ColumnCount;
            }
            if (countColumnInFile == 0 && dataGridView1.ColumnCount != 0)
            {
                dataGridView1.Rows.Add();
            }
            while (i < countColumnInFile)
            {
                dataGridView1.Rows.Add();
                int j = 0;
                while (j < dataGridView1.ColumnCount)
                {
                    encryptedUserText = mainStreamReader.ReadLine();
                    if (encryptedUserText == null) { break; }
                    string encryptedText = ConvertingEncryptedTextToText(encryptedUserText, Data.password);
                    dataGridView1[j, i].Value = encryptedText;
                    j++;
                }
                i++;
            }
            mainStreamReader.Close();
        }
        //Метод, который объединяет методы для создания, из текста, зашифрованный текст.
        string ConvertingTextToEncryptedText(string UserText, string PasswordText)
        {
            List<string> binaryUserText = new List<string>();
            List<string> binaryPasswordText = new List<string>();
            List<string> binaryEncryptedText = new List<string>();

            ConvertingTextToBinary(UserText, binaryUserText);
            ConvertingTextToBinary(PasswordText, binaryPasswordText);
            ConvertingBinaryTextToBinaryEncryptedText(binaryUserText, binaryPasswordText, binaryEncryptedText);
            string encryptedText = ConvertingBinaryToText(binaryEncryptedText);
            return encryptedText;
        }
        //Метод, который объединяет методы для создания, из зашифрованного текста, обычный текст.
        string ConvertingEncryptedTextToText(string cryptedUserText, string cryptedPasswordText)
        {
            List<string> binaryCryptedUserText = new List<string>();
            List<string> binaryCryptedPasswordText = new List<string>();
            List<string> binaryDecryptedText = new List<string>();

            ConvertingTextToBinary(cryptedUserText, binaryCryptedUserText);
            ConvertingTextToBinary(cryptedPasswordText, binaryCryptedPasswordText);
            ConvertingBinaryEncryptedTextToBinaryDecryptedText(binaryCryptedPasswordText, binaryCryptedUserText, binaryDecryptedText);
            string decryptedText = ConvertingBinaryToText(binaryDecryptedText);
            return decryptedText;
        }
        void ConvertingTextToBinary(string encodedText, List<string> binaryEncodedText)
        {
            try
            {
                for (int i = 0; i < encodedText.Length; i++)
                {
                    binaryEncodedText.Add(Convert.ToString(encodedText[i], 2));

                    if (binaryEncodedText[i].Length == 8)
                    {

                    }
                    else if (Char.IsLetter(encodedText[i]))
                    {
                        binaryEncodedText[i] = "0" + binaryEncodedText[i];
                    }
                    else if (encodedText[i] == '@' || encodedText[i] == '^' || encodedText[i] == '_' || encodedText[i] == '`' || encodedText[i] == '~' || encodedText[i] == '[' || encodedText[i] == ']' || encodedText[i] == '{' || encodedText[i] == '}' || encodedText[i] == '|')
                    {
                        binaryEncodedText[i] = "0" + binaryEncodedText[i];
                    }
                    else
                    {
                        binaryEncodedText[i] = "0" + "0" + binaryEncodedText[i];
                    }
                    if (binaryEncodedText[i].Length > 8)
                    {
                        //binaryEncodedText[i].Remove(binaryEncodedText[i].Length, binaryEncodedText[i].Length - 8);
                        
                        if (Data.language == "ru")
                        {
                            throw new Exception("Введённый символ " + "'" + encodedText[i] + "'" + " недействителен для ввода в " + encodedText);
                        }
                        else if (Data.language == "en")
                        {
                            throw new Exception("Entered character " + "'" + encodedText[i] + "'" + " is not valid for input in " + encodedText);
                        }
                    }
                }
            }
            catch (Exception ex2)
            {
                if (Data.language == "ru")
                {
                    MessageBox.Show(ex2.Message, "ОШИБКА. Конвертации текста в двоичный код");
                }
                else if (Data.language == "en")
                {
                    MessageBox.Show(ex2.Message, "ERROR. Converting text to binary");
                }
            }
        }
        void ConvertingBinaryTextToBinaryEncryptedText(List<string> binaryEncodedUserText, List<string> binaryEncodedPasswordText, List<string> binaryEncryptedText)
        {
            int counter = 0;
            /*
            for (int i = 0; i < binaryEncodedUserText.Count; i++)
            {
                if (i >= binaryEncodedPasswordText.Count)
                {
                    i = 0;
                }
                string tempPass = binaryEncodedPasswordText[i];
                string tempUser = binaryEncodedUserText[counter];
                char[] tempEncryptedText = new char[8];

                for (int j = 0; j < 8; j++)
                {
                    if (tempPass[j] == '1' && tempUser[j] == '1')
                    {
                        tempEncryptedText[j] = '1';
                    }
                    if (tempPass[j] == '0' && tempUser[j] == '0')
                    {
                        tempEncryptedText[j] = '1';
                    }
                    if (tempPass[j] == '0' && tempUser[j] == '1')
                    {
                        tempEncryptedText[j] = '0';
                    }
                    if (tempPass[j] == '1' && tempUser[j] == '0')
                    {
                        tempEncryptedText[j] = '0';
                    }
                }
                string tempStr = new string(tempEncryptedText);
                binaryEncryptedText.Add(tempStr);
                counter += 1;
                if (counter == binaryEncodedUserText.Count)
                {
                    break;
                }
            }
            */
            while (counter != binaryEncodedUserText.Count)
            {
                if (Data.numWhenEncryptedPasswordStop == binaryEncodedPasswordText.Count)
                {
                    Data.numWhenEncryptedPasswordStop = 0;
                }
                string tempPass = binaryEncodedPasswordText[Data.numWhenEncryptedPasswordStop];
                string tempUser = binaryEncodedUserText[counter];
                char[] tempEncryptedText = new char[8];

                for (int j = 0; j < 8; j++)
                {
                    if (tempPass[j] == '1' && tempUser[j] == '1')
                    {
                        tempEncryptedText[j] = '1';
                    }
                    if (tempPass[j] == '0' && tempUser[j] == '0')
                    {
                        tempEncryptedText[j] = '1';
                    }
                    if (tempPass[j] == '0' && tempUser[j] == '1')
                    {
                        tempEncryptedText[j] = '0';
                    }
                    if (tempPass[j] == '1' && tempUser[j] == '0')
                    {
                        tempEncryptedText[j] = '0';
                    }
                }
                string tempStr = new string(tempEncryptedText);
                binaryEncryptedText.Add(tempStr);
                Data.numWhenEncryptedPasswordStop++;
                counter += 1;
            }
            binaryEncodedUserText.Clear();
        }
        void ConvertingBinaryEncryptedTextToBinaryDecryptedText(List<string> binaryEncryptedPassword, List<string> binaryEncryptedText, List<string> binaryDecryptedText)
        {
            int counter = 0;
            /*
            for (int i = 0; i < binaryEncryptedText.Count; i++)
            {
                if (i >= binaryEncryptedPassword.Count)
                    i = 0;
                string tempPass = binaryEncryptedPassword[i];
                string tempEncryptedText = binaryEncryptedText[counter];
                char[] tempDecryptedText = new char[8];

                for (int j = 0; j < 8; j++)
                {
                    if (tempPass[j] == '1' && tempEncryptedText[j] == '1')
                    {
                        tempDecryptedText[j] = '1';
                    }
                    if (tempPass[j] == '0' && tempEncryptedText[j] == '0')
                    {
                        tempDecryptedText[j] = '1';
                    }
                    if (tempPass[j] == '0' && tempEncryptedText[j] == '1')
                    {
                        tempDecryptedText[j] = '0';
                    }
                    if (tempPass[j] == '1' && tempEncryptedText[j] == '0')
                    {
                        tempDecryptedText[j] = '0';
                    }
                }
                string tempStr = new string(tempDecryptedText);
                binaryDecryptedText.Add(tempStr);

                counter += 1;
                if (counter == binaryEncryptedText.Count)
                {
                    break;
                }
            }
            */
            while (counter != binaryEncryptedText.Count)
            {
                if (Data.numWhenDecryptedPasswordStop == binaryEncryptedPassword.Count)
                    Data.numWhenDecryptedPasswordStop = 0;
                string tempPass = binaryEncryptedPassword[Data.numWhenDecryptedPasswordStop];
                string tempEncryptedText = binaryEncryptedText[counter];
                char[] tempDecryptedText = new char[8];

                for (int j = 0; j < 8; j++)
                {
                    if (tempPass[j] == '1' && tempEncryptedText[j] == '1')
                    {
                        tempDecryptedText[j] = '1';
                    }
                    if (tempPass[j] == '0' && tempEncryptedText[j] == '0')
                    {
                        tempDecryptedText[j] = '1';
                    }
                    if (tempPass[j] == '0' && tempEncryptedText[j] == '1')
                    {
                        tempDecryptedText[j] = '0';
                    }
                    if (tempPass[j] == '1' && tempEncryptedText[j] == '0')
                    {
                        tempDecryptedText[j] = '0';
                    }
                }
                string tempStr = new string(tempDecryptedText);
                binaryDecryptedText.Add(tempStr);
                Data.numWhenDecryptedPasswordStop++;
                counter += 1;
            }
            binaryEncryptedText.Clear();
        }
        string ConvertingBinaryToText(List<string> binaryDecryptedText)
        {
            char[] charConvertorDecodingPass = new char[binaryDecryptedText.Count];
            for (int i = 0; i < binaryDecryptedText.Count; i++)
            {

                int int32ConvertorDecodingPass = Convert.ToInt32(binaryDecryptedText[i], 2);
                charConvertorDecodingPass[i] = Convert.ToChar(int32ConvertorDecodingPass);
            }
            string strConvertorDecodingPass = new string(charConvertorDecodingPass);
            binaryDecryptedText.Clear();
            return strConvertorDecodingPass;
        }
        private void Main_Load(object sender, EventArgs e)
        {
            //Смена яызка в программе при запуске
            if (Data.language == "ru")
            {
                addStripDropDown.Text = "Добавить";
                addRowMenu.Text = "Добавить ряд";
                addColumnMenu.Text = "Добавить столбец";

                toolStripDropDownButton2.Text = "Удалить";
                deleteRowToolStripMenuItem.Text = "Удалить ряд";
                deleteLastRow.Text = "Удалить последний ряд";
                deleteSelectRows.Text = "Удалить выделенные ряды";
                deleteAllRowsToolStripMenuItem.Text = "Удалить все ряды";

                deleteColumnToolStripMenuItem.Text = "Удалить столбец";
            }
            else if (Data.language == "en")
            {
                addStripDropDown.Text = "Add";
                addRowMenu.Text = "Add row";
                addColumnMenu.Text = "Add column";


                toolStripDropDownButton2.Text = "Delete";
                deleteRowToolStripMenuItem.Text= "Delete row";
                deleteLastRow.Text = "Delete last row";
                deleteSelectRows.Text = "Delete select rows";
                deleteAllRowsToolStripMenuItem.Text = "Delete all rows";

                deleteColumnToolStripMenuItem.Text = "Delete column";
            }

            //Создание столбцов
            dataGridView1.Columns.Clear();
            Dictionary<string, DataGridViewTextBoxColumn> dictionary = new Dictionary<string, DataGridViewTextBoxColumn>();
            for (int i = 0; i < Data.dataGridColumns.Count; i++)
            {
                dictionary[Data.dataGridColumns[i]] = new DataGridViewTextBoxColumn();
                dictionary[Data.dataGridColumns[i]].HeaderText = Data.dataGridColumns[i];
                dictionary[Data.dataGridColumns[i]].Name = Data.dataGridColumns[i];
                dictionary[Data.dataGridColumns[i]].SortMode = DataGridViewColumnSortMode.NotSortable;
                dictionary[Data.dataGridColumns[i]].ValueType = typeof(string);
                dictionary[Data.dataGridColumns[i]].Resizable = DataGridViewTriState.False;
                dictionary[Data.dataGridColumns[i]].Width = Data.dataGridColumnsWidth[i];
                dataGridView1.Columns.Add(dictionary[Data.dataGridColumns[i]]);
            }
            dictionary.Clear();
            WritingTextFileToTextDataGrid();
        }
       
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            dataGridView1.EndEdit();
            dataGridView1.Focus();
            WritingTextDataGridToTextFile();

            //Lock button
            if (LockButton.Text == "✔")
            {
                dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
                dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                dataGridView1.AllowUserToOrderColumns = false;
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    dataGridView1.Columns[i].Resizable = DataGridViewTriState.False;
                }
                LockButton.Text = "🔒";
            }

            //Запись ширин dataGridColumns
            for (int i = 0; i < Data.dataGridColumnsWidth.Count; i++)
            {
                Data.dataGridColumnsWidth[i] = dataGridView1.Columns[i].Width;
            }
           
        }
        //удалить последний ряд
        private void deleteLastRow_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.RowCount - 1);
                dataGridView1.Refresh();
            }
        }
        //добавление нового ряда
        private void addRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int newRowIndex = dataGridView1.Rows.Add();
            dataGridView1.Rows[newRowIndex].Cells[0].Value = "";
        }
        //удалить выделенные ряды
        private void deleteSelectRows_Click(object sender, EventArgs e)
        {
            int countSelectedCells = dataGridView1.SelectedCells.Count;
            for (int i = 0; i < countSelectedCells; i++)
            {
                int selectedCells = dataGridView1.SelectedCells[0].RowIndex;
                dataGridView1.Rows.RemoveAt(selectedCells);
                dataGridView1.Refresh();
            }
        }
        //Удалить все ряды
        private void deleteAllRowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Data.language == "ru")
            {
                DialogResult messageBox1 = MessageBox.Show(
                  "Вы хотите удалить все записи?",
                  "Внимание",
                  MessageBoxButtons.YesNo
                );
                if (messageBox1 == DialogResult.Yes) dataGridView1.Rows.Clear();
            }
            else if (Data.language == "en")
            {
                DialogResult messageBox2 = MessageBox.Show(
                  "Do you want to delete all rows?",
                  "Warning",
                  MessageBoxButtons.YesNo
                );
                if (messageBox2 == DialogResult.Yes) dataGridView1.Rows.Clear();
            }
        }
        // Кнопка addColumn: добавление нового столбца
        private void addColumnMenu_Click(object sender, EventArgs e)
        {
            //Запись ширин dataGridColumns
            for (int i = 0; i < Data.dataGridColumnsWidth.Count; i++)
            {
                Data.dataGridColumnsWidth[i] = dataGridView1.Columns[i].Width;
            }

            AddColumn addColumn = new AddColumn();
            addColumn.Owner = this;
            addColumn.ShowDialog();
            dataGridView1.Columns.Clear();
            //Создание столбцов
            if (Data.dataGridColumns.Count != 0)
            {
                Dictionary<string, DataGridViewTextBoxColumn> dictionary = new Dictionary<string, DataGridViewTextBoxColumn>();
                for (int i = 0; i < Data.dataGridColumns.Count; i++)
                {
                    dictionary[Data.dataGridColumns[i]] = new DataGridViewTextBoxColumn();
                    dictionary[Data.dataGridColumns[i]].HeaderText = Data.dataGridColumns[i];
                    dictionary[Data.dataGridColumns[i]].Name = Data.dataGridColumns[i];
                    dictionary[Data.dataGridColumns[i]].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dictionary[Data.dataGridColumns[i]].ValueType = typeof(string);
                    dictionary[Data.dataGridColumns[i]].Resizable = DataGridViewTriState.False;
                    dictionary[Data.dataGridColumns[i]].Width = Data.dataGridColumnsWidth[i];
                    dataGridView1.Columns.Add(dictionary[Data.dataGridColumns[i]]);
                }
                dataGridView1.Rows.Add();
                dictionary.Clear();
            }
        }
        //Кнопка addRow: добавление нового ряда
        private void addRowMenu_Click(object sender, EventArgs e)
        {
            int newRowIndex = dataGridView1.Rows.Add();
            dataGridView1.Rows[newRowIndex].Cells[0].Value = "";
        }
        //Удаление стоблцов
        private void deleteColumnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Запись ширин dataGridColumns
            for (int i = 0; i < Data.dataGridColumnsWidth.Count; i++)
            {
                Data.dataGridColumnsWidth[i] = dataGridView1.Columns[i].Width;
            }

            AddColumn addColumn = new AddColumn();
            addColumn.Owner = this;
            addColumn.ShowDialog();
            dataGridView1.Columns.Clear();
            //Создание столбцов
            if (Data.dataGridColumns.Count != 0)
            {
                Dictionary<string, DataGridViewTextBoxColumn> dictionary = new Dictionary<string, DataGridViewTextBoxColumn>();
                for (int i = 0; i < Data.dataGridColumns.Count; i++)
                {
                    dictionary[Data.dataGridColumns[i]] = new DataGridViewTextBoxColumn();
                    dictionary[Data.dataGridColumns[i]].HeaderText = Data.dataGridColumns[i];
                    dictionary[Data.dataGridColumns[i]].Name = Data.dataGridColumns[i];
                    dictionary[Data.dataGridColumns[i]].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dictionary[Data.dataGridColumns[i]].ValueType = typeof(string);
                    dictionary[Data.dataGridColumns[i]].Width = Data.dataGridColumnsWidth[i];
                    dataGridView1.Columns.Add(dictionary[Data.dataGridColumns[i]]);
                }
                dataGridView1.Rows.Add();
                dictionary.Clear();
            }
        }
        // Кнопка(🔒) изминения столбцов
        private void LockButton_Click(object sender, EventArgs e)
        {
            if (LockButton.Text == "✔")
            {
                dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
                dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                dataGridView1.AllowUserToOrderColumns = false;
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    dataGridView1.Columns[i].Resizable = DataGridViewTriState.False;
                }
                LockButton.Text = "🔒";
            }
            else if(LockButton.Text == "🔒")
            {
                dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
                dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                dataGridView1.AllowUserToOrderColumns = true;
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    dataGridView1.Columns[i].Resizable = DataGridViewTriState.True;
                }
                LockButton.Text = "✔";
            }
        }
    }
}
