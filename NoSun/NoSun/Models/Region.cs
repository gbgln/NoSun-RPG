using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NoSun.Models
{
    public class Region
    {
        //[Key]
        [Display(Name = "ID: ")]
        public int RegionID { get; set; }
        [Display(Name = "Region: ")]
        public string RegionName { get; set; }

        public List<NPC> NPCs { get; set; }
    }
}