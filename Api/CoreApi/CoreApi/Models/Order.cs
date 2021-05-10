using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApi.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string Vessel_name { get; set; }
        public string Shipyard { get; set; }
        public string Owner { get; set; }
        public string HullNr { get; set; }
        public int SalesId { get; set; }
        public string Buyer { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string DeliveryIsClose { get; set; }
        public string OrderNumber { get; set; }
        public List<Part> PartsOrdered { get; set; }
        public Order()
        {

        }
    }
}
