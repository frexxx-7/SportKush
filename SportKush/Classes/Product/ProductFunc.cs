using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SportKush.Classes.Product
{
    internal class ProductFunc
    {
        public bool AddItemsToTable(string name, string description, string compound, string count, string price, string gram, Image img, string idManufacturer)
        {
            DB db = new DB();

            string query = "INSERT INTO product(name, description, compound, counte, price, gram, cover, id_manufacturer) " +
                "VALUES (@name, @description, @compound, @count, @price, @gram, @cover, @id_manufacturer)";
            db.openConnection();
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, db.getConnection()))
                {
                    if (name == null || description == null || compound == null || count == null || price == null || gram == null)
                    {
                        MessageBox.Show("Вы не ввели данные", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@description", description);
                        cmd.Parameters.AddWithValue("@compound", compound);
                        cmd.Parameters.AddWithValue("@count", count);
                        cmd.Parameters.AddWithValue("@price", price);
                        cmd.Parameters.AddWithValue("@gram", gram);
                        MemoryStream ms = new MemoryStream();
                        if (img != null)
                        {
                            img.Save(ms, img.RawFormat);
                        }
                        cmd.Parameters.AddWithValue("@cover" , ms.Length != 0 ? ms.ToArray() : null);
                        cmd.Parameters.AddWithValue("@id_manufacturer" , idManufacturer);
                        cmd.ExecuteNonQuery();
                        db.closeConnection();
                    }
                }
                return true;
            }
            catch
            {
                throw;
            }
        }

        public DataTable ReadItems(bool isBasket, string idUser, string search)
        {
            DB db = new DB();

            db.openConnection();
            string query =
                !isBasket ?
                $"SELECT * FROM product where name like '{search}%' ORDER BY id_product DESC "
                :
                $"SELECT * FROM product " +
                $"  WHERE id_product in (SELECT id_product from basket" +
                $"      WHERE id_user = {idUser} AND is_bought=false)";
                ;
                ;
            MySqlCommand cmd = new MySqlCommand(query, db.getConnection());
            try
            {
                using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    return dt;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
