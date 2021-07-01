using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A101_SKT_Takip
{
    class SKT_List
    {
        public List<ArrayList> sktList = new List<ArrayList>();

        public SKT_List()
        {
            ReadList();
        }

        public void ReadList()
        {
            sktList.Clear();

            string filePath = "skt_list.dll";
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            StreamReader sw = new StreamReader(fs);

            string line = sw.ReadLine();
            while (line != null)
            {
                string[] split = line.Split('~');

                ArrayList skt = new ArrayList();
                skt.Add(split[0]);
                skt.Add(split[1]);
                skt.Add(split[2]);

                sktList.Add(skt);
                line = sw.ReadLine();
            }

            sw.Close();
            fs.Close();
        }

        public void Writer(ArrayList skt)
        {
            string filePath = "skt_list.dll";
            FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine(skt[0].ToString() + "~" + skt[1].ToString() + "~" + skt[2].ToString());
            sw.Flush();

            sw.Close();
            fs.Close();
        }

        public void NewList(List<ArrayList> productList)
        {
            string filePath = "skt_list.dll";
            FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            sw.Close();
            fs.Close();

            for (int i = 0; i < sktList.Count; i++)
            {
                ArrayList skt = sktList[i];

                if (BarcodeFinder(productList, skt[0].ToString())) Writer(skt);
            }

            ReadList();
        }

        bool BarcodeFinder(List<ArrayList> products, string barcode)
        {
            for (int i = 0; i < products.Count; i++)
            {
                ArrayList product = products[i];

                if (product[0].ToString() == barcode) return true;
            }
            return false;
        }
    }
}
