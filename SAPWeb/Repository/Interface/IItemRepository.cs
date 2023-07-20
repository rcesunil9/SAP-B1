using SAPWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPWeb.Repository.Interface
{
    internal interface IItemRepository
    {
        ItemDefault GetItem(string code); 
    }
}
