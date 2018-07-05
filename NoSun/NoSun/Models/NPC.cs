using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NoSun.Models
{
    public class NPC
    {
        //[Key]
        [Display(Name = "ID: ")]
        public int NPCID { get; set; }
        [Display(Name = "NPC Name: ")]
        public string NPCName { get; set; }

        [Display(Name = "Region: ")]
        public int RegionID { get; set; }

        [ForeignKey("RegionID")]
        public virtual Region _Region { get; set; }

        
    }
}