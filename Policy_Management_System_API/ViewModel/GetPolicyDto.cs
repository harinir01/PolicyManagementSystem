// namespace Policy_Management_System_API
// {
//     using System.ComponentModel.DataAnnotations.Schema;
//     using System.ComponentModel.DataAnnotations;
//     [NotMapped]

//     public class GetPolicyDto
//     {
//         public int PolicyId { get; set; } 
//         public string Title { get; set; }=String.Empty;
//         public string Description { get; set; }=String.Empty;
//         public DateTime StartDate { get; set; }
//         public DateTime EndDate { get; set; }
//         public float InsuredAmount { get; set; }
//         public string InsuredName { get; set; }=String.Empty;
//         public int InsuredHolderAge { get; set; }
//         public string PolicyType { get; set; }
//         public string CoverageType { get; set; }
//         public int? VehicleDetailId { get; set; } 
//         public string? VehicleNumber { get; set; }=String.Empty;
//         public string? VehicleModel { get; set; }=String.Empty;
//         public int? HouseDetailId { get; set; } 
//         public string? HouseAddress { get; set; }=String.Empty;
//         public float? AssetValue { get; set; }  
//         public bool IsActive{get;set;}=true;
//     }
// }