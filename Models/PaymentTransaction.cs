using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcountSearchAndPayment.Models
{
    public class PaymentTransaction
    {
        public int TransactionId { get; set; }
        public int InvoiceId { get; set; }  // Foreign key referencing Invoice
        public decimal PaymentAmount { get; set; }
        public DateTime PaymentDate { get; set; }
        // Other relevant properties...

        // Navigation property to Invoice
        public Invoice Invoice { get; set; }
    }
}