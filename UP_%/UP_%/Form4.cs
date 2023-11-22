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
    public partial class Form4 : Form
    {
        public enum RowStat
        { Existed, New, Modified, ModifiedNew, Deleted }

        Database dataBase = new Database();

        public Form4()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void CreateColumns()
        {
            dataGridView1.Columns.Add("[Код статьи]", "[Код статьи]");
            dataGridView1.Columns.Add("[Код издания]", "[Код издания]");
            dataGridView1.Columns.Add("[Код Автора]", "[Код Автора]");
            dataGridView1.Columns.Add("[Заголовок]", "[Заголовок]");
            dataGridView1.Columns.Add("[Текст статьи]", "[Текст статьи]");
            dataGridView1.Columns.Add("[Дата публикации]", "[Дата публикации]");
            dataGridView1.Columns.Add("IsNew", String.Empty);
        }
        private void ReadSingleRows(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetInt32(1), record.GetInt32(2), record.GetString(3), record.GetString(4), record.GetDateTime(5), RowStat.ModifiedNew);
        }
        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string stringQuery = $"select * from Статьи";

            SqlCommand cmd = new SqlCommand(stringQuery, dataBase.getConnection());

            dataBase.openConnection();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRows(dgw, reader);
            }
            reader.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            // запись в sql статьи в таблицу
                dataBase.openConnection();

                int id;
                int id_izd;
                int id_auth;
                var Name = textBox4.Text;
                var Text = richTextBox1.Text;
                var Datetime  = textBox5.Text;

                if (int.TryParse(textBox1.Text, out id) | int.TryParse(textBox2.Text, out id_izd) |  int.TryParse(textBox3.Text, out id_auth))
                {
                    string addQuery = $"insert into Статьи([Код статьи], [Код издания], [Код Автора], [Заголовок], [Текст статьи], [Дата публикации]) " +
                                      $"values('{id}','{id_izd}','{id_auth}','{Name}','{Text}', '{Datetime}')";

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
            // выход на Form_3

            this.Hide();
            var form3 = new Form3();
            form3.Closed += (s, args) => this.Close();
            form3.Show();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGrid(dataGridView1);
        }
    }
}
