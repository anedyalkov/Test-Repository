using System;
using System.Collections.Generic;
using System.Text;

namespace Panda.App.ViewModels.Receipts
{
    public class ReceiptViewModel
    {
        public string Id { get; set; }

        public decimal Fee { get; set; }

        public DateTime IssuedOn { get; set; }

        public string RecipientName { get; set; }
    }
}
