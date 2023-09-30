using MySql.Data.MySqlClient;
using SportKush.Classes;
using SportKush.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SportKush
{
    public partial class Autorization : Form
    {
        public Autorization()
        {
            InitializeComponent();
        }

        private void RegistrationLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registration reg = new Registration();
            reg.StartPosition = FormStartPosition.CenterScreen;
            reg.Show();
            this.Hide();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LogInButton_Click(object sender, EventArgs e)
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @uL AND `passwords` = @uP", db.getConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = LoginInput.Text;
            command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = PasswordInput.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                string queryAccount = $"SELECT id_user FROM users WHERE login = '{LoginInput.Text}'";
                MySqlCommand mySqlCommand = new MySqlCommand(queryAccount, db.getConnection());
                Main main = new Main();

                db.openConnection();

                main.id = mySqlCommand.ExecuteScalar().ToString();

                db.closeConnection();

                ErrorLabel.Text = "Добро пожаловать";
                ErrorLabel.Visible = true;
                main.isAdmin = LoginInput.Text == "admin" || LoginInput.Text == "admin";

                this.Hide();
                main.Show();
            }
            else
            {
                ErrorLabel.Text = "Неправильный логин или пароль";
                ErrorLabel.Visible = true;
            }
        }

        private void LoginInput_TextChanged(object sender, EventArgs e)
        {
            ErrorLabel.Visible = false;
        }

        private void PasswordInput_TextChanged(object sender, EventArgs e)
        {
            ErrorLabel.Visible = false;
        }
    }
}
