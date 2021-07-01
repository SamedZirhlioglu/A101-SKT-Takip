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
    public partial class SKT_Ekle : Form
    {
        public Dictionary<string, string> products = new Dictionary<string, string>();
        public Dictionary<string, float> reList = new Dictionary<string, float>();
        public Product_List productList = new Product_List();
        SKT_List sktList = new SKT_List();

        public SKT_Ekle()
        {
            InitializeComponent();
        }

        private void SKT_Ekle_Load(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string barcode;
            products.TryGetValue(comboBox1.Text, out barcode);
            textBox1.Text = barcode;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null || textBox3.Text == null || dateTimePicker1.Value == null)
            {
                MessageBox.Show("Boş bırakılan alanlar var", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                dataGridView1.Rows.Add(textBox1.Text, textBox3.Text, dateTimePicker1.Text);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                ArrayList product = new ArrayList();
                product.Add(dataGridView1.Rows[i].Cells[0].EditedFormattedValue.ToString());
                product.Add(dataGridView1.Rows[i].Cells[1].EditedFormattedValue.ToString());
                product.Add(dataGridView1.Rows[i].Cells[2].EditedFormattedValue.ToString());

                sktList.Writer(product);
            }
            dataGridView1.Rows.Clear();
        }

        public void GetProductList()
        {
            products.Clear();
            comboBox1.Items.Clear();
            for (int i = 0; i < productList.products.Count; i++)
            {
                ArrayList product = productList.products[i];
                string barcode = (string)product[0];
                string productName = (string)product[1];
                products.Add(productName, barcode);
                reList.Add(product[0].ToString(), float.Parse(product[3].ToString()));
                comboBox1.Items.Add((string)product[1]);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }
    }
}
