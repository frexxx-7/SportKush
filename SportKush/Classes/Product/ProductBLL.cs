using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SportKush.Classes.Product
{
    internal class ProductBLL
    {
        public bool SaveItem(string name, string description, string compound, string count, string price, string gram, Image img, string idManufacturer)
        {
            try
            {
                ProductFunc objdal = new ProductFunc();
                return objdal.AddItemsToTable(name, description, compound, count, price, gram, img, idManufacturer);
            }
            catch (Exception e)
            {
                DialogResult result = MessageBox.Show(e.Message.ToString());
                return false;
            }
        }

        public DataTable GetItems(bool isBasket, string idUser, string search)
        {
            try
            {
                ProductFunc objdal = new ProductFunc();
                return objdal.ReadItems(isBasket, idUser, search);
            }
            catch (Exception e)
            {
                DialogResult result = MessageBox.Show(e.Message.ToString());
                return null;
            }
        }
    }
}
