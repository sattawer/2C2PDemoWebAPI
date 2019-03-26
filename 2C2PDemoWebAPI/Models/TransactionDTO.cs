using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2C2PDemoWebAPI.Models
{
    public class TransactionDTO
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public Nullable<decimal> amount { get; set; }
        public string currency { get; set; }
        public string status { get; set; }
    }
}