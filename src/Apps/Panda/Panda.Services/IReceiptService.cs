using Panda.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Panda.Services
{
    public interface IReceiptService
    {
        Receipt CreateReceipt(string id);
        IQueryable<Receipt> GetAllReceipts();
    }
}
