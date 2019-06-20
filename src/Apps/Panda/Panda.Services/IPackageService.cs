using Panda.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Panda.Services
{
    public interface IPackageService
    {
        Package CreatePackage (string description, double weight, string shippingAddress, string recipientName);

        IQueryable<Package> GetAllPackages(PackageStatus status);

        Package Deliver(string id);

        Package GetPackageById(string id);
    }
}
