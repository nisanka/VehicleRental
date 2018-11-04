using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace VehicleRentalUI.Models
{
    public class Brand
    {
        [DisplayName("Brand Id")]
        public string Id { get; set; }

        [DisplayName("Brand Name")]
        public string Name { get; set; }
        public Attachment Picture { get; set; }
    }
}