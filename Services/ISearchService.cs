using AcountSearchAndPayment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcountSearchAndPayment.Services
{
    public interface ISearchService
    {
        List<Invoice> SearchUnpaidInvoices(string accountName);
        Invoice GetInvoiceById(int invoiceId);
    }
}
