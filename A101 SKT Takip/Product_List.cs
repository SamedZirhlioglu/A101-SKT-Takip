using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A101_SKT_Takip
{
    public class Product_List
    {
        public List<ArrayList> products = new List<ArrayList>();
        public Dictionary<string, string> productList = new Dictionary<string, string>();
        public Dictionary<string, string> productListReversed = new Dictionary<string, string>();

        public Product_List()
        {
            ReadList();
        }

        public void ReadList()
        {
            products.Clear();
            productList.Clear();
            productListReversed.Clear();

            string filePath = "product_list.dll";
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            StreamReader sw = new StreamReader(fs);

            string line = sw.ReadLine();
            while (line != null)
            {
                string[] split = line.Split('~');

                ArrayList product = new ArrayList();
                product.Add(split[0]);
                product.Add(split[1]);
                product.Add(split[2]);
                product.Add(split[3]);

                products.Add(product);
                productList.Add(split[0], split[1]);
                productListReversed.Add(split[1], split[0]);
                line = sw.ReadLine();
            }

            sw.Close();
            fs.Close();
        }

        public void Writer(ArrayList product)
        {
            string filePath = "product_list.dll";
            FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine(product[0].ToString() + "~" + product[1].ToString() + "~" + product[2].ToString() + "~" + product[3].ToString());
            sw.Flush();

            sw.Close();
            fs.Close();
        }

        public void NewList(List<ArrayList> products_)
        {
            string filePath = "product_list.dll";
            FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            sw.Close();
            fs.Close();

            for (int i = 0; i < products_.Count; i++)
            {
                ArrayList product = products_[i];
                Writer(product);
            }
            ReadList();
        }
    }
}
