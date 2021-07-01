using System;
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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Urun_Ekle urun_ = new Urun_Ekle();
            urun_.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SKT_Ekle sKT = new SKT_Ekle();
            sKT.GetProductList();
            sKT.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SKT_Listele listele = new SKT_Listele();
            listele.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UrunSil urunSil = new UrunSil();
            urunSil.Show();
        }
    }
}
