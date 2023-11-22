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
    public partial class Form2 : Form
    {
        Database dataBase = new Database();
        public DataTable table;
        public SqlDataAdapter adapter;
        public SqlCommandBuilder builder;
        public Form2()
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

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = new Form();
            form.Closed += (s, args) => this.Close();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Открытие таблицы авторов
            CreateTable("SELECT * FROM Авторы");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // открытие таблицы изданий
            CreateTable("SELECT * FROM Издания");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Открыть таблицу статьей 
            CreateTable("SELECT * FROM Статьи");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Покупка подписок

            MessageBox.Show("Вы успешно приобрели подписку");
        }
    }
}
