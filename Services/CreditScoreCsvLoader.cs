using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using CarInsuranceApi.Data;

namespace CarInsuranceApi.Services
{
    public static class CreditScoreCsvLoader
    {
        public static List<CreditScoreData> LoadFromCsv(string csvPath)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ",",
                HasHeaderRecord = true,
                HeaderValidated = null, 
                MissingFieldFound = null 
            };

            using var reader = new StreamReader(csvPath);
            using var csv = new CsvReader(reader, config);

            var records = csv.GetRecords<CreditScoreData>().ToList();
            return records;
        }
    }
}
