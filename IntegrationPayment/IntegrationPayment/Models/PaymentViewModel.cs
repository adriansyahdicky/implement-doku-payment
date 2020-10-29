using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationPayment.Models
{
    public class PaymentViewModel
    {
        public string Currency { get; set; }
        public string  Amount { get; set; }
        public string Basket { get; set; }
        public string Invoice { get; set; }
        public string SharedKey { get; set; }
        public string mallId { get; set; }
        public string Words { get; set; }
        public string ChainMerchant { get; set; }
    }
}
