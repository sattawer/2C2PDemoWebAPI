using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2C2PDemoWebAPI.Models
{
    public class CustomerDTO
    {
        public decimal customerID { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string mobile { get; set; }
        public List<TransactionDTO> transactions { get; set; }
    }
}