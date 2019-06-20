using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Panda.Data.Models
{
    public class User
    {
        public User()
        {
            Packages = new List<Package>();
            Receipts = new List<Receipt>();
        }

        public string Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        [MaxLength(20)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public List<Package> Packages { get; set; }
        public List<Receipt> Receipts { get; set; }
    }
}
