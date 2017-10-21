using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HW5.Models
{
    public class Request
    {
        public int ID { get; set; }

        [Display(Name = "ODL#:"), Required]
        public int ODL { get; set; }

        [Display(Name = "Date of Birth:"), Required]
        public string DoB { get; set; }

        [Display(Name = "Full Name:"), Required]
        public string FullName { get; set; }

        [Display(Name = "Street Address:"), Required]
        public string StreetAddress { get; set; }

        [Display(Name = "City:"), Required]
        public string City { get; set; }

        [Display(Name = "State:"), Required]
        public string States { get; set; }

        [Display(Name = "Zipcode:"), Required]
        public string ZipCode { get; set; }

        [Display(Name = "County:"), Required]
        public string County { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()}; ODL = {ODL} {DoB} {FullName} {StreetAddress} {City} {States} {ZipCode} {County}";
        }
    }
}