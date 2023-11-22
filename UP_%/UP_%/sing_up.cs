using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UP__
{
    public partial class sign_up : Form
    {
        Database dataBase = new Database();
        public sign_up()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button_sign_up_Click(object sender, EventArgs e)
        {
            var id = textBox1.Text;
            var login = textBox_login.Text;
            var password = textBox_pwd.Text;
            var fio = textBox_FIO.Text;
            var role = textBox_role.Text;

            string stringQuery = $"insert into Пользователи(id, login, pwd, roles, fio) " +
                                 $"values('{id}','{login}','{password}','{role}','{fio}')";

            SqlCommand command = new SqlCommand(stringQuery, dataBase.getConnection());
            dataBase.openConnection();


            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Аккаунт успешно создан!!!", "@@@");
                Form log_In = new Form();
                this.Hide();
                log_In.ShowDialog();
                this.Show();
            }
            else
            { 
                MessageBox.Show("Аккаунт не создан!!!", "@@@");
            }

            dataBase.closeConnection();

        }



        private void button1_Click(object sender, EventArgs e)
        {
            //выход на перв
            this.Hide();
            var form1 = new Form();
            form1.Closed += (s, args) => this.Close();
            form1.Show();
        }
    }
}
