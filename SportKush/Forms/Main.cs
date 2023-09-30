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
    public partial class Main : Form
    {
        public string id = null;
        public bool isAdmin = false;
        public Main()
        {
            InitializeComponent();
        }
        private void GenerateProducts()
        {
            ProductBLL objbll = new ProductBLL();

            DataTable dt = objbll.GetItems(false, null, SearchInput.Text.Length !=0 ? SearchInput.Text : "");

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
                                Size = new Size(440, 500),
                                Padding = new System.Windows.Forms.Padding(bottom: 3, left: 0, top: 0, right: 0),
                            };
                            listItems[i] = new ProductControl(id, false, this);

                            listItems[i].idProduct = (int)row["id_product"];
                            listItems[i].idManufacturer = row["id_manufacturer"] is null ? (int)row["id_manufacturer"] : 0;
                            listItems[i].name = row["name"].ToString();
                            listItems[i].description = row["description"].ToString();
                            listItems[i].compound = row["compound"].ToString();
                            listItems[i].count = (int)row["counte"];
                            listItems[i].price = (int)row["price"];
                            listItems[i].gram = (int)row["gram"];

                            if (row["cover"] != System.DBNull.Value)
                            {
                                MemoryStream ms = new MemoryStream((byte[])row["cover"]);
                                listItems[i].cover = new Bitmap(ms);
                            }
                            panel.Controls.Add(listItems[i]);
                            LentaPanel.Controls.Add(panel);
                            panelNumber++;
                        }

                    }
                }
            }
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            new Profile(id).Show();
            this.Close();
        }


        private void Main_Load(object sender, EventArgs e)
        {
            if (id != "1")
            {
                AdminPanel.Visible = false;
            }
            DB db = new DB();
            string queryInfo = $"SELECT login, avatar, passwords FROM users WHERE id_user = '{id}'";
            MySqlCommand mySqlCommand = new MySqlCommand(queryInfo, db.getConnection());

            db.openConnection();

            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                LoginLabel.Text = reader[0].ToString();

                if (reader[1].ToString()!="")
                {
                    System.Drawing.Image avatar = (Bitmap)((new ImageConverter()).ConvertFrom(reader[1]));
                    UserAvatar.Image = avatar;
                    UserAvatar.Invalidate();
                }
            }
            reader.Close();

            db.closeConnection();
            GenerateProducts();
        }

        private void LoginLabel_Click(object sender, EventArgs e)
        {
            new Profile(id).Show();
            this.Close();
        }

        private void LogInButton_Click(object sender, EventArgs e)
        {
            new AddProduct(null).Show();
            this.Close();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            LentaPanel.Controls.Clear();
            GenerateProducts();
        }

        private void OrdersButton_Click(object sender, EventArgs e)
        {
            new ViewForm(1).Show();
            this.Close();
        }

        private void ManufacturerButton_Click(object sender, EventArgs e)
        {
            new ViewForm(2).Show();
            this.Close();
        }

        private void UsersButton_Click(object sender, EventArgs e)
        {
            new ViewForm(3).Show();
            this.Close();
        }
    }
}
