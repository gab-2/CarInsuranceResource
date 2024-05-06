using System.Collections.Generic;
using System.Linq;
using CarInsuranceApi.Data;
using CarInsuranceApi.Models;

namespace CarInsuranceApi.Services
{
    public class CreditScoreService
    {
        private readonly List<CreditScoreData> _creditScoreData;

        public CreditScoreService(List<CreditScoreData> creditScoreData)
        {
            _creditScoreData = creditScoreData;
        }

        public double? GetCreditScore(CreditScoreRequest request)
        {
            var match = _creditScoreData.FirstOrDefault(data =>
                data.Age == request.Age &&
                data.Gender == request.Gender &&
                data.DrivingExperience == request.DrivingExperience &&
                data.Education == request.Education &&
                data.Income == request.Income &&
                data.VehicleYear == request.VehicleYear &&
                data.VehicleType == request.VehicleType &&
                data.AnnualMileage == request.AnnualMileage);

            return (double?)(match?.CreditScore);
        }
    }
}
