using SAPWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPWeb.Repository.Interface
{
    internal interface ICustomerRepository
    {
        CustomerDefault GetCustomer(string q);
        ContactPersonDefault GetContactPerson(string code);
        AddressDetailDefault GetBillToId(string code);
        AddressDetailDefault GetShipToId(string code);
        CommonSalesQuotation GetSalesQuotation(string code);
    }
}
