namespace Policy_Management_System_API
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;

    public class VehicleDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VehicleDetailId{get; set;}
        public string? VehicleNumber{get;set;}
        public string? VehicleModel{get; set;}
        // public int? PolicyId{get; set;}
        public  Policy? policy { get; set; }
        [DefaultValue(true)]
        public bool IsActive{get;set;}
    }
}