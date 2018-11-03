using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using VehicleRentalUI.Enum;

namespace VehicleRentalUI.Models
{
    public class Vehicle
    {
        public string Id { get; set; }
        //public string EngineNumber { get; set; }
        //public string ChasisNumber { get; set; }       
        public virtual VehicleType Type { get; set; }
        public decimal? Rate { get; set; }
        //public int? RegisteredYear { get; set; }
        public int? EngineCapacity { get; set; }
        public virtual Brand Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Remarks { get; set; }
        public virtual AttachmentType ObjectType { get { return AttachmentType.Vehicle; } set { } }
        public virtual ICollection<Attachment> Attachments { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public DateTime? LastRentedDatetime { get; set; }
        [NotMapped]
        public HttpPostedFileBase[] files { get; set; }
    }
}