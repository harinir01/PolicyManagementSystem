namespace Policy_Management_System_API
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Microsoft.AspNetCore.JsonPatch;
    using Microsoft.EntityFrameworkCore;

    public class PolicyService : IPolicyService
    {
        private readonly IPolicyDataAccessLayer _policyData;
        private readonly ILogger<PolicyService> _logger;
        private readonly IMapper mapper;
        

        public PolicyService(ILogger<PolicyService> logger, IPolicyDataAccessLayer policyData, IMapper mapper)
        {
            _logger = logger;
            _policyData = policyData;
            this.mapper = mapper;
        }

        //Creating a Policy
        public bool CreatePolicy(PolicyDto policyDto)
        {
            if (policyDto == null)
            {
                throw new ArgumentNullException("Policy object cannot be null");
            }
            try
            {
                Policy? policy = null;
                VehicleDetail? vehicleDetail = null;
                HouseDetail? houseDetail = null;

                switch (policyDto.PolicyTypeId)
                {
                    case (int)PolicyType.PolicyTypes.Personal:
                        policy=mapper.Map<Policy>(policyDto);
                        break;
                    case (int)PolicyType.PolicyTypes.Vehicle:
                        vehicleDetail = mapper.Map<VehicleDetail>(policyDto);
                        policy=mapper.Map<Policy>(policyDto);
                        break;
                    case (int)PolicyType.PolicyTypes.Asset:
                        houseDetail = mapper.Map<HouseDetail>(policyDto);
                        policy=mapper.Map<Policy>(policyDto);
                        break;

                }
                var result = _policyData.CreatePolicy(policy, vehicleDetail, houseDetail);
                return result;

            }
            // catch (DbUpdateException exception)
            // {
            //     _logger.LogError($"PolicyService-CreatePolicy()-{exception.Message}-{exception.StackTrace}");
            //     throw new DbUpdateException();
            // }
            catch (ArgumentNullException exception)
            {
                _logger.LogError($"PolicyService-CreatePolicy()-{exception.Message}-{exception.StackTrace}");
                throw new ArgumentNullException();
            }
            catch (Exception exception)
            {
                _logger.LogError($"PolicyService : CreatePolicy()-{exception.Message}\n{exception.StackTrace}");
                throw exception;
            }
        }
        //Getting all Policies and Search a Policy based on the applied filter
        public List<Policy> GetAllPolicies(SearchParams searchValues)
        {
            try
            {

                List<Policy> result = new();
                var getallpolicy = _policyData.GetAllPolicies(searchValues).Where(item => item.IsActive == true) ;
                foreach(var item in getallpolicy){
                    Policy data=null;
                    if (Enum.GetName(typeof(PolicyType.PolicyTypes), item.PolicyTypeId) == "Personal")
                    {
                    data = new Policy()
                    {
                        PolicyId = item.PolicyId,
                        Title = item.Title,
                        Description = item.Description,
                        StartDate = item.StartDate,
                        EndDate = item.EndDate,
                        Premium = item.Premium,
                        Duration = item.Duration,
                        InsuredAmount = item.InsuredAmount,
                        InsuredName = item.InsuredName,
                        InsuredHolderAge = item.InsuredHolderAge,
                        PolicyType=Enum.GetName(typeof(PolicyType.PolicyTypes), item.PolicyTypeId),
                        CoverageType = item.coverage!.CoverageType,
                        IsActive=item.IsActive
                    };
                    result.Add(data!);
                }
                
                else if (Enum.GetName(typeof(PolicyType.PolicyTypes), item.PolicyTypeId) == "Vehicle")
                    {
                    data = new Policy()
                    {
                        PolicyId = item.PolicyId,
                        Title = item.Title,
                        Description = item.Description,
                        StartDate = item.StartDate,
                        EndDate = item.EndDate,
                        Premium = item.Premium,
                        Duration = item.Duration,
                        InsuredAmount = item.InsuredAmount,
                        InsuredName = item.InsuredName,
                        InsuredHolderAge = item.InsuredHolderAge,
                        PolicyType=Enum.GetName(typeof(PolicyType.PolicyTypes), item.PolicyTypeId),
                        VehicleModel=item.vehicleDetail.VehicleModel,
                        VehicleNumber=item.vehicleDetail.VehicleNumber,
                        CoverageType = item.coverage!.CoverageType,
                        IsActive=item.IsActive
                    };
                  result.Add(data!);  
                }
                else if (Enum.GetName(typeof(PolicyType.PolicyTypes), item.PolicyTypeId) == "Asset")
                    {
                    data = new Policy()
                    {
                        PolicyId = item.PolicyId,
                        Title = item.Title,
                        Description = item.Description,
                        StartDate = item.StartDate,
                        EndDate = item.EndDate,
                        Premium = item.Premium,
                        Duration = item.Duration,
                        InsuredAmount = item.InsuredAmount,
                        InsuredName = item.InsuredName,
                        InsuredHolderAge = item.InsuredHolderAge,
                        PolicyType=Enum.GetName(typeof(PolicyType.PolicyTypes), item.PolicyTypeId),
                        HouseAddress=item.houseDetail.HouseAddress,
                        AssetValue=item.houseDetail.AssetValue,
                        CoverageType = item.coverage!.CoverageType,
                        IsActive=item.IsActive
                    };
                  result.Add(data!);  
                }
                }
                
                switch (searchValues.SortBy)
                {
                    case "InsuredName":
                        if (searchValues.SortType == "ascending")
                        {
                            result = (List<Policy>)result.OrderBy(c => c.InsuredName);
                        }
                        else
                        {
                            result = (List<Policy>)result.OrderByDescending(c => c.InsuredName);
                        }

                        break;
                    case "StartDate":
                        if (searchValues.SortType == "ascending")
                        {
                            result = (List<Policy>)result.OrderBy(c => c.StartDate);
                        }
                        else
                        {
                            result = (List<Policy>)result.OrderByDescending(c => c.StartDate);
                        }

                        break;
                    case "EndDate":
                        if (searchValues.SortType == "ascending")
                        {
                            result = (List<Policy>)result.OrderBy(c => c.EndDate);
                        }
                        else
                        {
                            result = (List<Policy>)result.OrderByDescending(c => c.EndDate);
                        }

                        break;
                }
                return result;
               
            }
            catch (NullReferenceException exception)
            {
                _logger.LogError($"PolicyService : GetAllPolicies()-{exception.Message}-{exception.StackTrace}");
                throw exception;
            }
            catch (Exception exception)
            {
                _logger.LogError($"PolicyService : GetAllPolicies()-{exception.Message}\n{exception.StackTrace}");
                throw exception;
            }

        }
        public object GetPolicyById(int PolicyId)
        {
            if (PolicyId == 0)
            {
                throw new ArgumentNullException();
            }
            else if(PolicyId < 0){
                throw new ArgumentException();
            }
            try
            {
                var getpolicy = _policyData.GetPolicyById(PolicyId);
                if (Enum.GetName(typeof(PolicyType.PolicyTypes), getpolicy.PolicyTypeId) == "Personal")
                {
                    return new
                    {
                        policyId = getpolicy.PolicyId,
                        title = getpolicy.Title,
                        description = getpolicy.Description,
                        startDate = getpolicy.StartDate.ToString("yyyy-MM-dd"),
                        endDate = getpolicy.EndDate.ToString("yyyy-MM-dd"),
                        premium = getpolicy.Premium,
                        duration = getpolicy.Duration,
                        insuredAmount = getpolicy.InsuredAmount,
                        insuredName = getpolicy.InsuredName,
                        insuredHolderAge = getpolicy.InsuredHolderAge,
                        policyTypeId=getpolicy.PolicyTypeId,
                        policyType = Enum.GetName(typeof(PolicyType.PolicyTypes), getpolicy.PolicyTypeId),
                        coverageId=getpolicy.CoverageId,
                        coverageType = getpolicy.coverage!.CoverageType
                    };
                }
                else if (Enum.GetName(typeof(PolicyType.PolicyTypes), getpolicy.PolicyTypeId) == "Vehicle")
                {
                    return new
                    {
                        policyId = getpolicy.PolicyId,
                        title = getpolicy.Title,
                        description = getpolicy.Description,
                        startDate = getpolicy.StartDate.ToString("yyyy-MM-dd"),
                        endDate = getpolicy.EndDate.ToString("yyyy-MM-dd"),
                        premium = getpolicy.Premium,
                        duration = getpolicy.Duration,
                        insuredAmount = getpolicy.InsuredAmount,
                        insuredName = getpolicy.InsuredName,
                        insuredHolderAge = getpolicy.InsuredHolderAge,
                        policyTypeId=getpolicy.PolicyTypeId,
                        policyType = Enum.GetName(typeof(PolicyType.PolicyTypes), getpolicy.PolicyTypeId),
                        vehicleNumber = getpolicy.vehicleDetail!.VehicleNumber,
                        vehicleModel = getpolicy.vehicleDetail.VehicleModel,
                        coverageId=getpolicy.CoverageId,
                        coverageType = getpolicy.coverage!.CoverageType
                    };
                }
                else
                {
                    return new
                    {
                        policyId = getpolicy.PolicyId,
                        title = getpolicy.Title,
                        description = getpolicy.Description,
                        startDate = getpolicy.StartDate.ToString("yyyy-MM-dd"),
                        endDate = getpolicy.EndDate.ToString("yyyy-MM-dd"),
                        premium = getpolicy.Premium,
                        duration = getpolicy.Duration,
                        insuredAmount = getpolicy.InsuredAmount,
                        insuredName = getpolicy.InsuredName,
                        insuredHolderAge = getpolicy.InsuredHolderAge,
                        policyTypeId=getpolicy.PolicyTypeId,
                        policyType = Enum.GetName(typeof(PolicyType.PolicyTypes), getpolicy.PolicyTypeId),
                        houseAddress = getpolicy.houseDetail!.HouseAddress,
                        assetValue = getpolicy.houseDetail.AssetValue,
                        coverageId=getpolicy.CoverageId,
                        coverageType = getpolicy.coverage!.CoverageType
                    };
                }
            }
            catch (Exception exception)
            {
                _logger.LogError($"PolicyService : GetPolicyById()-{exception.Message}\n{exception.StackTrace}");
                throw exception;
            }

        }
        public Policy GetPolicyDetailsById(int PolicyId)
        {
            if (PolicyId == 0)
            {
                throw new ArgumentNullException();
            }
            else if(PolicyId<0){
                throw new ArgumentException();
            }
            try
            {
                Policy policy = _policyData.GetPolicyById(PolicyId);
                return policy;
            }
            catch (Exception exception)
            {
                _logger.LogError($"PolicyService : GetPolicyDetailsById()-{exception.Message}\n{exception.StackTrace}");
                throw exception;
            }

        }
        // Updation of Policy Details
        public bool UpdatePolicy(PolicyDto policyDto)
        {
           try
            {
                Policy? policy = null;
                VehicleDetail? vehicleDetail = null;
                HouseDetail? houseDetail = null;

                switch (policyDto.PolicyTypeId)
                {
                    case (int)PolicyType.PolicyTypes.Personal:
                        policy=mapper.Map<Policy>(policyDto);
                        break;
                    case (int)PolicyType.PolicyTypes.Vehicle:
                        vehicleDetail = mapper.Map<VehicleDetail>(policyDto);
                        policy=mapper.Map<Policy>(policyDto);
                        break;
                    case (int)PolicyType.PolicyTypes.Asset:
                        houseDetail = mapper.Map<HouseDetail>(policyDto);
                        policy=mapper.Map<Policy>(policyDto);
                        break;

                }
                var result = _policyData.UpdatePolicy(policy, vehicleDetail, houseDetail);
                return result;

            }
            // catch (DbUpdateException exception)
            // {
            //     _logger.LogError($"PolicyService-CreatePolicy()-{exception.Message}-{exception.StackTrace}");
            //     throw new DbUpdateException();
            // }
            catch (ArgumentNullException exception)
            {
                _logger.LogError($"PolicyService-CreatePolicy()-{exception.Message}-{exception.StackTrace}");
                throw new ArgumentNullException();
            }
            catch (Exception exception)
            {
                _logger.LogError($"PolicyService : CreatePolicy()-{exception.Message}\n{exception.StackTrace}");
                throw exception;
            }
        }
        //Disable Policy details
        public bool DeletePolicy(int PolicyId)
        {
            if (PolicyId == 0)
            {
                throw new ArgumentNullException();
            }
            else if(PolicyId < 0){
                throw new ArgumentException();
            }
            try
            {
                return _policyData.DeletePolicy(PolicyId);
            }
            catch (Exception exception)
            {
                _logger.LogError($"PolicyService : DeletePolicy()-{exception.Message}\n{exception.StackTrace}");
                throw exception;
            }
        }

        //Update Policy using Patch
        public Task<Policy> UpdatePolicyPatch(int policyid, JsonPatchDocument policyDocument)
        {
            try
            {
                return _policyData.UpdatePolicyPatch(policyid, policyDocument);
            }
            catch (ValidationException exception)
            {
                _logger.LogError($"PolicyService-UpdatePolicyPatch()-{exception.Message}-{exception.StackTrace}");
                throw new ValidationException();
            }
            catch (ArgumentNullException exception)
            {
                _logger.LogError($"PolicyService-UpdatePolicyPatch()-{exception.Message}-{exception.StackTrace}");
                throw new ArgumentNullException();
            }
            catch (Exception exception)
            {
                _logger.LogError($"PolicyService : UpdatePolicyPatch()-{exception.Message}\n{exception.StackTrace}");
                throw exception;
            }
        }
        public object GetPolicyType()
        {
            try
            {
                
                return _policyData.GetPolicyType()
                .Select(polictype => new
                {
                    policyType=Enum.GetName(typeof(PolicyType.PolicyTypes), polictype.PolicyTypeId)
                });
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{ex.Message}\n {ex.StackTrace}");
                 throw;
                
            }
        }
    }
}