using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Policy_Management_System_API;
namespace Testing.Mock
{
    static class PolicyMock
    {
        public static PolicyDto CreateValidPolicy()
        {
            return new PolicyDto
            {

                PolicyId = 1,
                Title = "DEW",
                Description = "Personal insurance",
                StartDate = new DateTime(2020, 09, 03),
                EndDate = new DateTime(2023, 09, 03),
                InsuredAmount = 100000,
                InsuredName = "Barney",
                InsuredHolderAge = 25,
                PolicyTypeId = 2,
                CoverageId = 1,
                VehicleDetailId=1,
                VehicleModel="dbsc",
                VehicleNumber="TN 67f 7890",
                HouseDetailId = null,
                HouseAddress = null,
                AssetValue = null,
                IsActive = true

            };
        }
        public static PolicyDto CreateInValidPolicy()
        {
            return new PolicyDto
            {

                PolicyId = 1,
                Title = "DEW",
                Description = "Personal insurance",
                StartDate = new DateTime(2020, 09, 03),
                EndDate = new DateTime(2020, 09, 03),
                InsuredAmount = 100000,
                InsuredName = "Barney",
                InsuredHolderAge = 25,
                PolicyTypeId = 1,
                CoverageId = 1,
                IsActive = true

            };
        }
        public static List<Policy> GetAllPolicies()
        {
            return new List<Policy>()
            {
                new Policy(){
                    PolicyId= 1,
                    Title="DEW",
                    Description="Home insurance for own home",
                    StartDate=new DateTime(2020,09,03),
                    EndDate=new DateTime(2023,09,03),
                    InsuredAmount=100000,
                    InsuredName="Barney",
                    InsuredHolderAge=25,
                    PolicyTypeId=1,
                    CoverageId=1,
                    // VehicleDetailId=null,
                    // HouseDetailId=null,
                    IsActive= true
                },
                new Policy(){
                    PolicyId= 2,
                    Title="YEW",
                    Description="Vehicle insurance for own vehicle",
                    StartDate=new DateTime(2020,09,03),
                    EndDate=new DateTime(2023,09,03),
                    InsuredAmount=100000,
                    InsuredName="Stinson",
                    InsuredHolderAge=25,
                    PolicyTypeId=2,
                    CoverageId=1,
                    VehicleDetailId=1,
                    // HouseDetailId=null,
                    IsActive= true
                },

            };
        }

        public static class SearchParams
        {
            public static string InsuredName { get; set; } = "Daniel";
            public static string Title { get; set; } = "FGU";
            public static string Description { get; set; } = "Home insurance";
            public static int Premium { get; set; } = 50000;
            public static int PolicyTypeId { get; set; } = 3;
            public static DateTime StartDate { get; set; } = new DateTime(2020,09,03);
            public static DateTime EndDate { get; set; } = new DateTime(2023,09,03);
            public static string SortType { get; set; } = "ascending";
            public static string SortBy { get; set; } = "Insured Name";
        }

        public static Policy CreatePolicy()
        {
            return new Policy
            {

                PolicyId = 1,
                Title = "DEW",
                Description = "Personal insurance",
                StartDate = new DateTime(2020, 09, 03),
                EndDate = new DateTime(2023, 09, 03),
                InsuredAmount = 100000,
                InsuredName = "Barney",
                InsuredHolderAge = 25,
                PolicyTypeId = 2,
                CoverageId = 1,
                VehicleDetailId=1,
                HouseDetailId=null,
                IsActive = true

            };
        }
        public static VehicleDetail CreateVehicle()
        {
            return new VehicleDetail
            {

                VehicleDetailId=1,
                VehicleModel="dbsc",
                VehicleNumber="TN 67f 7890",
                IsActive = true

            };
        }


    }
}