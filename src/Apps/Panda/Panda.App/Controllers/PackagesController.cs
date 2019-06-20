using Panda.App.BindingModels.Packages;
using Panda.App.ViewModels.Packages;
using Panda.Data.Models;
using Panda.Services;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Panda.App.Controllers
{
    public class PackagesController: Controller
    {

        private readonly IPackageService packageService;
        private readonly IUserService userService;
        private readonly IReceiptService receiptService;

        public PackagesController(IPackageService packageService, IUserService userService, IReceiptService receiptService)
        {
            this.packageService = packageService;
            this.userService = userService;
            this.receiptService = receiptService;
        }
        [Authorize]
        public IActionResult Create()
        {
            var userNames = userService.GetUsernames();
            return this.View(userNames);
        }
        [HttpPost]
        [Authorize]
        public IActionResult Create(PackageCreateBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/Packages/Create");
            }
            var package = this.packageService.CreatePackage(model.Description, model.Weight, model.ShippingAddress, model.RecipientName);
            return this.Redirect("/Packages/Pending");
        }

        [Authorize]
        public IActionResult Pending()
        {
            var packages = packageService.GetAllPackages(PackageStatus.Pending)
                .Select(p => new PackageViewModel
                {
                    Id = p.Id,
                    Description = p.Description,
                    Weight = p.Weight,
                    ShippingAddress = p.ShippingAddress,
                    RecipientName = p.Recipient.Username
                }).ToList();
            return this.View(packages);
        }

        [Authorize]
        public IActionResult Delivered()
        {
            var packages = packageService.GetAllPackages(PackageStatus.Delivered)
                .Select(p => new PackageViewModel
                {
                    Id = p.Id,
                    Description = p.Description,
                    Weight = p.Weight,
                    ShippingAddress = p.ShippingAddress,
                    RecipientName = p.Recipient.Username
                }).ToList();

            return this.View(packages);
        }

        [Authorize]
        public IActionResult Deliver(string id)
        {
            packageService.Deliver(id);
            receiptService.CreateReceipt(id);
                
            return this.Redirect("/Packages/Delivered"); ;
        }
    }
}
