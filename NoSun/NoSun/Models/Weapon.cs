﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NoSun.Models
{
    [Table("Weapon")]
    public class Weapon
    {
        [Key]
        public int WeaponId { get; set; }
        [Display(Name = "Weapon:")]
        public string Name { get; set; }
        [Display(Name = "Attack:")]
        public int Atk { get; set; }
        [Display(Name = "Defense:")]
        public int Def { get; set; }
        [Display(Name = "Speed:")]
        public int Spd { get; set; }

        public string WeaponToString
        {
            get
            {
                return Name + ", ATK: " + Atk.ToString() + ", DEF: " + Def.ToString() + ", SPD: " + Spd.ToString();
            }
        }
    }
}