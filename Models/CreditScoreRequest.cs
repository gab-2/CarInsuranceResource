namespace CarInsuranceApi.Models
{
    public class CreditScoreRequest
    {
        public string Age { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string DrivingExperience { get; set; } = string.Empty;
        public string Education { get; set; } = string.Empty;
        public string Income { get; set; } = string.Empty;
        public string VehicleYear { get; set; } = string.Empty;
        public string VehicleType { get; set; } = string.Empty;
        public int AnnualMileage { get; set; }
    }
}
