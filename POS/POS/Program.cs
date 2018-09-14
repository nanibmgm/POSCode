using POS.Service.Client.DataContracts;
using POS.Service.Facade;
using POS.Service.FacadeContracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace POS
{
    class Program
    {
        static void Main(string[] args)
        {
            //To Test are we getting product details.
            IProductFacade productRepos = new ProductFacade();
            var productdto = productRepos.GetProduct("P3");
            productdto.OrderQuantity = 3;
            IList<ProductDTO> list = new List<ProductDTO>();
            list.Add(productdto);
            productdto = productRepos.GetProduct("P1");
            productdto.OrderQuantity = 3;
            list.Add(productdto);
            productdto = productRepos.GetProduct("P2");
            productdto.OrderQuantity = 3.5;
            list.Add(productdto);

            OrderSlip orderSlip = new OrderSlip();
            orderSlip.Items = new List<OrderItem>();
            foreach (var product in list)
            {
                orderSlip.Items.Add(new OrderItem { ProductCode = product.ProductCode, ProductName = product.ProductName, Quantity = product.OrderQuantity, UnitPrice=(double)product.UnitPrice, NettPrice = (double)product.TotalPrice, TotalPrice = product.ActualPrice });
            }

            orderSlip.SavingsOnOrder = orderSlip.Items.Sum(item => item.Saving);
            orderSlip.SubTotal = orderSlip.Items.Sum(item => item.NettPrice);

            Console.WriteLine("---Order Slip---");
            Console.WriteLine("-------------------------");
            Console.WriteLine("ProductCode\tProductName\tQuantity\tUnitPrice\tTotal\t\tSaving\t\tNett");
            foreach (var item in orderSlip.Items)
            {
                Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}\t\t{5}\t\t{6}", item.ProductCode,item.ProductName,item.Quantity,item.UnitPrice,item.TotalPrice,item.Saving,item.NettPrice);
            }
            Console.WriteLine("-------------------------");
            Console.WriteLine("Total : {0}", orderSlip.SubTotal);
            Console.WriteLine("You Have Saved : {0}", orderSlip.SavingsOnOrder);
            Console.WriteLine("-------------------------");
            Console.ReadKey();
            //return orderSlip;
        }
    }
}
