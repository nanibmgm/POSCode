using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service.Client.DataContracts
{
    [DataContract]
    public class OrderItem
    {
        [DataMember(Name = "ProductCode")]
        public string ProductCode { get; set; }
        [DataMember(Name = "ProductName")]
        public string ProductName { get; set; }
        [DataMember(Name = "Quantity")]
        public double Quantity { get; set; }
        [DataMember(Name = "UnitPrice")]
        public double UnitPrice { get; set; }
        [DataMember(Name = "TotalPrice")]
        public double TotalPrice { get; set; }
        [DataMember(Name = "Saving")]
        public double Saving { get { return TotalPrice - NettPrice; } set { } }
        [DataMember(Name = "NettPrice")]
        public double NettPrice { get; set; }
    }

    [DataContract]
    public class OrderSlip
    {
        [DataMember(Name = "OrderItems")]
        public IList<OrderItem> Items { get; set; }
        [DataMember(Name = "SubTotal")]
        public double SubTotal { get; set; }
        [DataMember(Name = "SavingsOnOrder")]
        public double SavingsOnOrder { get; set; }
    }

    [DataContract]
    public class OrderRequest
    {
        [DataMember(Name = "ProductCode")]
        public string ProductCode { get; set; }
        [DataMember(Name = "Quantity")]
        public int Quantity { get; set; }
    }
}
