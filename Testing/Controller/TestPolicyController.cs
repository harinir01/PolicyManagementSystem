using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Policy_Management_System_API;
using Moq;
using Testing.Mock;

namespace testing.Controller
{
    public class TestPolicyController
    {
        private readonly PolicyController policyController;
        private readonly Mock<IPolicyService> policyService = new Mock<IPolicyService>();
        private readonly Mock<ILogger<PolicyController>> logger = new Mock<ILogger<PolicyController>>();

        public TestPolicyController()
        {
            policyController = new PolicyController(policyService.Object, logger.Object);
        }
        //Create Policy
        [Fact]
        public void CreatePolicy_ShouldreturnStatuscode200_WhenPolicyObjectIsPassed()
        {

            PolicyDto policyDto = PolicyMock.CreateValidPolicy();
            policyService.Setup(obj => obj.CreatePolicy(policyDto)).Returns(true);
            var Result = policyController.CreatePolicy(policyDto) as ObjectResult;
            Assert.Equal(200, Result?.StatusCode);
        }
        [Fact]
        public void CreatePolicy_ShouldreturnStatuscode500_WhenPolicyObjectIsPassed()
        {

            PolicyDto policyDto = PolicyMock.CreateValidPolicy();
            policyService.Setup(obj => obj.CreatePolicy(policyDto)).Returns(false);
            var Result = policyController.CreatePolicy(policyDto) as ObjectResult;
            Assert.Equal(500, Result?.StatusCode);
        }
        //Exception
        [Fact]
        public void CreatePolicy_ShouldreturnStatuscode400_WhenValidationExceptionIsThrown()
        {

            PolicyDto policyDto = PolicyMock.CreateInValidPolicy();
            policyService.Setup(obj => obj.CreatePolicy(policyDto)).Throws(new ValidationException());
            Assert.Throws<ValidationException>(() => policyController.CreatePolicy(policyDto));
        }
        [Fact]
        public void CreatePolicy_ShouldreturnStatuscode400_WhenArgumentNullExceptionIsThrown()
        {
            PolicyDto? policyDto = null;
            policyService.Setup(obj => obj.CreatePolicy(policyDto)).Throws(new ArgumentNullException());
            Assert.Throws<ArgumentNullException>(() => policyController.CreatePolicy(policyDto));
        }
        [Fact]
        public void CreatePolicy_ShouldreturnStatuscode500_WhenExceptionIsThrown()
        {
            PolicyDto policyDto = PolicyMock.CreateValidPolicy();
            policyService.Setup(obj => obj.CreatePolicy(policyDto)).Throws(new Exception());
            Assert.Throws<Exception>(() => policyController.CreatePolicy(policyDto));
        }

        // GetAllPolicies
        // [Theory]
        // [InlineData (null)]
        // public void GetAllPolicies_ShouldReturnAllPolicies_WhenMethodIsCalled(SearchParams searchParams)
        // {
        //     var policies = PolicyMock.GetAllPolicies();
        //     policyService.Setup(obj => obj.GetAllPolicies(searchParams)).Returns(policies);
        //     var Result = policyController.GetAllPolicies(searchParams) as ObjectResult;
        //     Assert.Equal(policies, Result?.Value);

        // }
        [Theory]
        [InlineData(null)]
        public void GetAllPolicies_ShouldReturnStatuscode500_WhenExceptionIsThrown(SearchParams searchParams)
        {

            policyService.Setup(obj => obj.GetAllPolicies(searchParams)).Throws(new Exception());
            Assert.Throws<Exception>(() => policyController.GetAllPolicies(searchParams));

        }

        //GetPolicyById

        [Theory]
        [InlineData(0)]
        public void GetPolicyById_ShouldreturnStatuscode400_WhenPolicyIdIsNull(int policyId)
        {
            policyService.Setup(obj => obj.GetPolicyById(policyId)).Throws(new ArgumentNullException());
            Assert.Throws<ArgumentNullException>(() => policyController.GetPolicyById(policyId));
        }
        [Theory]
        [InlineData(1)]
        public void GetPolicyById_ShouldReturnStatusCode200_WhenIdIsPassed(int policyId)
        {
            var policy = PolicyMock.GetAllPolicies();
            policyService.Setup(obj => obj.GetPolicyById(policyId)).Returns(policy);
            var Result = policyController.GetPolicyById(policyId) as ObjectResult;
            Assert.Equal(200, Result?.StatusCode);

        }
        [Theory]
        [InlineData(1)]
        public void GetPolicyById_ShouldreturnStatuscode500_WhenExceptionIsThrown(int policyId)
        {
            policyService.Setup(obj => obj.GetPolicyById(policyId)).Throws(new Exception());
            Assert.Throws<Exception>(() => policyController.GetPolicyById(policyId));
        }
        [Theory]
        [InlineData(-1)]
        public void GetPolicyById_ShouldreturnStatuscode400_WhenPolicyIdIsInvalid(int policyId)
        {
            policyService.Setup(obj => obj.GetPolicyById(policyId)).Throws(new ArgumentException());
            Assert.Throws<ArgumentException>(() => policyController.GetPolicyById(policyId));
        }

        //UpdatePolicy
        //    [Theory]
        //    [InlineData(null)]
        //    public void UpdatePolicy_ShouldReturnStatusCode400_WhenObjectIsPassed(int policyid,)
        //    {
        //        var Result=userControllers.UpdateUser(user) as ObjectResult;
        //        Assert.Equal(400,Result?.StatusCode);
        //    }

        //RemovePolicy
        [Theory]
        [InlineData(1)]
        public void RemovePolicy_ShouldReturnStatusCode200_WhenIdIsPassed(int policyId)
        {
            policyService.Setup(obj => obj.DeletePolicy(policyId)).Returns(true);
            var Result = policyController.DeletePolicy(policyId) as ObjectResult;
            Assert.Equal(200, Result?.StatusCode);
        }
        [Theory]
        [InlineData(1)]
        public void RemovePolicy_ShouldReturnStatusCode500_WhenIdIsPassed(int policyId)
        {
            policyService.Setup(obj => obj.DeletePolicy(policyId)).Returns(false);
            var Result = policyController.DeletePolicy(policyId) as ObjectResult;
            Assert.Equal(500, Result?.StatusCode);
        }
        [Theory]
        [InlineData(-1)]
        public void RemovePolicy_ShouldReturnStatusCode400_WhenIdIsPassed(int policyId)
        {
            policyService.Setup(obj => obj.DeletePolicy(policyId)).Throws(new ArgumentException());
            Assert.Throws<ArgumentException>(() => policyController.DeletePolicy(policyId));
        }
        [Theory]
        [InlineData(0)]
        public void RemovePolicy_ShouldReturnStatusCode400_WhenIdIsNull(int policyId)
        {
            policyService.Setup(obj => obj.DeletePolicy(policyId)).Throws(new ArgumentNullException());
            Assert.Throws<ArgumentNullException>(() => policyController.DeletePolicy(policyId));
        }
        [Theory]
        [InlineData(1)]
        public void RemovePolicy_ShouldreturnStatuscode500_WhenExceptionIsThrown(int policyId)
        {
            policyService.Setup(obj => obj.DeletePolicy(policyId)).Throws(new Exception());
            Assert.Throws<Exception>(() => policyController.DeletePolicy(policyId));
        }
    }
}