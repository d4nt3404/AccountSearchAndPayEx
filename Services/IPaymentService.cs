using AcountSearchAndPayment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcountSearchAndPayment.Services
{
    public interface IPaymentService
    {
        void AddPaymentTransaction(PaymentTransaction paymentTransaction);
        void UpdateInvoice(Invoice invoice, decimal amountPay, bool isTotalPayment);
        decimal CalculateTotalPayment(string accountName);
    }
}
