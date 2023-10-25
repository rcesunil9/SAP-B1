using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAPWeb.Models
{
    public class PaymentIncoming
    {
        public string CardCode { get; set; }
        public string CashAccount { get; set; }
        public decimal CashSum { get; set; }
        public List<PaymentInvoice> PaymentInvoices { get; set; }
    }
    public class PaymentInvoice
    {
        public int DocEntry { get; set; }
        public decimal SumApplied { get; set; }
        public string InvoiceType { get; set; }
    }
}