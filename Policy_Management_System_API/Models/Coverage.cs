namespace Policy_Management_System_API
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel;
     public class Coverage
    {
        [Key]
        public int CoverageId{get; set;}
        [Required]
        public string? CoverageType{get;set;}
        [InverseProperty("coverage")]
        public ICollection<Policy>?  policy  {get;set;}
        [DefaultValue(true)]
        public bool IsActive{get;set;}
    }
}