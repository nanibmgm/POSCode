using POS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BLL.Contracts
{
    public interface IProductBLL
    {
        void Save(Product product);
        void Update(Product product);
        Product GetProduct(string productId);
    }
}
