using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace A101_SKT_Takip
{
    public partial class Urun_Ekle : Form
    {
        Product_List product_List = new Product_List();

        public Urun_Ekle()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null || textBox2.Text == null || textBox3.Text == null || textBox4.Text == null)
            {
                MessageBox.Show("Boş bırakılan alanlar var", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                List<ArrayList> products = product_List.products;
                bool isThereSame = false;

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    ArrayList product = new ArrayList()
                {
                    dataGridView1.Rows[i].Cells[0].EditedFormattedValue.ToString(),
                    dataGridView1.Rows[i].Cells[1].EditedFormattedValue.ToString(),
                    dataGridView1.Rows[i].Cells[2].EditedFormattedValue.ToString(),
                    dataGridView1.Rows[i].Cells[3].EditedFormattedValue.ToString(),
                };
                    products.Add(product);
                }

                for (int i = 0; i < products.Count; i++)
                {
                    ArrayList product = products[i];

                    if (product[0].ToString() == textBox1.Text || product[1].ToString() == textBox2.Text)
                    {
                        MessageBox.Show("Eklemeye çalıştığınız ürün zaten mevcut!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        isThereSame = true;
                        break;
                    }
                }

                if (!isThereSame)
                    dataGridView1.Rows.Add(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                ArrayList product = new ArrayList();
                product.Add(dataGridView1.Rows[i].Cells[0].EditedFormattedValue.ToString());
                product.Add(dataGridView1.Rows[i].Cells[1].EditedFormattedValue.ToString());
                product.Add(dataGridView1.Rows[i].Cells[2].EditedFormattedValue.ToString());
                product.Add(dataGridView1.Rows[i].Cells[3].EditedFormattedValue.ToString());

                product_List.Writer(product);
            }
            dataGridView1.Rows.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Urun_Ekle_Load(object sender, EventArgs e)
        {

        }
    }
}
