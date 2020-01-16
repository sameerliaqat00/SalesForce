using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesForce.Models.Setup
{
    public class GoodTransfer
    {
        public int Id { get; set; }
        public int GoodTransferId { get; set; }
        public string GoodTransferName { get; set; }
        public string GoodTransferPhone { get; set; }
    }
}