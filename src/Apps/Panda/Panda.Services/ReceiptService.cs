using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Panda.Data;
using Panda.Data.Models;

namespace Panda.Services
{
    public class ReceiptService : IReceiptService
    {
        private readonly PandaDbContext db;
        private readonly IPackageService packageService;

        public ReceiptService(PandaDbContext db,IPackageService packageService)
        {
            this.db = db;
            this.packageService = packageService;
        }
        public Receipt CreateReceipt(string id)
        {
            var package = packageService.GetPackageById(id);
            var receipt = new Receipt
            {
                Fee = (decimal)(package.Weight * 2.67),
                IssuedOn = DateTime.UtcNow,
                RecipientId = package.RecipientId,
                PackageId = package.Id
            };

            db.Receipts.Add(receipt);
            db.SaveChanges();
            return receipt;
        }

        public IQueryable<Receipt> GetAllReceipts()
        {
            var receipts = db.Receipts;
            return receipts;
        }
    }
}
