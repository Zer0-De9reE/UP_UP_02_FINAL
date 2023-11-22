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
    public partial class History : Form
    {
        enum RowState
        { Existed, New, Modified, ModifiedNew, Deleted }

        Database dataBase = new Database();
        //Dictionary<int, DateTime> list  = new Dictionary<int, DateTime>() { {1, DateTime.Now },{2, DateTime.Now } };
        public History()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }
        //DataGrid dataGrid;

        private void CreateColumns()
        {
            dataGridView1.Columns.Add("id", "id");
            dataGridView1.Columns.Add("time", "Время входа");
            dataGridView1.Columns.Add("succsesful", "1/0");
            dataGridView1.Columns.Add("IsNew", String.Empty);
        }

        private void ReadSingleRows(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.IsDBNull(0) ? -1:   record.GetInt32(0), record.GetDateTime(1), record.GetBoolean(2),  RowState.ModifiedNew);
        }

        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string stringQuery = $"select * from История";

            SqlCommand cmd = new SqlCommand(stringQuery, dataBase.getConnection());

            dataBase.openConnection();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRows(dgw, reader);
            }
            reader.Close();
        }


        private void History_Load(object sender, EventArgs e)
        {
            //List<int> list = new List<int>();
            //dataGridView1 = new DataGridView();
            //dataGridView1.ColumnCount = 2;
            //dataGridView1.DataSource = list;
            CreateColumns();
            RefreshDataGrid(dataGridView1);



        }

        private void Del()
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows[index].Visible = false;

            dataGridView1.Rows[index].Cells[3].Value = RowState.Deleted;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                var rowState = (RowState)dataGridView1.Rows[i].Cells[3].Value;

                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToString(dataGridView1.Rows[i].Cells[0].Value);
                    var deleteQuery = $"delete from История where id = {id}";

                    var command = new SqlCommand(deleteQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }
            }

        }

        private void button_Del_Click(object sender, EventArgs e)
        {
            Del();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form7 = new Administrator("Чибизов Степан Андреевич");
            form7.Closed += (s, args) => this.Close();
            form7.Show();

        }
    }
}
