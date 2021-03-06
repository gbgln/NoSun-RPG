﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NoSun.Models
{
    public class Reward
    {
        //[Key]
        [Display(Name = "ID: ")]
        public int RewardID { get; set; }
        [Display(Name = "Reward: ")]
        public string RewardDesc { get; set; }

        [Display(Name = "Region: ")]
        public int RegionID { get; set; }
        [ForeignKey("RegionID")]
        public virtual Region _Region { get; set; }

        [Display(Name = "Giver: ")]
        public int NPCID { get; set; }
        [ForeignKey("NPCID")]
        public NPC _NPC { get; set; }
        
    }
}