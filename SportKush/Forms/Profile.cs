using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using SportKush.Classes;
using SportKush.Classes.Product;
using SportKush.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SportKush.Forms
{
    public partial class Profile : Form
    {
        public string id;
        public string login;
        public Image avatar;
        public Profile(string id)
        {
            InitializeComponent();
            this.id = id;
            loadUserInfo();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
        }
        private void loadUserInfo()
        {
            DB db = new DB();
            string queryInfo = $"SELECT login, avatar, passwords FROM users WHERE id_user = '{id}'";
            MySqlCommand mySqlCommand = new MySqlCommand(queryInfo, db.getConnection());

            db.openConnection();

            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                LoginLabel.Text = reader[0].ToString();
                LoginInput.Text = reader[0].ToString();
                PasswordInput.Text = reader[2].ToString();

                if (reader[1].ToString() != "")
                {
                    System.Drawing.Image avatar = (Bitmap)((new ImageConverter()).ConvertFrom(reader[1]));
                    UserAvatar.Image = avatar;
                    UserAvatar.Invalidate();
                }
            }
            reader.Close();

            db.closeConnection();
        }

        private void guna2ControlBox1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LogInButton_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.id = id;
            main.Show();
            this.Close();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
                DB db = new DB();
                MySqlCommand command = new MySqlCommand($"UPDATE users SET avatar = @image WHERE id_user = '{id}'", db.getConnection());

                db.openConnection();

                OpenFileDialog open_dialog = new OpenFileDialog();
                open_dialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
                if (open_dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        command.Parameters.AddWithValue("@image", File.ReadAllBytes($"{open_dialog.FileName}"));
                        command.ExecuteNonQuery();

                        Bitmap image = new Bitmap(open_dialog.FileName);
                        UserAvatar.Image = image;
                        UserAvatar.Invalidate();
                    }
                    catch
                    {
                        MessageBox.Show("Изображение должно быть меньше 16 МБ", "Ошибка изображения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

                db.closeConnection();
        }

        private void GenerateProducts()
        {
            ProductBLL objbll = new ProductBLL();

            DataTable dt = objbll.GetItems(true, id, "");

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    ProductControl[] listItems = new ProductControl[dt.Rows.Count];

                    for (int i = 0; i < 1; i++)
                    {
                        int panelNumber = 0;
                        foreach (DataRow row in dt.Rows)
                        {
                            Guna2Panel panel = new Guna2Panel
                            {
                                Name = $"Product+{panelNumber}",
                                Size = new Size(310, 400),
                                Padding = new System.Windows.Forms.Padding(bottom: 3, left: 0, top: 0, right: 0),
                            };
                            listItems[i] = new ProductControl(id, true, this);

                            listItems[i].idProduct = (int)row["id_product"];
                            listItems[i].idManufacturer = row["id_manufacturer"] is null ? (int)row["id_manufacturer"] : 0;
                            listItems[i].name = row["name"].ToString();
                            listItems[i].description = row["description"].ToString();
                            listItems[i].compound = row["compound"].ToString();
                            listItems[i].count = (int)row["counte"];
                            listItems[i].price = (int)row["price"];
                            listItems[i].gram = (int)row["gram"];
                            listItems[i].Dock = DockStyle.Fill;

                            if (row["cover"] != System.DBNull.Value)
                            {
                                MemoryStream ms = new MemoryStream((byte[])row["cover"]);
                                listItems[i].cover = new Bitmap(ms);
                            }
                            panel.Controls.Add(listItems[i]);
                            ProductPanel.Controls.Add(panel);
                            panelNumber++;
                        }

                    }
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand($"UPDATE users SET login = @login, passwords = @password WHERE id_user = '{id}'", db.getConnection());

            db.openConnection();
                try
                {
                    command.Parameters.AddWithValue("@login", LoginInput.Text);
                    command.Parameters.AddWithValue("@password", PasswordInput.Text);
                command.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Изображение должно быть меньше 16 МБ", "Ошибка изображения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            db.closeConnection();
            loadUserInfo();
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            GenerateProducts();
        }
    }
}
