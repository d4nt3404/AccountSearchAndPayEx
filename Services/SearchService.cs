﻿using AcountSearchAndPayment.Models;
using SearchAccountEx.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcountSearchAndPayment.Services
{
    public class SearchService
    {
        private readonly InvoiceDbContext _dbContext;

        public SearchService(InvoiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Invoice> SearchUnpaidInvoices(string accountName)
        {
            return _dbContext.Invoice
                .Where(i => i.AccountName == accountName && i.AmountDue > 0)
                .ToList();
        }

        public Invoice GetInvoiceById(int invoiceId)
        {
            var invoiceFound = _dbContext.Invoice
            .FirstOrDefault(i => i.InvoiceId == invoiceId);
            return invoiceFound;
        }

        public void UpdateInvoice(Invoice invoice, decimal amountPay, bool isTotalPayment)
        {
            var invoiceFound = _dbContext.Invoice
            .FirstOrDefault(i => i.InvoiceId == invoice.InvoiceId);

            if (invoiceFound != null)
            {
                invoiceFound.Paid = isTotalPayment;
                invoiceFound.LastPaymentDate = DateTime.Now;
                invoiceFound.AmountDue -= amountPay;

                _dbContext.SaveChanges(); ; // Save the changes to the database
            }
        }
    }
}