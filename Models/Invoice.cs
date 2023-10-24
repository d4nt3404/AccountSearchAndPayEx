using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AcountSearchAndPayment.Models
{
    public class Invoice
    {
        // This class will include properties like
        // AccountName, InvoiceNumber, AmountDue, etc.

        public int InvoiceId { get; set; }
        public string InvoiceNumber { get; set; }
        public string AccountName { get; set; }
        public decimal AmountDue { get; set; }
        [DisplayFormat(DataFormatString = "{0: MM/dd/yyyy}")] 
        public Nullable<System.DateTime> DueDate { get; set; }
        public bool Paid { get; set; }
        public DateTime? LastPaymentDate { get; set; }

        // Navigation property to PaymentTransaction (if needed)
        public ICollection<PaymentTransaction> PaymentTransactions { get; set; }
    }
}