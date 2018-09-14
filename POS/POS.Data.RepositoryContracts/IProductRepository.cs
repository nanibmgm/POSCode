using POS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data.RepositoryContracts
{
    public interface IProductRepository
    {
        void Save(Product product);
        void Update(Product product);
        Product GetProduct(string productId);
    }
}
