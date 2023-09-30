using Guna.UI2.WinForms.Suite;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using SportKush.Classes;
using SportKush.Classes.Product;
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
using System.Xml.Linq;

namespace SportKush.Forms
{
    public partial class AddProduct : Form
    {
        private Image image = null;
        private string idProduct = null;
        public AddProduct(string idProduct)
        {
            InitializeComponent();
            this.idProduct = idProduct;
        }

        private void guna2TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
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

        private void AddProduct_Load(object sender, EventArgs e)
        {
            AddedPanel.Controls.Add(ProductPanel);
            ProductPanel.Visible = true;
            ProductPanel.Dock = DockStyle.Fill;

            DB db = new DB();
            string queryInfoCbb = $"SELECT name, id_manufacturer FROM manufacturer";
            MySqlCommand mySqlCommandCbb = new MySqlCommand(queryInfoCbb, db.getConnection());
            db.openConnection();

            MySqlDataReader readerCbb = mySqlCommandCbb.ExecuteReader();
            while (readerCbb.Read())
            {
                ManufacturerComboBox.Items.Add(readerCbb[1].ToString() + " "+ readerCbb[0].ToString());
            }
            readerCbb.Close();

            db.closeConnection();

            if(idProduct != null)
            {
                loadInfoProduct();
                guna2Button2.Text = "Сохранить";
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            AddedPanel.Controls.Clear();
            AddedPanel.Controls.Add(ManufacturerPanel);
            ManufacturerPanel.Visible = true;
            ManufacturerPanel.Dock = DockStyle.Fill;
            label1.Text = "Добавить производителя";
        }

        private void AddPhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog opendlg = new OpenFileDialog();
            if (opendlg.ShowDialog() == DialogResult.OK)
            {
                image = Image.FromFile(opendlg.FileName);
                Cover.Image = image;
                Cover.Visible = true;
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (idProduct == null)
            {
                ProductBLL objbll = new ProductBLL();

                if (NameInput.Text.Length == 0 || DescriptionInput.Text.Length == 0 ||
                    CompoundInput.Text.Length == 0 || CountInput.Text.Length == 0 ||
                    PriceInput.Text.Length == 0 || GramInput.Text.Length == 0)
                {
                    ErrorLabel.Text = "Некоторые данные введены некорректно";
                    ErrorLabel.Visible = true;
                }
                else
                if (objbll.SaveItem(NameInput.Text, DescriptionInput.Text, CompoundInput.Text, CountInput.Text, PriceInput.Text, GramInput.Text, image, ManufacturerComboBox.SelectedItem.ToString()[0].ToString()))
                {
                    Main main = new Main();
                    main.id = "1";
                    main.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ошибка!");
                }
            }
            else
            {
                DB db = new DB();
                MySqlCommand command = new MySqlCommand($"update product set name=@name , description=@description, compound=@compound, counte=@count, price= @price, gram=@gram, id_manufacturer=@id_manufacturer " +
                $"where id_product = {idProduct}", db.getConnection());

                db.openConnection();

                try
                {
                    if (NameInput.Text.Length == 0 || DescriptionInput.Text.Length == 0 ||
                    CompoundInput.Text.Length == 0 || CountInput.Text.Length == 0 ||
                    PriceInput.Text.Length == 0 || GramInput.Text.Length == 0)
                    {
                        ErrorLabel.Text = "Некоторые данные введены некорректно";
                        ErrorLabel.Visible = true;
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@name", NameInput.Text);
                        command.Parameters.AddWithValue("@description", DescriptionInput.Text);
                        command.Parameters.AddWithValue("@compound", CompoundInput.Text);
                        command.Parameters.AddWithValue("@count", CountInput.Text);
                        command.Parameters.AddWithValue("@price", PriceInput.Text);
                        command.Parameters.AddWithValue("@gram", GramInput.Text);
                        command.Parameters.AddWithValue("@id_manufacturer", ManufacturerComboBox.SelectedItem.ToString()[0]);
                        command.ExecuteNonQuery();

                        Main main = new Main();
                        main.id = "1";
                        main.Show();
                        this.Close();
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                db.closeConnection();
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand($"INSERT INTO manufacturer(name, physical_address, legal_address, phone, director) " +
                $"values(@name, @physical_address, @legal_address, @phone, @director)", db.getConnection());

            db.openConnection();

                try
                {
                if (NameManufacturer.Text.Length == 0 || PhysicalAddress.Text.Length == 0 || LegalAddress.Text.Length == 0 || PhoneInput.Text.Length == 0 || DirectrorInput.Text.Length == 0)
                {
                    ErrorLabel2.Text = "Данные введены некорректно";
                    ErrorLabel2.Visible = true;
                }
                else
                {
                    command.Parameters.AddWithValue("@name", NameManufacturer.Text);
                    command.Parameters.AddWithValue("@physical_address", PhysicalAddress.Text);
                    command.Parameters.AddWithValue("@legal_address", LegalAddress.Text);
                    command.Parameters.AddWithValue("@phone", PhoneInput.Text);
                    command.Parameters.AddWithValue("@director", DirectrorInput.Text);
                    command.ExecuteNonQuery();

                    AddedPanel.Controls.Clear();
                    AddedPanel.Controls.Add(ProductPanel);
                    ProductPanel.Visible = true;
                    ProductPanel.Dock = DockStyle.Fill;
                    label1.Text = "Добавить производителя";
                }
                }
                catch
                {
                    MessageBox.Show("Ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            db.closeConnection();
        }

        private void NameManufacturer_Validated(object sender, EventArgs e)
        {

        }

        private void NameManufacturer_TextChanged(object sender, EventArgs e)
        {
            ErrorLabel2.Visible = false;
        }

        private void PhysicalAddress_TextChanged(object sender, EventArgs e)
        {
            ErrorLabel2.Visible = false;
        }

        private void PhoneInput_TextChanged(object sender, EventArgs e)
        {
            ErrorLabel2.Visible = false;
        }

        private void LegalAddress_TextChanged(object sender, EventArgs e)
        {
            ErrorLabel2.Visible = false;
        }

        private void DirectrorInput_TextChanged(object sender, EventArgs e)
        {
            ErrorLabel2.Visible = false;
        }

        private void ManufacturerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void loadInfoProduct()
        {
            DB db = new DB();
            string queryInfo = $"SELECT * FROM product WHERE (id_product = '{idProduct}') ";
            MySqlCommand mySqlCommand = new MySqlCommand(queryInfo, db.getConnection());

            db.openConnection();

            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                NameInput.Text = reader["name"].ToString();
                DescriptionInput.Text = reader["description"].ToString();
                CompoundInput.Text = reader["compound"].ToString();
                CountInput.Text = reader["counte"].ToString();
                PriceInput.Text = reader["price"].ToString();
                GramInput.Text = reader["gram"].ToString();
                ManufacturerComboBox.SelectedIndex = (int)reader["id_manufacturer"]-1;

                
            }
            reader.Close();

            db.closeConnection();
            label3.Visible = false;
            AddPhoto.Visible = false;
        }
    }
}
