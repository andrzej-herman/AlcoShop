using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AlcoShopCommon
{
    public class AlcoService : IAlcoService
    {
        public AlcoService()
        {
            GenarateProductsFromJson();
            Random = new Random();
        }

        private IEnumerable<Product> AllProducts { get; set; }
        private Random Random { get; set; }

        private void GenarateProductsFromJson()
        {
            var json = File.ReadAllText("wwwroot\\data\\alco.json");
            AllProducts = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);    
        }

        public IEnumerable<Product> GetRandomProducts()
        {
            return AllProducts.OrderBy(a => Random.Next()).Take(6);
        }

        public IEnumerable<string> GetAlcoTypes()
        {
            return AllProducts.Select(a => a.Type).Distinct().OrderBy(c => c);
        }

        public IEnumerable<Product> GetProductsByCapacity(decimal min, decimal max)
        {
            return AllProducts.Where(a => a.Capacity >= min && a.Capacity <= max);
        }

        public IEnumerable<Product> GetProductsByName(string name)
        {
            return AllProducts.Where(a => a.Name.ToLower().Contains(name.ToLower()));
        }

        public IEnumerable<Product> GetProductsByPrice(decimal min, decimal max)
        {
            return AllProducts.Where(a => a.Price >= min && a.Price <= max);
        }

        public IEnumerable<Product> GetProductsByType(string type)
        {
            return AllProducts.Where(a => a.Type == type);
        }


    }
}
