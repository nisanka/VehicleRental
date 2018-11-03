using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using VehicleRentalUI.Enum;

namespace VehicleRentalUI.Models
{
    public class Customer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber1 { get; set; }
        public string PhoneNumber2 { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime? DOB { get; set; }
        public char Gender { get; set; }
        public virtual ICollection<Attachment> Attachments { get; set; }
        public virtual AttachmentType ObjectType { get { return AttachmentType.Customer; } set { } }
        public bool IsActive { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public DateTime? LastRentedDatetime { get; set; }
        [NotMapped]
        public HttpPostedFileBase[] files { get; set; }
    }
}