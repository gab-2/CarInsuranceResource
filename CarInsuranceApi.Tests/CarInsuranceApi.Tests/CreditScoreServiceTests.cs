using System.Collections.Generic;
using CarInsuranceApi.Data;
using CarInsuranceApi.Models;
using CarInsuranceApi.Services;
using FluentAssertions;
using Xunit;

namespace CarInsuranceApi.Tests
{
    public class CreditScoreServiceTests
    {
        private readonly CreditScoreService _service;

        public CreditScoreServiceTests()
        {
            var creditScoreData = new List<CreditScoreData>
            {
                new CreditScoreData
                {
                    Age = "16-25",
                    Gender = "male",
                    DrivingExperience = "0-9y",
                    Education = "none",
                    Income = "poverty",
                    VehicleYear = "before 2015",
                    VehicleType = "sedan",
                    AnnualMileage = 16000,
                    CreditScore = (double?)3577.571170184620m
                },
                new CreditScoreData
                {
                    Age = "65+",
                    Gender = "female",
                    DrivingExperience = "0-9y",
                    Education = "high school",
                    Income = "upper class",
                    VehicleYear = "after 2015",
                    VehicleType = "sedan",
                    AnnualMileage = 12000,
                    CreditScore = (double?)629.027313918201m
                }
            };

            _service = new CreditScoreService(creditScoreData);
        }

        [Fact]
        public void GetCreditScore_ShouldReturn_CorrectScore()
        {
            var request = new CreditScoreRequest
            {
                Age = "16-25",
                Gender = "male",
                DrivingExperience = "0-9y",
                Education = "none",
                Income = "poverty",
                VehicleYear = "before 2015",
                VehicleType = "sedan",
                AnnualMileage = 16000
            };

            var result = _service.GetCreditScore(request);

            result.Should().Be((double)3577.571170184620m);
        }

        [Fact]
        public void GetCreditScore_ShouldReturn_NullForUnknownData()
        {
            var request = new CreditScoreRequest
            {
                Age = "40-64",
                Gender = "male",
                DrivingExperience = "0-9y",
                Education = "none",
                Income = "poverty",
                VehicleYear = "before 2015",
                VehicleType = "sedan",
                AnnualMileage = 16000
            };

            var result = _service.GetCreditScore(request);

            result.Should().BeNull();
        }

        [Fact]
        public void GetCreditScore_ShouldReturn_CorrectScoreWithDifferentEducation()
        {
            var request = new CreditScoreRequest
            {
                Age = "65+",
                Gender = "female",
                DrivingExperience = "0-9y",
                Education = "high school",
                Income = "upper class",
                VehicleYear = "after 2015",
                VehicleType = "sedan",
                AnnualMileage = 12000
            };

            var result = _service.GetCreditScore(request);

            result.Should().Be((double)629.027313918201m);
        }

        [Fact]
        public void GetCreditScore_ShouldReturn_Null_WhenSomeValuesAreNull()
        {
            var request = new CreditScoreRequest
            {
                Age = "16-25",
                Gender = "male",
                DrivingExperience = null,
                Education = "none",
                Income = "poverty",
                VehicleYear = "before 2015",
                VehicleType = "sedan",
                AnnualMileage = 16000
            };

            var result = _service.GetCreditScore(request);

            result.Should().BeNull();
        }

        [Fact]
        public void GetCreditScore_ShouldReturn_Null_ForInvalidValues()
        {
            var request = new CreditScoreRequest
            {
                Age = "invalid-age",
                Gender = "unknown-gender",
                DrivingExperience = "invalid-experience",
                Education = "unknown-education",
                Income = "invalid-income",
                VehicleYear = "unknown-year",
                VehicleType = "unknown-type",
                AnnualMileage = 1000000
            };

            var result = _service.GetCreditScore(request);

            result.Should().BeNull();
        }
    }
}
