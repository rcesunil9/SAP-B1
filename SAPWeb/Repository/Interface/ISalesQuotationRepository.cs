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
    }
}
