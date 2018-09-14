using POS.BLL.Contracts;
using POS.Core.Models;
using POS.Data.Repository;
using POS.Data.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BLL
{
    public class ProductBLL : IProductBLL
    {
        IProductRepository productRepository = new ProductRepository();
        public Product GetProduct(string productId)
        {
            return productRepository.GetProduct(productId);
        }

        public void Save(Product product)
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
