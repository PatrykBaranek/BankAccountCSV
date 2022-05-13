using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountCSV
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public string AccountId { get; set; }
        public decimal Balance { get; set; }
        public decimal Operation { get; set; }
        
        public TransactionType TransactionType { get; set; }
    }

    
}
