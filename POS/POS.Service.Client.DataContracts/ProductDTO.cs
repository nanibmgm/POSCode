using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service.Client.DataContracts
{
    [DataContract(Name = "Product")]
    public class ProductDTO : BaseDTO
    {
        [DataMember(Name = "ProductId")]
        public int ProductPK { get; set; }

        [DataMember(Name = "ProductCode")]
        public string ProductCode { get; set; }

        [DataMember(Name = "ProductName")]
        public string ProductName { get; set; }

        [DataMember(Name = "UnitPrice")]
        public double? UnitPrice { get; set; }

        [DataMember(Name = "Discount")]
        public double? Discount { get; set; }

        [DataMember(Name = "BuyQuantity")]
        public int? BuyQuantity { get; set; }

        [DataMember(Name = "GetQuantity")]
        public int? GetQuantity { get; set; }

        [DataMember(Name = "DiscountType")]
        public int? DiscountType { get; set; }

        public double OrderQuantity { get; set; }
        public double? TotalPrice
        {
            get
            {
                if (DiscountType == 1) // Flat Discount Rate
                {
                    double? total = (UnitPrice * OrderQuantity);
                    return total - (total * Discount / 100);
                }
                else if (DiscountType == 2)//Buy X Get Y
                {
                    if (OrderQuantity >= BuyQuantity)
                    {
                        double nouToBill = 0;
                        double _LocalOrderQuantity = OrderQuantity;
                        while (_LocalOrderQuantity > BuyQuantity)
                        {
                            nouToBill = (double)(nouToBill + BuyQuantity);
                            _LocalOrderQuantity = (double)(_LocalOrderQuantity - (BuyQuantity + GetQuantity));

                        }
                        if (_LocalOrderQuantity > 0)
                            nouToBill = (double)(nouToBill + _LocalOrderQuantity);
                        return nouToBill * UnitPrice;
                    }
                    return (UnitPrice * OrderQuantity);
                }
                else //If no disount
                    return (UnitPrice * OrderQuantity);
            }
            set { }
        }

        public double ActualPrice
        {
            get { return (double)(OrderQuantity * UnitPrice); }
            set { }
        }

    }
}
