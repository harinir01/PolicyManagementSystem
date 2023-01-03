namespace Policy_Management_System_API
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    [NotMapped]

    public class PolicyDto
    {
        public int PolicyId { get; set; } 
        [Required(ErrorMessage = "Title is Required.")]
        [StringLength(10)]
        public string Title { get; set; }=String.Empty;
        [Required(ErrorMessage = "Description is Required.")]
        public string Description { get; set; }=String.Empty;
        [Required(ErrorMessage = "Start date of policy is Required.")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "End date of policy is Required.")]
        public DateTime EndDate { get; set; }
        [Required(ErrorMessage = "Insured amount is Required.")]
        public float InsuredAmount { get; set; }
        [Required(ErrorMessage = "Insured holder's name is Required.")]
        [StringLength(15)]
        public string InsuredName { get; set; }=String.Empty;
        [Required(ErrorMessage = "Insured holder's age is Required")]
        [Range(18,int.MaxValue, ErrorMessage ="Age of an insured person should not be less than 18.")]
        public int InsuredHolderAge { get; set; }
        [Required(ErrorMessage = "Policy Type Id is Required.")]
        public int PolicyTypeId { get; set; }
        [Required(ErrorMessage = "Coverage Id is Required.")]
        public int CoverageId { get; set; }
        public int? VehicleDetailId { get; set; } 
        public string? VehicleNumber { get; set; }=String.Empty;
        public string? VehicleModel { get; set; }=String.Empty;
        public int? HouseDetailId { get; set; } 
        public string? HouseAddress { get; set; }=String.Empty;
        public float? AssetValue { get; set; }  
        public bool IsActive{get;set;}=true;
    }
}