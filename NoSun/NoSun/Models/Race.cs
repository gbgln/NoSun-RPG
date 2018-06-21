using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NoSun.Models
{
    [Table("Race")]
    public class Race
    {
        [Key]
        public int RaceId { get; set; }
        public string Name { get; set; }
        [Display(Name = "Attack:")]
        public int AtkMod { get; set; }
        [Display(Name = "Defense:")]
        public int DefMod { get; set; }
        [Display(Name = "Speed:")]
        public int SpdMod { get; set; }

    }
}