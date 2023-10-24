using AcountSearchAndPayment.Models;
using AcountSearchAndPayment.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;

namespace AcountSearchAndPayment.Controllers
{
    public class InvoiceController : Controller
    {
        public InvoiceController()
        {
            // Parameterless constructor
        }

        private readonly SearchService _searchService;
        private readonly PaymentService _paymentService;

        public InvoiceController(SearchService searchService, PaymentService paymentService)
        {
            _searchService = searchService;
            _paymentService = paymentService;
        }

        // GET: Invoice
        public ActionResult SearchForm()
        {
            return View();
        }

        // GET: Search unpaid invoices by account name
        [HttpGet]
        public ActionResult UnpaidInvoices(string accountName)
        {
            var invoice = _searchService.SearchUnpaidInvoices(accountName);

            return View(invoice);
        }

        public ActionResult PayInvoice(int invoiceId)
        {
            // Retrieve invoice and payment information
            var invoice = _searchService.GetInvoiceById(invoiceId);
            var paymentTransaction = new PaymentTransaction();

            // Creates a ViewModel that combines invoice data and payment information
            var viewModel = new PayInvoiceViewModel
            {
                Invoice = invoice,
                PaymentTransaction = paymentTransaction
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult RegisterPayment(PayInvoiceViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // 1. Record the payment in the Payment Transaction table
                    var paymentTransaction = new PaymentTransaction
                {
                    InvoiceId = viewModel.Invoice.InvoiceId,
                    PaymentAmount = viewModel.PaymentTransaction.PaymentAmount,
                    PaymentDate = DateTime.Now
                };
                _paymentService.AddPaymentTransaction(paymentTransaction);

                // 2. Update the Invoice table

                    var invoice = _searchService.GetInvoiceById(viewModel.Invoice.InvoiceId);
                if(viewModel.IsTotalPayment)
                {
                   viewModel.PaymentTransaction.PaymentAmount = viewModel.Invoice.AmountDue;
                }
                    _searchService.UpdateInvoice(invoice, viewModel.PaymentTransaction.PaymentAmount, viewModel.IsTotalPayment);
            }
            return RedirectToAction("UnpaidInvoices");
        }

        // GET: Display a payment success page
        [HttpGet]
        public ActionResult PaymentSuccess()
        {
            return View();
        }

        // GET: Invoice/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Invoice/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Invoice/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Invoice/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Invoice/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Invoice/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Invoice/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
