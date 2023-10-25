using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAPWeb.Models;

namespace SAPWeb.Repository.Interface
{
    public interface IARInvoiceRepository
    {
        SalesDocumentsDefault SAPARInvoiceInsertUpdate(SalesOrderQuotationDocument objModel);
        QuotationListDefault SAPARInvoiceList(int skip);
        SalesOrderQuotationDocument GetARInvoiceById(int docEntry);
        SalesDocumentsDefault CancelInvoice(int docEntry);

        SalesDocumentsDefault SAPARInvoiceInsertUpdateUser(SalesOrderQuotationDocument objModel);
        QuotationListDefault SAPARInvoiceListUser(string userID, int skip);
        SalesOrderQuotationDocument GetARInvoiceUserById(int docEntry);
    }
}
