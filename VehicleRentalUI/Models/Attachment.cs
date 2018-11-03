using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using VehicleRentalUI.Enum;

namespace VehicleRentalUI.Models
{
    public class Attachment
    {
        public string Id { get; set; }
        public AttachmentType AttachmentType { get; set; }
        public string FileName { get; set; }
        public string OriginalFileName { get; set; }
        [NotMapped]
        public byte[] file { get; set; }
    }
}