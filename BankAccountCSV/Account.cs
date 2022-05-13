using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountCSV
{
    public class Account
    {
        public string AccountId { get; set; }
        public int UserId { get; set; }
        public string Currency { get; set; }
        public decimal Balance { get; set; }
        public string Blockade { get; set; }

    }

    public class AccountMap : ClassMap<Account>
    {
        public AccountMap()
        {
            Map(m => m.AccountId).Name("NrKonta");
            Map(m => m.UserId).Name("Uzytkownik");
            Map(m => m.Currency).Name("Waluta");
            Map(m => m.Balance).Name("Saldo");
            Map(m => m.Blockade).Name("Blokada");
        }
    }
}