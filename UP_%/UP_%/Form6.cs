using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace UP__
{
    public partial class Form6 : Form
    {
        public enum RowStat
        { Existed, New, Modified, ModifiedNew, Deleted }
        
        
        Database dataBase = new Database();

        private void CreateColumns()
        {
            dataGridView1.Columns.Add("[Код получателя]", "[Код получателя]");
            dataGridView1.Columns.Add("[Ф.И.О]", "[Ф.И.О]");
            dataGridView1.Columns.Add("Адрес", "Адрес");
            dataGridView1.Columns.Add("[Контактная информация]", "[Контактная информация]");
            dataGridView1.Columns.Add("[Дополнительная информация]", "[Дополнительная информация]");
            dataGridView1.Columns.Add("IsNew", String.Empty);
        }

        private void ReadSingleRows(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetString(4), RowStat.ModifiedNew);
        }
        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string stringQuery = $"select * from Получатель";

            SqlCommand cmd = new SqlCommand(stringQuery, dataBase.getConnection());

            dataBase.openConnection();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRows(dgw, reader);
            }
            reader.Close();
        }
        public Form6()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // добавление пользователя как получателя в sql таблицу
            dataBase.openConnection();

            int id;
            var fio = textBox2.Text;
            var Adress = textBox3.Text;
            var Kontakt_inf = textBox4.Text;
            var Include_inf = textBox5.Text;

            if (int.TryParse(textBox1.Text, out id))
            {
                string addQuery = $"insert into Получатель ([Код получателя], [Ф.И.О], Адрес, [Контактная информация], [Дополнительная информация]) " +
                                  $"values('{id}','{fio}','{Adress}','{Kontakt_inf}','{Include_inf}')";

                var command = new SqlCommand(addQuery, dataBase.getConnection());
                command.ExecuteNonQuery();



                MessageBox.Show("Запись создана успешно!!!", "Успех!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Введено не правильно");
            }
            dataBase.closeConnection();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // выход из формы 
            this.Hide();
            var form = new Form();
            form.Closed += (s, args) => this.Close();
            form.Show();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGrid(dataGridView1);
        }
    }
}
