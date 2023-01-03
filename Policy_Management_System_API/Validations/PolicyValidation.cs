namespace Policy_Management_System_API
{
    // using GlobalExceptionHandling.Exceptions;
    // using CustomExceptionFilter;
    using System.Net;
    using System.Net.Http;
    using System.ComponentModel.DataAnnotations;
    
    public static class PolicyValidation
    {
        public static void IsPolicyValid(PolicyDto policyDto)
        {
            // if (policyDto.InsuredHolderAge < 18)
            // {
            //     throw new ValidationException("Insured person's age should not be less than 18");
            // }
            // if (policy.InsuredAmount < policy.Premium)
            // {
            //     throw new ValidationException("Insured amount should not be less than Premium amount");
            // }
            if (policyDto.EndDate == policyDto.StartDate || policyDto.EndDate < DateTime.Today)
            {
                throw new ValidationException("Policy's End date sholud not be same as start date or it should not be in past");
            }
        }
    }
}