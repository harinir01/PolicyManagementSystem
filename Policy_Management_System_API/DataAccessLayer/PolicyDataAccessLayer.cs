namespace Policy_Management_System_API
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.JsonPatch;

    public class PolicyDataAccessLayer : IPolicyDataAccessLayer
    {
        private readonly Context _context;
        private readonly ILogger<PolicyService> _logger;

        public PolicyDataAccessLayer(Context context, ILogger<PolicyService> logger)
        {
            _context = context;
            _logger = logger;

        }

        //Creating a Policy
        public bool CreatePolicy(Policy policy, VehicleDetail vehicleDetail, HouseDetail houseDetail)
        {
            try
            {
                switch (policy.PolicyTypeId)
                {
                    case (int)PolicyType.PolicyTypes.Vehicle:
                        _context.vehicledetail!.Add(vehicleDetail);
                        _context.SaveChanges();
                        policy.VehicleDetailId = vehicleDetail.VehicleDetailId;
                        _context.policy!.Add(policy);
                        _context.SaveChanges();
                        break;
                    case (int)PolicyType.PolicyTypes.Asset:
                        _context.housedetail!.Add(houseDetail);
                        _context.SaveChanges();
                        policy.HouseDetailId = houseDetail.HouseDetailId;
                        _context.policy!.Add(policy);
                        _context.SaveChanges();
                        break;
                    case (int)PolicyType.PolicyTypes.Personal:
                        _context.policy!.Add(policy);
                        _context.SaveChanges();
                        break;
                }
                return true;

            }

            catch (DbUpdateException exception)
            {
                _logger.LogError($"PolicyDataAccessLayer-CreatePolicy()-{exception.Message}-{exception.StackTrace}");
                throw new DbUpdateException();
            }
            catch (Exception exception)
            {
                _logger.LogError($"PolicyDataAccessLayer-CreatePolicy()-{exception.Message}-{exception.StackTrace}");
                throw exception;
            }
        }
        //Getting all Policies and Search a Policy based on the applied filter
        public List<Policy> GetAllPolicies(SearchParams searchValues)
        {
            try
            {
                var x= _context.policy!
                    .Include(p => p.coverage)
                    .Include(p => p.vehicleDetail)
                    .Include(p => p.houseDetail)
                    .Include(p => p.policytype)
                    .WhereIf(String.IsNullOrEmpty(searchValues.InsuredName) == false, policy => policy.InsuredName!.Contains(searchValues.InsuredName) == true)
                    .WhereIf(String.IsNullOrEmpty(searchValues.Title) == false, policy => policy.Title==searchValues.Title)
                    .WhereIf(String.IsNullOrEmpty(searchValues.Description) == false, policy => policy.Description!.Contains(searchValues.Description) == true)
                    .WhereIf(searchValues.Premium != 0, policy => policy.Premium <= searchValues.Premium)
                    .WhereIf(searchValues.PolicyTypeId != 0, policy => policy.PolicyTypeId == searchValues.PolicyTypeId)
                    .WhereIf(searchValues.StartDate != DateTime.MinValue, policy => policy.StartDate.Date >= searchValues.StartDate.Date)
                    .WhereIf( searchValues.EndDate != DateTime.MinValue,policy =>policy.EndDate.Date <= searchValues.EndDate.Date)
                    .Skip((searchValues.PageNumber - 1) * searchValues.PageSize)
                    .Take(searchValues.PageSize)
                    .ToList();
                var y = x;
                return x;
                
            }
            catch (NullReferenceException exception)
            {
                _logger.LogError($"PolicyDataAccessLayer-GetAllPolicies()-{exception.Message}-{exception.StackTrace}");
                throw exception;
            }
            catch (Exception exception)
            {
                _logger.LogError($"PolicyDataAccessLayer-GetAllPolicies()-{exception.Message}-{exception.StackTrace}");
                throw exception;
            }
        }
        public int GetCountOfData(){
            return _context.policy!.Count();
        }
        //Getting a Policy detail by Id
        public Policy GetPolicyById(int PolicyId)
        {
            if (PolicyId == 0)
            {
                throw new ArgumentNullException();
            }
            else if (PolicyId < 0)
            {
                throw new ArgumentException();
            }
            try
            {
                return _context.policy!.Include(p => p.coverage).Include(p => p.vehicleDetail).Include(p => p.houseDetail).Include(p => p.policytype).First(p => p.PolicyId == PolicyId);
            }
            catch (Exception exception)
            {
                _logger.LogError($"PolicyDataAccessLayer-GetPolicyById()-{exception.Message}-{exception.StackTrace}");
                throw exception;
            }
        }
        //Update Policy Details
        public bool UpdatePolicy(Policy policy, VehicleDetail vehicleDetail, HouseDetail houseDetail)
        {
            try
            {
                switch (policy.PolicyTypeId)
                {
                    case (int)PolicyType.PolicyTypes.Vehicle:
                        _context.vehicledetail!.Update(vehicleDetail);
                        _context.SaveChanges();
                        policy.VehicleDetailId = vehicleDetail.VehicleDetailId;
                        _context.policy!.Update(policy);
                        _context.SaveChanges();
                        break;
                    case (int)PolicyType.PolicyTypes.Asset:
                        _context.housedetail!.Update(houseDetail);
                        _context.SaveChanges();
                        policy.HouseDetailId = houseDetail.HouseDetailId;
                        _context.policy!.Update(policy);
                        _context.SaveChanges();
                        break;
                    case (int)PolicyType.PolicyTypes.Personal:
                        _context.policy!.Update(policy);
                        _context.SaveChanges();
                        break;
                }
                return true;

            }

            catch (DbUpdateException exception)
            {
                _logger.LogError($"PolicyDataAccessLayer-CreatePolicy()-{exception.Message}-{exception.StackTrace}");
                throw new DbUpdateException();
            }
            catch (Exception exception)
            {
                _logger.LogError($"PolicyDataAccessLayer-CreatePolicy()-{exception.Message}-{exception.StackTrace}");
                throw exception;
            }

        }

        //Disable Policy Details
        public bool DeletePolicy(int PolicyId)
        {
            if (PolicyId == 0)
            {
                throw new ArgumentNullException();
            }
            else if (PolicyId < 0)
            {
                throw new ArgumentException();
            }
            try
            {
                var policydetails = _context.policy!.Find(PolicyId);
                if (policydetails == null) throw new ArgumentNullException($"Policy Id - {PolicyId} not found");
                policydetails.IsActive = false;
                _context.policy.Update(policydetails);
                _context.SaveChanges();
                return true;
            }
            catch (DbUpdateException exception)
            {
                _logger.LogError($"PolicyDataAccessLayer-DeletePolicy()-{exception.Message}-{exception.StackTrace}");
                throw new DbUpdateException();
            }
            catch (Exception exception)
            {
                _logger.LogError($"PolicyDataAccessLayer-DeletePolicy()-{exception.Message}-{exception.StackTrace}");
                throw exception;
            }


        }

        public async Task<Policy> UpdatePolicyPatch(int policyid, JsonPatchDocument policyDocument)
        {
            try
            {
                var getpolicy = GetPolicyById(policyid);
                if (getpolicy == null)
                {
                    throw new NullReferenceException();
                }
                policyDocument.ApplyTo(getpolicy);
                DateTime FromYear = Convert.ToDateTime(getpolicy.StartDate);
                DateTime ToYear = Convert.ToDateTime(getpolicy.EndDate);
                getpolicy.Duration = (ToYear - FromYear).Days / 365;
                getpolicy.Premium = getpolicy.InsuredAmount / getpolicy.Duration;
                await _context.SaveChangesAsync();

                return getpolicy;
            }
            catch (DbUpdateException exception)
            {
                _logger.LogError($"PolicyDataAccessLayer-UpdatePolicyPatch()-{exception.Message}-{exception.StackTrace}");
                throw new DbUpdateException();
            }
            catch (ValidationException exception)
            {
                _logger.LogError($"PolicyDataAccessLayer-UpdatePolicyPatch()-{exception.Message}-{exception.StackTrace}");
                throw new ValidationException();
            }
            catch (ArgumentNullException exception)
            {
                _logger.LogError($"PolicyDataAccessLayer-UpdatePolicyPatch()-{exception.Message}-{exception.StackTrace}");
                throw new ArgumentNullException();
            }
            catch (Exception exception)
            {
                _logger.LogError($"PolicyDataAccessLayer-UpdatePolicyPatch()-{exception.Message}-{exception.StackTrace}");
                throw exception;
            }

        }

         public List<PolicyType> GetPolicyType() 
        {
            try
            {
                return _context.policytype!.Where(p=>p.IsActive==true).ToList();
            }
            catch (InvalidOperationException ex)              //InvalidOperation Exception Occurs
            {
                _logger.LogInformation($"{ex.Message}\n {ex.StackTrace}");
                throw new InvalidOperationException();

            }
            catch (Exception ex)                      //Unknown Exception Occurs
            {
                _logger.LogInformation($"{ex.Message}\n {ex.StackTrace}");
                throw;  
            }
        }
    }
}