namespace Policy_Management_System_API
{
    using Microsoft.AspNetCore.JsonPatch;
    public interface IPolicyService
    {
        bool CreatePolicy(PolicyDto policyDto);
        object GetAllPolicies(SearchParams searchValues);
        object GetPolicyById(int PolicyId);
        bool UpdatePolicy(PolicyDto policyDto);
        Task<Policy> UpdatePolicyPatch(int policyid, JsonPatchDocument policyDocument);
        bool DeletePolicy(int id);
        object GetPolicyType();
    }
}