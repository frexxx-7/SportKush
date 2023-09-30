using MySql.Data.MySqlClient;
using SportKush.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace SportKush.Forms
{
    public partial class DetailedProduct : Form
    {
        public string id;
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
        public DetailedProduct()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.id = id;
            main.Show();
            this.Close();
        }

        private void PriceLabel_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void DetailedProduct_Load(object sender, EventArgs e)
        {
            NameLabel.Text = name;
            GramLabel.Text = gram.ToString();
            CountLabel.Text = count.ToString();
            PriceLabel.Text = price.ToString();
            ImagePictureBox.Image = cover;
            CompoundLabel.Text = compound;
            DescriptionLabel.Text = description;
            searchBusketProduct();
        }

        private void CountLabel_Click(object sender, EventArgs e)
        {

        }

        private void InStockLabel_Click(object sender, EventArgs e)
        {

        }

        private void LogInButton_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO basket(id_user, id_product, counte) " +
                "VALUES (@id_user, @id_product, @count)", db.getConnection());

            db.openConnection();
            try
            {
                command.Parameters.AddWithValue("@id_user", id);
                command.Parameters.AddWithValue("@id_product", idProduct);
                command.Parameters.AddWithValue("@count", InBasketNumericUpDown.Value);
                command.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            db.closeConnection();
            InBusketButton.Visible = false;
            InBasketNumericUpDown.Visible= false;
        }
        private void searchBusketProduct()
        {
            DB db = new DB();
            string queryInfo = $"SELECT id_basket, is_bought FROM basket WHERE (id_user = '{id}') AND (id_product= '{idProduct}') ";
            MySqlCommand mySqlCommand = new MySqlCommand(queryInfo, db.getConnection());

            db.openConnection();

            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                if (reader["id_basket"].ToString() != null && (bool)reader["is_bought"]!=true)
                {
                    InBusketButton.Visible = false;
                    InBasketNumericUpDown.Visible= false;
                }
            }
            reader.Close();

            db.closeConnection();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            // Открытие документа
            Word.Application wordApp = new Word.Application();
            Word.Document doc = wordApp.Documents.Open(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Шаблон.docx"));

            // Очистка закладки
            if (doc.Bookmarks.Exists("Name"))
            {
                Word.Range bookmarkRange = doc.Bookmarks["Name"].Range;
                bookmarkRange.Text = "";
            }

            // Запись нового текста в закладку
            if (doc.Bookmarks.Exists("Name"))
            {
                Word.Range bookmarkRange = doc.Bookmarks["Name"].Range;
                bookmarkRange.Text = name;
            }
            // Очистка закладки
            if (doc.Bookmarks.Exists("Description"))
            {
                Word.Range bookmarkRange = doc.Bookmarks["Description"].Range;
                bookmarkRange.Text = "";
            }

            // Запись нового текста в закладку
            if (doc.Bookmarks.Exists("Description"))
            {
                Word.Range bookmarkRange = doc.Bookmarks["Description"].Range;
                bookmarkRange.Text = description;
            }

            // Очистка закладки
            if (doc.Bookmarks.Exists("Compound"))
            {
                Word.Range bookmarkRange = doc.Bookmarks["Compound"].Range;
                bookmarkRange.Text = "";
            }

            // Запись нового текста в закладку
            if (doc.Bookmarks.Exists("Compound"))
            {
                Word.Range bookmarkRange = doc.Bookmarks["Compound"].Range;
                bookmarkRange.Text = compound;
            }

            // Сохранение и закрытие документа
            doc.Save();
            doc.Close();
            Process.Start(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Шаблон.docx"));
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            AddProduct ap = new AddProduct(idProduct.ToString());
            ap.Show();
            this.Close();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
