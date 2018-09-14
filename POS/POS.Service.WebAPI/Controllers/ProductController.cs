using POS.Service.Client.DataContracts;
using POS.Service.Facade;
using POS.Service.FacadeContracts;
using System.Collections.Generic;
using System.Web.Http;

namespace POS.Service.WebAPI.Controllers
{
    public class ProductController : ApiController
    {
        IProductFacade productFacade;  
        public ProductController()
        {
            productFacade = new ProductFacade();
        }

        [HttpGet]
        public ProductDTO GetProduct(string productId)
        {
            return productFacade.GetProduct(productId);
        }

        [HttpPost]
        public OrderSlip GenerateOrder(IList<ProductDTO> list)
        {
            return productFacade.GenerateOrder(list);
        }
    }
}
