namespace Policy_Management_System_API
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.JsonPatch;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;

    [ApiController]
    [Route("[controller]/[Action]")]
    public class PolicyController : Controller
    {

        private readonly IPolicyService _policyService;
        private readonly ILogger _logger;

        public PolicyController(IPolicyService policyService, ILogger<PolicyController> logger)
        {
            _policyService = policyService;
            _logger = logger;

        }

        //Creating a Policy
        [HttpPost]
        public IActionResult CreatePolicy(PolicyDto policyDto)
        {

            PolicyValidation.IsPolicyValid(policyDto);
            var createpolicy = _policyService.CreatePolicy(policyDto);
            return createpolicy ? Ok(new { message = "Policy Details added successfully" }) : Problem("Something went wrong");
        }

        //Getting all Policies and Search a Policy based on the applied filter
        [HttpGet]
        public IActionResult GetAllPolicies([FromQuery]SearchParams searchValues )
        {
            
            return Ok(_policyService.GetAllPolicies(searchValues));
        }

        //Getting a Policy by Id
        [HttpGet]
        public IActionResult GetPolicyById(int PolicyId)
        {
            // try{
             
            return Ok(_policyService.GetPolicyById(PolicyId));
            // }
            // catch (ArgumentNullException exception)
            // {
            //     _logger.LogError($"PolicyController:GetPolicyById()-{exception.Message}{exception.StackTrace}");
            //     return BadRequest(exception.Message);
            // }
            // catch (Exception exception)
            // {
            //     _logger.LogInformation($"PolicyController:GetPolicyById()- exception occured while fetching record{exception.Message}{exception.StackTrace}");
            //     return Problem(exception.Message);
            // }
        }
        //Updation of Policy details
        [HttpPut]
        public IActionResult UpdatePolicy(PolicyDto policyDto)
        {
            PolicyValidation.IsPolicyValid(policyDto);
            var updatepolicy = _policyService.UpdatePolicy(policyDto);
            return updatepolicy ? Ok(new { message = "Policy Details updated successfully" }) : Problem("Something went wrong");
        }
        //Disable Policy details
        // [CustomExceptionFilter]
        [HttpDelete]
        public IActionResult DeletePolicy(int PolicyId)
        {
            // try{
            var deletepolicy = _policyService.DeletePolicy(PolicyId);
            return deletepolicy ? Ok(new { message = "Policy Details removed successfully" }) : Problem();
            // }   
            // catch (ArgumentNullException exception)
            // {
            //     _logger.LogError($"PolicyController :DeletePolicy()-{exception.Message}-{exception.StackTrace}");
            //     return BadRequest(exception.Message);
            // }
            // catch (Exception exception)
            // {
            //     _logger.LogError($"PolicyController :DeletePolicy()-{exception.Message}-{exception.StackTrace}");
            //     return Problem("Sorry some internal error occured");
            // }            
        }

        //Updating Policy details
        // [CustomExceptionFilter]
        [HttpPatch("{policyid:int}")]
        public async Task<IActionResult> UpdatePolicyPatch([FromRoute] int policyid, [FromBody] JsonPatchDocument policyDocument)
        {
            if (policyDocument == null)
            {
                return BadRequest(new { message = "Policy json obeject can't be null" }); ;
            }
            // try{
            var updatedPolicy = await _policyService.UpdatePolicyPatch(policyid, policyDocument);
            return Ok(new { message = "Policy Details updated successfully" });
            // }
            // catch (ArgumentNullException exception)
            // {
            //     _logger.LogError($"PolicyController : UpdatePolicyPatch()-{exception.Message}{exception.StackTrace}");
            //     return BadRequest(exception.Message);
            // }
            // catch (Exception exception)
            // {
            //     _logger.LogError($"PolicyController : UpdatePolicyPatch()-{exception.Message}{exception.StackTrace}");
            //     return Problem(exception.Message);
            // }

        }
        [HttpGet]
        public IActionResult GetPolicyType()
        {
            
            return Ok(_policyService.GetPolicyType());
        }
    }
}
