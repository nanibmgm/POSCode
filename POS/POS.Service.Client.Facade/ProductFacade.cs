using AutoMapper;
using POS.BLL;
using POS.BLL.Contracts;
using POS.Core.Models;
using POS.Service.Client.DataContracts;
using POS.Service.FacadeContracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace POS.Service.Facade
{
    public class ProductFacade : IProductFacade
    {
        IProductBLL productBLL = new ProductBLL();
        //IMapper mapper;
        public ProductFacade()
        {

        }
        public ProductDTO GetProduct(string productId)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Product, ProductDTO>();
            });
            var mapper = config.CreateMapper();
            Product product =  productBLL.GetProduct(productId);
            ProductDTO dto= mapper.Map<Product, ProductDTO>(product);
            return dto;
        }

        public OrderSlip GenerateOrder(IList<ProductDTO> list)
        {
            OrderSlip orderSlip = new OrderSlip();
            orderSlip.Items = new List<OrderItem>();
            foreach (var product in list)
            {
                orderSlip.Items.Add(new OrderItem { ProductCode = product.ProductCode, ProductName = product.ProductName, Quantity = product.OrderQuantity, UnitPrice = (double)product.UnitPrice, NettPrice = (double)product.TotalPrice, TotalPrice = product.ActualPrice });
            }
            orderSlip.SavingsOnOrder = orderSlip.Items.Sum(item => Convert.ToInt32(item.Saving));
            orderSlip.SubTotal = orderSlip.Items.Sum(item => Convert.ToInt32(item.NettPrice));
            return orderSlip;
        }

        public void Save(ProductDTO product)
        {
            throw new NotImplementedException();
        }

        public void Update(ProductDTO product)
        {
            throw new NotImplementedException();
        }
    }
}
