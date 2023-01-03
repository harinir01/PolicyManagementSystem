namespace Policy_Management_System_API
{
    using Microsoft.AspNetCore.JsonPatch;
    public interface IPolicyDataAccessLayer
    {
        bool CreatePolicy(Policy policy,VehicleDetail vehicleDetail,HouseDetail houseDetail);
        List<Policy> GetAllPolicies(SearchParams searchValues);
        int GetCountOfData();
        Policy GetPolicyById(int PolicyId);
        bool UpdatePolicy(Policy policy,VehicleDetail vehicleDetail,HouseDetail houseDetail);
        Task<Policy> UpdatePolicyPatch(int policyid, JsonPatchDocument policyDocument);
        bool DeletePolicy(int PolicyId);
        List<PolicyType> GetPolicyType();
    }
}