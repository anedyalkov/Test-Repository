using Microsoft.EntityFrameworkCore;
using Panda.Data;
using Panda.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Panda.Services
{
    public class PackageService : IPackageService
    {
        private readonly PandaDbContext db;

        public PackageService(PandaDbContext db)
        {
            this.db = db;
        }

        public Package CreatePackage(string description, double weight, string shippingAddress, string recipientName)
        {
            var recipient = db.Users.Where(u => u.Username == recipientName).FirstOrDefault();

            var package = new Package
            {
                Description = description,
                Weight = weight,
                Status = PackageStatus.Pending,
                ShippingAddress = shippingAddress,
                Recipient = recipient
            };
            db.Packages.Add(package);
            db.SaveChanges();
            return package;
        }

        public Package Deliver(string id)
        {
            var packageToDeliver = db.Packages.FirstOrDefault(p => p.Id == id);

            if (packageToDeliver == null)
            {
                return null;
            }
            packageToDeliver.Status = PackageStatus.Delivered;

            this.db.Update(packageToDeliver);
            this.db.SaveChanges();
            return packageToDeliver;
        }

        public IQueryable<Package> GetAllPackages(PackageStatus status)
        {
            var packages = db.Packages.Where(p => p.Status == status);
            return packages;
        }

        public Package GetPackageById(string id)
        {
            var package = db.Packages
                .FirstOrDefault(p => p.Id == id);
            return package;
        }
    }
}
