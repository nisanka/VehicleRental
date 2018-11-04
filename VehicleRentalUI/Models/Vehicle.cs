using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using VehicleRentalUI.Enum;

namespace VehicleRentalUI.Models
{
    public class Vehicle
    {        
        [RegularExpression(@"([a-zA-Z]{2,3}|\d{1,3})[-]\d{4}$", ErrorMessage = "Enter a valid vehicle registration number")]
        [Display(Name = "Number")]
        public string Id { get; set; }      

        public decimal? Rate { get; set; }

        [RegularExpression(@"^(\d{4})$", ErrorMessage = "Enter a valid 4 digit Year")]
        [Display(Name = "Registered Year")]
        public int? RegisteredYear { get; set; }

        [Display(Name = "Engine Capacity ( CC )")]
        public int? EngineCapacity { get; set; }
        

        public string Model { get; set; }

        public string Color { get; set; }

        [Display(Name = "Notes")]
        public string Remarks { get; set; }

        public virtual AttachmentType ObjectType { get { return AttachmentType.Vehicle; } set { } }

        public virtual ICollection<Attachment> Attachments { get; set; }                

        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        public DateTime? UpdatedDateTime { get; set; }

        [Display(Name = "Last Rented Date")]
        public DateTime? LastRentedDatetime { get; set; }

        [ForeignKey("VehicleType")]
        [Display(Name = "Vehicle Type")]
        public string VehicleTypeId { get; set; }

        public virtual VehicleType VehicleType { get; set; }

        [ForeignKey("Brand")]
        [Display(Name = "Brand")]
        public string BrandId { get; set; }
        public virtual Brand Brand { get; set; }

        [ForeignKey("ProvinceCategory")]
        [Display(Name = "Province")]
        public string ProvinceId { get; set; }
        public virtual ProvinceCategory ProvinceCategory { get; set; }
               
        [Display(Name = "Picture")]
        public string PictureId { get; set; }
        //public virtual Attachment Picture { get; set; }

        [NotMapped]
        public HttpPostedFileBase[] files { get; set; }
    }
}