using AlcoShopCommon;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlcoShopDataProvider
{
    internal class FileWriter
    {
        private readonly string path;
        private readonly List<Product> products;

        public FileWriter(string path, List<Product> products)
        {
            this.path = path;
            this.products = products;
        }

        public void SaveFile()
        {
            Console.WriteLine();
            Console.WriteLine(" Zapis pliku na dysku ...");
            var json = JsonConvert.SerializeObject(products);
            File.WriteAllText(path, json);
            Console.WriteLine($" Plik zapisano w {path}");
        }
    }
}
