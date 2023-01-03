namespace Policy_Management_System_API
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel;
     public class HouseDetail
    {
        [Key]
        public int HouseDetailId{get; set;}
        public string? HouseAddress{get;set;}
        public float? AssetValue{get; set;}
        // public int? PolicyId{get; set;}
        public  Policy? policy { get; set; }
        [DefaultValue(true)]
        public bool IsActive{get;set;}
    }
}