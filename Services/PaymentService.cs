using AcountSearchAndPayment.Models;
using SearchAccountEx.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcountSearchAndPayment.Services
{
    public class PaymentService
    {
        //  including the method to calculate the total payment and create a transaction record.
        private readonly InvoiceDbContext _context;

        public PaymentService(InvoiceDbContext context)
        {
            _context = context;
        }

        // Method that create a transaction record
        public void AddPaymentTransaction(PaymentTransaction paymentTransaction) // TODO ---
        {
            // Create a new payment transaction
            var payment = new PaymentTransaction
            { 
                InvoiceId = paymentTransaction.InvoiceId,
                PaymentAmount = paymentTransaction.PaymentAmount,
                PaymentDate = DateTime.Now
            };

            _context.PaymentTransaction.Add(payment);
            _context.SaveChanges();
        }

        // Method to calculate the total payment TODO
        private decimal CalculateTotalPayment(string accountName)
        {
            var unpaidInvoices = _context.Invoice
                .Where(i => i.AccountName == accountName && i.AmountDue > 0)
                .ToList();

            decimal totalPayment = unpaidInvoices.Sum(i => i.AmountDue);
            return totalPayment;
        }
    }
}