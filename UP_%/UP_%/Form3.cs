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
    public partial class Form3 : Form
    {
        Database dataBase = new Database();
        public DataTable table;
        public SqlDataAdapter adapter;
        public SqlCommandBuilder builder;

        public Form3()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        public void CreateTable(string sqlCommand)
        {
            dataBase.openConnection();
            table = new DataTable("dataGridView1");
            adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand(sqlCommand, dataBase.getConnection());
            builder = new SqlCommandBuilder(adapter);
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            dataBase.closeConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // открывание таблицы с подписками 
            CreateTable("SELECT * FROM Подписка");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // открытие формы по добавлению статьи
            this.Hide();
            var form4 = new Form4();
            form4.Closed += (s, args) => this.Close();
            form4.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // открывается форма с заполнением данных получателя
            this.Hide();
            var form6 = new Form6();
            form6.Closed += (s, args) => this.Close();
            form6.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // выход из формы 
            this.Hide();
            var form = new Form();
            form.Closed += (s, args) => this.Close();
            form.Show();
        }
    }
}
