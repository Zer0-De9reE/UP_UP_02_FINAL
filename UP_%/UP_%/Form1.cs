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
using System.Reflection.Emit;


namespace UP__
{
    public partial class Invite : Form
    {

        private string text = String.Empty;
        Database dataBase = new Database();
        private int count = 0;
        private Timer timer;
        int remaning;
        int time = 180;

        public Invite()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            button4.Visible = false;
            textBox3.Visible = false;
            button3.Visible = false;
            label4.Visible = false;
            remaning = 60;
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = this.CreateImage(pictureBox1.Width, pictureBox1.Height);
            textBox2.PasswordChar = '•';

        }

        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = this.CreateImage(pictureBox1.Width, pictureBox1.Height);
        }

        private void button_Enter_Click(object sender, EventArgs e)
        {

            
            var login = textBox1.Text;
            var password = textBox2.Text;


            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();


            string queryString = $"select id, login, password, roles, fio from Пользователи " +
                                 $"where login = '{login}' and password = '{password}'";



            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);


            dataBase.openConnection();
            string history = $"insert into История (id, time, succsesful)";

            if (table.Rows.Count != 1)
            {
                history += $" values (NULL, '{DateTime.Now.ToString("yyyy-dd-MM HH:mm:ss")}', 'false')";
            }
            else
            {
                history += $" values ({table.Rows[0].ItemArray[0].ToString()}, '{DateTime.Now.ToString("yyyy-dd-MM HH:mm:ss")}', 'true')";
            }


            SqlCommand his = new SqlCommand(history, dataBase.getConnection());
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = his;
            his.ExecuteNonQuery();

            if (table.Rows.Count == 1)
            {

                MessageBox.Show("Вы успешно вошли", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (table.Rows[0].ItemArray[3].ToString() == "Administrator")
                {
                    Administrator administrator = new Administrator($"{table.Rows[0].ItemArray[3].ToString()}, {table.Rows[0].ItemArray[4].ToString()}");
                    this.Hide();
                    administrator.ShowDialog();
                    this.Show();
                    count = 0;
                }
                if (table.Rows[0].ItemArray[3].ToString() == "Mailkeeper")
                {
                    Form3 pochta = new Form3();
                    this.Hide();
                    pochta.ShowDialog();
                    this.Show();
                    count = 0;
                }
                if (table.Rows[0].ItemArray[3].ToString() == "Klient")
                {
                    Form2 klient= new Form2();
                    this.Hide();
                    klient.ShowDialog();
                    this.Show();
                    count = 0;
                }
            }


            else
            {
                count++;
                MessageBox.Show("Не получилось", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            label3.Text = $"Количество попыток {count}/3";
            if (count == 1)
            {
                button4.Visible = true;
                button_Enter.Visible = false;
                textBox1.Visible = true;
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                button3.Visible = true;
                textBox3 .Visible = true;
                pictureBox1 .Visible = true;
                button2 .Visible = false;
                textBox1.Text = "Введите CAPTCHA!!!";
                textBox2.Text = "Введите CAPTCHA!!!";
                pictureBox1.Image = this.CreateImage(pictureBox1.Width, pictureBox1.Height);
            }
            if (count == 2)
            {
                label4.Visible = true;
                timer1.Start();
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                button_Enter.Enabled = false;
                button4.Visible = true;
                button_Enter.Visible = false;
                textBox1.Visible = true;
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                button3.Visible = true;
                textBox3.Visible = true;
                button2 .Visible = false;
                pictureBox1 .Visible = true;
                textBox1.Text = "Введите CAPTCHA!!!";
                textBox2.Text = "Введите CAPTCHA!!!";
                pictureBox1.Image = this.CreateImage(pictureBox1.Width, pictureBox1.Height);

            }
            if (count == 3)
            {
                Application.Exit();
            }
        }

        private Bitmap CreateImage(int Width, int Height)
        {
            Random rnd = new Random();

            //Создадим изображение
            Bitmap result = new Bitmap(Width, Height);

            //Вычислим позицию текста
            int Xpos = rnd.Next(0, Width - 50);
            int Ypos = rnd.Next(15, Height - 15);

            //Добавим различные цвета
            Brush[] colors = { Brushes.Black,
                     Brushes.Red,
                     Brushes.RoyalBlue,
                     Brushes.Green };

            //Укажем где рисовать
            Graphics g = Graphics.FromImage(result);

            //Пусть фон картинки будет серым
            g.Clear(Color.Gray);

            //Сгенерируем текст
            text = String.Empty;
            string ALF = "1234567890QWERTYUIOPASDFGHJKLZXCVBNM";
            for (int i = 0; i < 5; ++i)
                text += ALF[rnd.Next(ALF.Length)];

            //Нарисуем сгенирируемый текст
            g.DrawString(text,
                         new Font("Arial", 15),
                         colors[rnd.Next(colors.Length)],
                         new PointF(Xpos, Ypos));

            //Добавим немного помех
            /////Линии из углов
            g.DrawLine(Pens.Black,
                       new Point(0, 0),
                       new Point(Width - 1, Height - 1));
            g.DrawLine(Pens.Black,
                       new Point(0, Height - 1),
                       new Point(Width - 1, 0));
            ////Белые точки
            //for (int i = 0; i < Width; ++i)
            //    for (int j = 0; j < Height; ++j)
            //        if (rnd.Next() % 20 == 0)
            //            result.SetPixel(i, j, Color.White);

            return result;
        }
        private void button1_Click(object sender, EventArgs e)
        {

            pictureBox1.Image = this.CreateImage(pictureBox1.Width, pictureBox1.Height);


        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == this.text)
            {
                MessageBox.Show("Верно!");
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox1.Text = "";
                textBox2.Text = "";
                button_Enter.Visible = true;
                button4.Visible = false;
                textBox3.Visible = false;
                button2.Visible = true;
                pictureBox1.Visible = false;
                button3.Visible = false;
                label3.Visible = false;
            }
            else if (textBox3.Text != this.text)
            {
                MessageBox.Show("ERROR!!!");
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            time--;
            label4.Text = $"Осталось: {time}";
            if (time == 0)
            {
                timer1.Stop();
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                button_Enter.Enabled = true;
                MessageBox.Show("Время закончилось!!!");
                this.Close();
            }
            if (textBox3.Text == this.text)
            {
                timer1.Stop();
                label4.Visible = false;
                button_Enter.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sign_up sign_Up = new sign_up();
            this.Hide();
            sign_Up.ShowDialog();
            this.Show();
        }
    }
}
