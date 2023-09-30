using MySql.Data.MySqlClient;
using SportKush.Classes;
using SportKush.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SportKush.UserControls
{
    public partial class ProductControl : UserControl
    {
        public int idProduct;
        public int idManufacturer;
        public string name;
        public string description;
        public string compound;
        public int count;
        public int price;
        public int gram;
        public Image cover;
        public string idUser;
        public bool isBasket = false;
        private Form form;

        public ProductControl(string idUser, bool isBasket, Form form)
        {
            InitializeComponent();
            this.idUser = idUser;
            this.isBasket = isBasket;
            this.form = form;
        }

        private void ProductControl_Load(object sender, EventArgs e)
        {
            NameLabel.Text = name;
            GramLabel.Text = gram.ToString();
            CountLabel.Text = count.ToString();
            PriceLabel.Text = price.ToString();
            ImagePitcureBox.Image = cover;
            searchBusketProduct();
            if (isBasket)
            {
                InBusketButton.Text = "Купить";
                InStockLabel.Text = "Кол-во:";

            }
        }

        private void NameLabel_Click(object sender, EventArgs e)
        {
            DetailedProduct dp = new DetailedProduct();
            dp.id = idUser;
            dp.idProduct = idProduct;
            dp.idManufacturer = idManufacturer;
            dp.name = name;
            dp.description = description;
            dp.compound = compound;
            dp.count = count;
            dp.price = price;
            dp.gram = gram;
            dp.cover = cover;
            form.Close();
            dp.Show();
        }

        private void LogInButton_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            if (!isBasket)
            {
                MySqlCommand command = new MySqlCommand("INSERT INTO basket(id_user, id_product, counte) " +
                    "VALUES (@id_user, @id_product, @count)", db.getConnection());

                db.openConnection();
                try
                {
                    command.Parameters.AddWithValue("@id_user", idUser);
                    command.Parameters.AddWithValue("@id_product", idProduct);
                    command.Parameters.AddWithValue("@count", 1);
                    command.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                db.closeConnection();
            }
            else
            {

                MySqlCommand command = new MySqlCommand($"UPDATE product SET counte = counte-1 WHERE id_product = '{idProduct}'", db.getConnection());

                db.openConnection();
                try
                {
                    command.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                db.closeConnection();

                MySqlCommand command2 = new MySqlCommand($"UPDATE basket SET is_bought = true WHERE id_product = '{idProduct}'", db.getConnection());

                db.openConnection();
                try
                {
                    command2.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                db.closeConnection();
            }
            InBusketButton.Visible = false;
        }

        private void searchBusketProduct()
        {
            DB db = new DB();
                string queryInfo = $"SELECT id_basket, counte, is_bought FROM basket WHERE (id_user = {idUser}) AND (id_product={idProduct})";
                MySqlCommand mySqlCommand = new MySqlCommand(queryInfo, db.getConnection());

                db.openConnection();

                MySqlDataReader reader = mySqlCommand.ExecuteReader();
                while (reader.Read())
                {
                if (!isBasket)
                {
                    if (reader["id_basket"].ToString() != null && (bool)reader["is_bought"]!=true)
                    {
                        InBusketButton.Visible = false;
                    }
                }
                else
                {
                    CountLabel.Text = reader["counte"].ToString();
                    PriceLabel.Text = ((int)reader["counte"] * price).ToString();
                }
                }
                reader.Close();

                db.closeConnection();
        }
    }
}
