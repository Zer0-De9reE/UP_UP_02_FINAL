using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UP__
{
    public partial class Administrator : Form
    {


        public Administrator(string FIO)
        {

            InitializeComponent();
            label1.Text = FIO;
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button_sign_up_Click(object sender, EventArgs e)
        {
            Workers workers = new Workers();
            this.Hide();
            workers.ShowDialog();
            this.Show();

        }

        private void button_His_Click(object sender, EventArgs e)
        {
            History history = new History();
            history.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void Administrator_Load(object sender, EventArgs e)
        {

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
