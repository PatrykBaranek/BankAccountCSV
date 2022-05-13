using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountCSV
{
    public class User
    {    
        public int Id { get; set; }   
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Pesel { get; set; }
        public string Address { get; set; }

    }

    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Map(m => m.Id).Name("Nr");
            Map(m => m.Name).Name("Imie");
            Map(m => m.Surname).Name("Nazwisko");
            Map(m => m.Pesel).Name("Pesel");
            Map(m => m.Address).Name("Adres");
        }
    }
}
