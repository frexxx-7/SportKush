using MySql.Data.MySqlClient;
using SportKush.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SportKush.Forms
{
    public partial class ViewForm : Form
    {
        private int numberPage;
        public ViewForm(int numberPage)
        {
            InitializeComponent();
            this.numberPage = numberPage;

            switch (numberPage)
            {
                case 1:
                        var column11 = new DataGridViewTextBoxColumn();
                        var column12 = new DataGridViewTextBoxColumn();
                        var column13 = new DataGridViewTextBoxColumn();
                        var column14 = new DataGridViewTextBoxColumn();
                        var column15 = new DataGridViewCheckBoxColumn();

                        column11.HeaderText = "Номер выдачи";
                        column11.Name = "Id_basket";

                        column12.HeaderText = "ID пользователя";
                        column12.Name = "id_User";

                        column13.HeaderText = "ID продукта";
                        column13.Name = "id_product";

                        column14.HeaderText = "Количество";
                        column14.Name = "counte";

                        column15.HeaderText = "Куплен";
                        column15.Name = "is_bought";

                        this.DataGridView1.Columns.AddRange(new DataGridViewColumn[] { column11, column12, column13, column14, column15 });
                    break;
                case 2:
                    var column21 = new DataGridViewTextBoxColumn();
                    var column22 = new DataGridViewTextBoxColumn();
                    var column23 = new DataGridViewTextBoxColumn();
                    var column24 = new DataGridViewTextBoxColumn();
                    var column25 = new DataGridViewTextBoxColumn();
                    var column26 = new DataGridViewTextBoxColumn();

                    column21.HeaderText = "Номер производителя";
                    column21.Name = "id_manufacturer";

                    column22.HeaderText = "Название";
                    column22.Name = "name";

                    column23.HeaderText = "Физический адресс";
                    column23.Name = "physical_address";

                    column24.HeaderText = "Юридический адресс";
                    column24.Name = "legal_address";

                    column25.HeaderText = "Телефон";
                    column25.Name = "phone";

                    column26.HeaderText = "Директор";
                    column26.Name = "director";

                    this.DataGridView1.Columns.AddRange(new DataGridViewColumn[] { column21, column22, column23, column24, column25, column26 });
                    break;
                case 3:
                    var column31 = new DataGridViewTextBoxColumn();
                    var column32 = new DataGridViewTextBoxColumn();
                    var column33 = new DataGridViewTextBoxColumn();

                    column31.HeaderText = "Номер прользователя";
                    column31.Name = "id_user";

                    column32.HeaderText = "Логин";
                    column32.Name = "login";

                    column33.HeaderText = "Пароль";
                    column33.Name = "password";

                    this.DataGridView1.Columns.AddRange(new DataGridViewColumn[] { column31, column32, column33 });
                    break;
                default:
                    break;
            }
        }

        private void ViewForm_Load(object sender, EventArgs e)
        {
            string query = null;

            switch (numberPage)
            {
                case 1:
                    query = "SELECT * from basket";
                    break;
                case 2:
                    query = "SELECT * from manufacturer";
                    break;
                case 3:
                    query = "SELECT * from users";
                    break;
                default:
                    query = null;
                    break;
            }

            DB db = new DB();
            DataGridView1.Rows.Clear();

            db.openConnection();
            using (MySqlCommand mySqlCommand = new MySqlCommand(query, db.getConnection()))
            {
                MySqlDataReader reader = mySqlCommand.ExecuteReader();

                List<string[]> dataDB = new List<string[]>();
                while (reader.Read())
                {
                    dataDB.Add(new string[reader.FieldCount]);

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        dataDB[dataDB.Count - 1][i] = reader[i].ToString();
                    }
                }
                reader.Close();
                foreach (string[] s in dataDB)
                    DataGridView1.Rows.Add(s);
            }
            db.closeConnection();
        }

        private void LogInButton_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.id = "1";
            main.Show();
            this.Close();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
