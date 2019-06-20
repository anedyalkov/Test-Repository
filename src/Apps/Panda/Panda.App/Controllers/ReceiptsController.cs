using Panda.App.ViewModels.Receipts;
using Panda.Data.Models;
using Panda.Services;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Panda.App.Controllers
{
    public class ReceiptsController : Controller
    {
        private readonly IPackageService packageService;
        private readonly IReceiptService receiptService;

        public ReceiptsController(IPackageService packageService, IReceiptService receiptService)
        {
            this.packageService = packageService;
            this.receiptService = receiptService;
        }

        [Authorize]
        public IActionResult Index()
        {
            var receipts = receiptService.GetAllReceipts()
                .Select(r => new ReceiptViewModel
                {
                    Id = r.Id,
                    Fee = r.Fee,
                    IssuedOn = r.IssuedOn,
                    RecipientName = r.Recipient.Username
                }).ToList();
            return this.View(receipts);
        }
    }
}
