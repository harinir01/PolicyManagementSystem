using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;

using Policy_Management_System_API;
using Policy_Management_System_API.Utilityfunctions;
using Testing.Mock;

namespace Testing.Service
{
    public class TestPolicyService
    {
        private readonly PolicyService policyService;
        private readonly Mock<IPolicyDataAccessLayer> policyData = new Mock<IPolicyDataAccessLayer>();
        private readonly Mock<ILogger<PolicyService>> logger = new Mock<ILogger<PolicyService>>();
        // private readonly Mock<IMapper> mapper = new Mock<IMapper>();
        private readonly IMapper mapper;

        public TestPolicyService()
        {
            var profile= new AutoMapperProfiles();
            var config=new MapperConfiguration(cfg => cfg.AddProfile(profile));
            mapper = new  Mapper(config); 
            policyService = new PolicyService(logger.Object, policyData.Object, mapper);
        }
        //Create Policy
        [Theory]
        [InlineData(null)]
        public void CreatePolicy_ShouldThrowArgumentNullException_WhenPolicyObjectIsNull(PolicyDto policyDto)
        {
            Assert.Throws<ArgumentNullException>(() => policyService.CreatePolicy(policyDto));
        }
        [Fact]
        public void CreatePolicy_ShouldReturnTrue_WhenObjectIsPassed()
        {
            
            PolicyDto policyDto = PolicyMock.CreateValidPolicy();
            // Policy policy=Mapper.Map<Policy>(policyDto);
            var vehicleDetail = mapper.Map<VehicleDetail>(policyDto);
            var policy= mapper.Map<Policy>(policyDto);
            // var policy = PolicyMock.CreatePolicy();
            // var vehicleDetail = PolicyMock.CreateVehicle();
            HouseDetail houseDetail = null;
            policyData.Setup(obj => obj.CreatePolicy(It.IsAny<Policy>(), It.IsAny<VehicleDetail>(), houseDetail)).Returns(true);
            var Result = policyService.CreatePolicy(policyDto);
            Assert.True(Result);
        }
        [Fact]
        public void CreatePolicy_ShouldThrowValidationException_WhenPolicyObjectIsInvalid()
        {
            PolicyDto policyDto = PolicyMock.CreateValidPolicy();
            Policy policy =  mapper.Map<Policy>(policyDto);
            VehicleDetail vehicleDetail = mapper.Map<VehicleDetail>(policyDto);
            HouseDetail houseDetail = null;
            policyData.Setup(obj => obj.CreatePolicy(policy, vehicleDetail, houseDetail)).Throws(new Exception());
            Assert.Throws<ValidationException>(() => policyService.CreatePolicy(policyDto));
        }



        //Get
        [Theory]
        [InlineData(1)]
        public void GetPolicyById_ShouldreturnPolicy_WhenPolicyIdIsPassed(int policyId)
        {
            var policy = PolicyMock.CreatePolicy();
            policyData.Setup(obj => obj.GetPolicyById(policyId)).Returns(policy);
            var Result = policyService.GetPolicyById(policyId);
            Assert.NotEqual(null, Result);
        }
        [Theory]
        [InlineData(-1)]
        public void GetPolicyById_ShouldThrowArgumentException_WhenUserIdIsInValid(int policyId)
        {
            Assert.Throws<ArgumentException>(() => policyService.GetPolicyById(policyId));
        }
        [Theory]
        [InlineData(0)]
        public void GetPolicyById_ShouldThrowArgumentNullException_WhenUserIdIsNull(int policyId)
        {
            Assert.Throws<ArgumentNullException>(() => policyService.GetPolicyById(policyId));
        }
        [Theory]
        [InlineData(1)]
        public void GetPolicyById_ShouldThrowException_WhenExceptionOccurs(int policyId)
        {
            policyData.Setup(obj => obj.GetPolicyById(policyId)).Throws(new Exception());
            Assert.Throws<Exception>(() => policyService.GetPolicyById(policyId));
        }

        // Get All Policies

        // [Theory]
        // [InlineData(null)]
        // public void GetAllPolicies_ShouldReturnAllPolicies_WhenMethodIsCalled(SearchParams searchParams)
        // {
        //     var policies = PolicyMock.GetAllPolicies();
        //     policyData.Setup(obj => obj.GetAllPolicies(searchParams)).Returns(policies);
        //     var Result = policyService.GetAllPolicies(searchParams);
        //     Assert.Equal(policies.Count(), Result.Count());
        // }

        [Theory]
        [InlineData(null)]
        public void GetAllPolicies_ShouldThrowException_WhenExceptionIsRaised(SearchParams searchParams)
        {

            policyData.Setup(obj => obj.GetAllPolicies(searchParams)).Throws(new Exception());
            Assert.Throws<Exception>(() => policyService.GetAllPolicies(searchParams));

        }
        [Theory]
        [InlineData(null)]
        public void GetAllPolicies_ShouldThrowException_WhenExceptionRaised(SearchParams searchParams)
        {

            policyData.Setup(obj => obj.GetAllPolicies(searchParams)).Throws(new Exception());
            Assert.Throws<Exception>(() => policyService.GetAllPolicies(searchParams));
        }

        //Remove Policy
        [Theory]
        [InlineData(0)]
        public void RemovePolicy_ShouldThrowArgumentNullException_WhenIdIsNull(int policyId)
        {
            Assert.Throws<ArgumentNullException>(() => policyService.DeletePolicy(policyId));
        }
        [Theory]
        [InlineData(-1)]
        public void RemoveUser_ShouldThrowArgumentException_WhenIdIsInValid(int policyId)
        {
            Assert.Throws<ArgumentException>(() => policyService.DeletePolicy(policyId));
        }
        [Theory]
        [InlineData(1)]
        public void RemovePolicy_ShouldReturnTrue_WhenIdIsPassed(int policyId)
        {
            policyData.Setup(obj => obj.DeletePolicy(policyId)).Returns(true);
            var Result = policyService.DeletePolicy(policyId);
            Assert.True(Result);
        }
        [Theory]
        [InlineData(1)]
        public void RemovePolicy_ShouldReturnFalse_WhenExceptionIsThrown(int policyId)
        {
            policyData.Setup(obj => obj.DeletePolicy(policyId)).Throws(new Exception());
            Assert.Throws<Exception>(() => policyService.DeletePolicy(policyId));
        }
    }
}