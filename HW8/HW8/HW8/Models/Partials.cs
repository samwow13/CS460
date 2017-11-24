using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace HW8.Models
{
    public partial class Artist
    {
        [Display(Name = "Artist Name")]
        public string FullName { get { return $"{FirstName} {LastName}"; } }

        [Display(Name = "Birth Place")]
        public string BirthPlace { get { return $"{BirthCity}, {BirthCountry}"; } }
    }
}