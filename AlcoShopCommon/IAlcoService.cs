using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlcoShopCommon
{
    public interface IAlcoService
    {
        IEnumerable<Product> GetRandomProducts();
        IEnumerable<Product> GetProductsByName(string name);
        IEnumerable<Product> GetProductsByCapacity(decimal min, decimal max);
        IEnumerable<Product> GetProductsByPrice(decimal min, decimal max);
        IEnumerable<Product> GetProductsByType(string type);
        IEnumerable<string> GetAlcoTypes();
    }
}
