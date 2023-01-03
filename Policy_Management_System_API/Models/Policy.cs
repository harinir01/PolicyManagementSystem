namespace Policy_Management_System_API
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel;
     public class Policy
    {
        [Key]
        [Required]
        public int PolicyId { get; set; }
        [Required]
        public string Title{get;set;}
        [Required]
        public string Description{get;set;}
        [Required]
        public DateTime StartDate{get;set;}
        [Required]
        public DateTime EndDate{get;set;}
        [Required]
        public float? Premium{get;set;}
        public float? Duration{get;set;}
        [Required]
        public float InsuredAmount{get;set;}
        [Required]
        public string InsuredName{get;set;}
        [Required]
        public int InsuredHolderAge{get;set;}
        [Required]
        public int PolicyTypeId { get; set; }
        [ForeignKey("PolicyTypeId")]
        [InverseProperty("policy")]
        public virtual PolicyType? policytype { get; set; }
        [Required]
        public int CoverageId { get; set; }
        [ForeignKey("CoverageId")]
        [InverseProperty("policy")]
        public virtual Coverage? coverage { get; set; }
        public int? HouseDetailId{get; set;}
        public HouseDetail? houseDetail { get; set; }
        public int? VehicleDetailId{get; set;}
        public VehicleDetail? vehicleDetail { get; set; }
        
        [NotMapped]
        public string PolicyType { get; set; }
        [NotMapped]
        public string? VehicleNumber { get; set; }=String.Empty;
        [NotMapped]
        public string? VehicleModel { get; set; }=String.Empty;
        [NotMapped]
        public string? HouseAddress { get; set; }=String.Empty;
        [NotMapped]
        public float? AssetValue { get; set; } 
        [NotMapped]
        public string CoverageType { get; set; }
        [DefaultValue(true)]
        public bool IsActive{get;set;}
    }
}