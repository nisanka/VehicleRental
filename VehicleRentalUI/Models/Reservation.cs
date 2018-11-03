using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using VehicleRentalUI.Enum;

namespace VehicleRentalUI.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public virtual Customer CustomerId { get; set; }
        public virtual Vehicle VehicleId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public decimal? Amount { get; set; }
        public decimal? Discount { get; set; }
        public decimal? AdditionalCharges { get; set; }
        public decimal NetAmount { get; set; }
        public string Remarks { get; set; }
        public virtual AttachmentType ObjectType { get { return AttachmentType.Reservation; } set { } }
        public virtual ICollection<Attachment> Attachments { get; set; }      
        public bool IsActive { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }        
        [NotMapped]
        public HttpPostedFileBase[] files { get; set; }
    }
}