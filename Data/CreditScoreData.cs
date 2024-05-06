using CsvHelper.Configuration.Attributes;

namespace CarInsuranceApi.Data
{
    public class CreditScoreData
    {
        [Name("AGE")]
        public string Age { get; set; } = string.Empty;

        [Name("GENDER")]
        public string Gender { get; set; } = string.Empty;

        [Name("DRIVING_EXPERIENCE")]
        public string DrivingExperience { get; set; } = string.Empty;

        [Name("EDUCATION")]
        public string Education { get; set; } = string.Empty;

        [Name("INCOME")]
        public string Income { get; set; } = string.Empty;

        [Name("VEHICLE_YEAR")]
        public string VehicleYear { get; set; } = string.Empty;

        [Name("VEHICLE_TYPE")]
        public string VehicleType { get; set; } = string.Empty;

        [Name("ANNUAL_MILEAGE")]
        public float? AnnualMileage { get; set; }

        [Name("CREDIT_SCORE")]
        public double? CreditScore { get; set; }
    }
}
