﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NoSun.Models
{
    [Table("Armor")]
    public class Armor
    {
        [Key]
        public int ArmorId { get; set; }
        [Display(Name = "Armor:")]
        public string Name { get; set; }
        [Display(Name = "Attack:")]
        public int Atk { get; set; }
        [Display(Name = "Defense:")]
        public int Def { get; set; }
        [Display(Name = "Speed:")]
        public int Spd { get; set; }

        public string ArmorToString
        {
            get
            {
                return Name + ", ATK: " + Atk.ToString() + ", DEF: " + Def.ToString() + ", SPD: " + Spd.ToString();
            }
        }
    }
}