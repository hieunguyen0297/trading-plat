using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradingPlat.Models
{
    public class Account
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public decimal Balance { get; set; }

        public UserModel User { get; set; }
    }
}
