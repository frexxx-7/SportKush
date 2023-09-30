using MySql.Data.MySqlClient;
using SportKush.Classes;
using System;
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
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            new Autorization().Show();
            this.Hide();
        }

        private void LogInButton_Click(object sender, EventArgs e)
        {
            DB db = new DB();

            string query = "SELECT * FROM users ORDER BY login";
            MySqlCommand mySqlCommand = new MySqlCommand(query, db.getConnection());

            db.openConnection();

            if (LoginInput.Text == "" || PasswordInput.Text == "" || RepeatPassword.Text == "")
            {
                ErrorLabel.Text = "Вы не ввели данные!";
                ErrorLabel.Visible = true;
            }
            else
            {
                if (PasswordInput.Text.Length >= 8)
                {
                    bool en = true;
                    bool number = false;

                    for (int i = 0; i < PasswordInput.Text.Length; i++)
                    {
                        if (PasswordInput.Text[i] >= 'А' && PasswordInput.Text[i] <= 'Я') en = false;
                        if (PasswordInput.Text[i] >= '0' && PasswordInput.Text[i] <= '9') number = true;
                    }
                    if (!en)
                    {
                        ErrorLabel.Text = "Доступна только английская раскладка";
                        ErrorLabel.Visible = true;
                    }
                    else if (!number)
                    {
                        ErrorLabel.Text = "Добавьте хотя бы одну цифру";
                        ErrorLabel.Visible = true;
                    }
                    if (en && number)
                    {
                        if (RepeatPassword.Text == PasswordInput.Text)
                        {
                                using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                                {
                                    ApplyExecuteResults();

                                new Autorization().Show();
                                this.Hide();
                            }
                                ErrorLabel.Text = "Логин уже существует";
                                ErrorLabel.Visible = true;
                        }
                        else
                        {
                            ErrorLabel.Text = "Пароли не совпадают";
                            ErrorLabel.Visible = true;
                        }
                    }
                }
                else
                {
                    ErrorLabel.Text = "Пароль минимум 8 символов!";
                    ErrorLabel.Visible = true;
                }
            }
            db.closeConnection();
        }
        private void ApplyExecuteResults()
        {
            DB db = new DB();

            MySqlCommand command = new MySqlCommand("INSERT INTO `users` (`login`, `passwords`) " +
                "VALUES (@login, @password)", db.getConnection());

            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = LoginInput.Text;
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = PasswordInput.Text;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                ErrorLabel.Text = "Аккаунт создан!";
            }
            else
            {
                ErrorLabel.Text = "Ошибка созадния аккаунта";
                ErrorLabel.Visible = true;
            }

            db.closeConnection();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginInput_TextChanged(object sender, EventArgs e)
        {
            ErrorLabel.Visible = false;
        }

        private void PasswordInput_TextChanged(object sender, EventArgs e)
        {
            ErrorLabel.Visible = false;
        }

        private void RepeatPassword_Validated(object sender, EventArgs e)
        {

        }

        private void RepeatPassword_TextChanged(object sender, EventArgs e)
        {
            ErrorLabel.Visible = false;
        }
    }
}
