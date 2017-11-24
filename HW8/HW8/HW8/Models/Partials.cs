using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace HW8.Models
{
    public partial class Artist
    {
        //create a string that is the entire name. Helpful for checking for 50 char total length as required in assignemnt
        [Display(Name = "Artist Name")]
        public string FullName { get { return $"{FirstName} {LastName}"; } }

        //create a string that is the birthcity + birthcountry.
        [Display(Name = "Birth Place")]
        public string BirthPlace { get { return $"{BirthCity}, {BirthCountry}"; } }
    }
}