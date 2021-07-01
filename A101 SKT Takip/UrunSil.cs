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

namespace A101_SKT_Takip
{
    public partial class UrunSil : Form
    {
        Product_List productListClass = new Product_List();

        List<ArrayList> products = new List<ArrayList>();
        List<ArrayList> newList = new List<ArrayList>();

        public UrunSil()
        {
            InitializeComponent();
        }

        private void UrunSil_Load(object sender, EventArgs e)
        {
            FillComboBoxes();
        }

        void FillComboBoxes()
        {
            checkedListBox1.Items.Clear();

            products.Clear();
            products = productListClass.products;

            for (int i = 0; i < products.Count; i++)
            {
                ArrayList product = products[i];
                checkedListBox1.Items.Add(product[0].ToString() + " => " + product[1].ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = checkedListBox1.Items.Count - 1; i >= 0; i--)
            {
                if (checkedListBox1.GetItemChecked(i)) checkedListBox1.Items.RemoveAt(i);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < products.Count; i++)
                {
                    ArrayList product = products[i];

                    if (ProductFinder(product[0].ToString()))
                    {
                        newList.Add(product);
                    }
                }

                SKT_List list = new SKT_List();
                list.NewList(newList);
                productListClass.NewList(newList);
                MessageBox.Show("Silme işlemi başarılı.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Bir hata oluştu! Programı sağlayan kişiye başvurun.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        bool ProductFinder(string barcode)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                string barcode_ = checkedListBox1.Items[i].ToString().Split(' ')[0];
                if (barcode == barcode_) return true;
            }
            return false;
        }
    }
}
