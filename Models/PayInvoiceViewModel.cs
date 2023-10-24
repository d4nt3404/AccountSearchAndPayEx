using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcountSearchAndPayment.Models
{
    public class PayInvoiceViewModel
    {
        public Invoice Invoice { get; set; }
        public PaymentTransaction PaymentTransaction { get; set; }
    }
}