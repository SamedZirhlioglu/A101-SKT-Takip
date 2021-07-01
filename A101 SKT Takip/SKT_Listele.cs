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
    public partial class SKT_Listele : Form
    {
        List<ArrayList> sktList = new List<ArrayList>();
        List<ArrayList> productList = new List<ArrayList>();
        Dictionary<string, float> reList = new Dictionary<string, float>();
        Dictionary<string, string> products = new Dictionary<string, string>();

        public SKT_Listele()
        {
            InitializeComponent();
        }

        private void SKT_Listele_Load(object sender, EventArgs e)
        {
            GetProducts();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            GetProducts();
        }

        void GetProducts()
        {
            products.Clear();
            productList.Clear();
            products = new Product_List().productList;
            productList = new Product_List().products;

            reList.Clear();
            for (int i = 0; i < productList.Count; i++)
                reList.Add(productList[i][0].ToString(), float.Parse(productList[i][3].ToString()));

            sktList.Clear();
            sktList = new SKT_List().sktList;

            GetTables();
        }

        void GetTables()
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            DateTime selectorDate = dateTimePicker1.Value;
            selectorDate = DateTime.Parse(selectorDate.ToShortDateString());

            for (int i = 0; i < sktList.Count; i++)
            {
                ArrayList skt = sktList[i];

                DateTime date = DateTime.Parse(skt[2].ToString());
                float time;
                reList.TryGetValue(skt[0].ToString(), out time);

                if (time > 1) date = date.AddDays(-time);
                date = DateTime.Parse(date.ToShortDateString());

                string productName;
                products.TryGetValue(skt[0].ToString(), out productName);

                if ((date - selectorDate).TotalDays == 1)
                {
                    dataGridView1.Rows.Add(skt[0].ToString(), productName, skt[1].ToString(), skt[2].ToString());
                }
                else if ((date - selectorDate).TotalDays == 7)
                {
                    dataGridView2.Rows.Add(skt[0].ToString(), productName, skt[1].ToString(), skt[2].ToString());
                }
            }
        }
    }
}
