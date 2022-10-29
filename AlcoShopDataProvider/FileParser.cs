using AlcoShopCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlcoShopDataProvider
{
    internal class FileParser
    {
        private readonly string path;

        public FileParser(string path)
        {
            this.path = path;
        }

        public List<Product> GetProducts()
        {
            Console.WriteLine();
            Console.WriteLine(" Parsowanie pliku ...");
            var result = new List<Product>();
            var lines = File.ReadAllLines(path);
            foreach (var line in lines)
            {
                if (!string.IsNullOrEmpty(line))
                {
                    var parts = line.Split("\t");
                    if (parts.Length == 5)
                    {
                        result.Add(CreateAlco(parts));
                    }
                }
            }

            Console.WriteLine($" Utworzono {result.Count} alkoholi");
            return result;
        }

        Product CreateAlco(string[] parts)
        {
            var product = new Product
            {
                Id = Guid.NewGuid().ToString(),
                Name = parts[0],
                Capacity = decimal.Parse(parts[1].Replace(".", ",")),
                Type = parts[2],
                Price = decimal.Parse(parts[3].Replace(".", ",")),
                Image = parts[4],
            };

            return product;
        }
    }
}
