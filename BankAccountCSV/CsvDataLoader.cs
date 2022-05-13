using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountCSV
{
    public class CsvDataLoader<T>
    {
        public static List<T> GetData(string path)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
            };

            using (StreamReader sr = new StreamReader(path))
            using (var csv = new CsvReader(sr, config))
            {
                csv.Context.UnregisterClassMap();

                if (typeof(T) == typeof(Account))
                {                    
                    csv.Context.RegisterClassMap<AccountMap>();
                }

                if (typeof(T) == typeof(User))
                {
                    csv.Context.RegisterClassMap<UserMap>();
                }

                var records = csv.GetRecords<T>().ToList();

                return records;
            }
        }






    }
}
