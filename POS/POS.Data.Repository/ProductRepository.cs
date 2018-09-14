using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Core.Models;
using POS.Data.RepositoryContracts;

namespace POS.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        public Product GetProduct(string productCode)
        {
            try
            {
                using (var context = new POSEntities())
                {
                    Product _product = context.Products.Where(p => p.productCode.Equals(productCode)).FirstOrDefault();
                    return _product;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Save(Product product)
        {
            try
            {
                using (var context = new POSEntities())
                {
                    Product Product = new Product
                    {
                        productCode = product.productCode,
                        productName = product.productName,
                        unitPrice = product.unitPrice,
                        buyQuantity = product.buyQuantity,
                        discount = product.discount,
                        discountType = product.discountType,
                        getQuantity = product.getQuantity
                    };
                    context.Products.Add(Product);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Product product)
        {
            try
            {
                using (var context = new POSEntities())
                {
                    Product _product = context.Products.Where(p => p.productCode.Equals(product.productCode)).FirstOrDefault();
                    _product.productCode = product.productCode;
                    _product.productName = product.productName;
                    _product.unitPrice = product.unitPrice;
                    _product.buyQuantity = product.buyQuantity;
                    _product.discount = product.discount;
                    _product.discountType = product.discountType;
                    _product.getQuantity = product.getQuantity;

                    context.Products.Add(_product);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
