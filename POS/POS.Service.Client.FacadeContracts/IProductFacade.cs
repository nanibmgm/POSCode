using POS.Service.Client.DataContracts;
using System.Collections.Generic;

namespace POS.Service.FacadeContracts
{
    public interface IProductFacade
    {
        void Save(ProductDTO product);
        void Update(ProductDTO product);
        ProductDTO GetProduct(string productId);
        OrderSlip GenerateOrder(IList<ProductDTO> list);
    }
}
