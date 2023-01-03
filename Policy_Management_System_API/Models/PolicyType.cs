namespace Policy_Management_System_API
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class PolicyType
    {
        [Key]
        public virtual int PolicyTypeId { get; set; }
        public PolicyTypes Policytype
        {
            get
            {
                return (PolicyTypes)this.PolicyTypeId;
            }
            set
            {
                this.PolicyTypeId = (int)value;
            }
        }
        [InverseProperty("policytype")]
        public ICollection<Policy>?  policy  {get;set;}
        public bool IsActive { get; set; }

        public static implicit operator PolicyType(string v)
        {
            throw new NotImplementedException();
        }

        public enum PolicyTypes
        {
            Personal=1,
            Vehicle=2,
            Asset=3
        }
    }

}
