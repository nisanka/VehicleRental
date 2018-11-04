using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using VehicleRentalUI.Enum;

namespace VehicleRentalUI.Models
{
    public class Reservation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
                
        [Display(Name = "Customer")]
        public virtual Customer CustomerId { get; set; }

        [Display(Name = "Vehicle")]
        public virtual Vehicle VehicleId { get; set; }

        [Display(Name = "From Date")]
        public DateTime FromDate { get; set; }

        [Display(Name = "To Date")]
        public DateTime ToDate { get; set; }
        public decimal? Amount { get; set; }

        public decimal? Discount { get; set; }

        [Display(Name = "Additional Charges")]
        public decimal? AdditionalCharges { get; set; }

        [Display(Name = "Net Amount")]
        public decimal NetAmount { get; set; }

        [Display(Name = "Notes")]
        public string Remarks { get; set; }

        public virtual AttachmentType ObjectType { get { return AttachmentType.Reservation; } set { } }

        public virtual ICollection<Attachment> Attachments { get; set; }

        public bool IsActive { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        public DateTime? UpdatedDateTime { get; set; }
        public bool Damaged { get; set; }   
      
        public string Status { get; set; }

        [NotMapped]
        public HttpPostedFileBase[] files { get; set; }
    }
}