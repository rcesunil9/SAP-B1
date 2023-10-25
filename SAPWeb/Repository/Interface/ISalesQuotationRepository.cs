using CrystalDecisions.ReportAppServer.DataDefModel;
using SAPWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPWeb.Repository.Interface
{
    public interface ISalesQuotationRepository
    {
        SalesDocumentsDefault SAPSalesQuotation(SalesOrderQuotationDocument objModel);
        QuotationListDefault SAPSalesQuotationList(int skip);
        SalesOrderQuotationDocument GetSalesQuotationById(int docEntry);
        SalesDocumentsDefault SAPSalesQuotaionUser(SalesOrderQuotationDocument objModel);
        QuotationListDefault SAPSalesQuotationListUser(string userID,int skip);
        SalesOrderQuotationDocument GetSalesQuotationUserById(int docEntry);
    }
}
