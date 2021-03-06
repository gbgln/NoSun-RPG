﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NoSun.Models
{
    [Table("Equip")]
    public class Equip
    {
        [Key]
        public int EquipId { get; set; }
        [Display(Name = "Equipment:")]
        public string Name { get; set; }
        [Display (Name = "Attack:")]
        public int Atk { get; set; }
        [Display(Name = "Defense:")]
        public int Def { get; set; }
        [Display(Name = "Speed:")]
        public int Spd { get; set; }

        public string EquipToString
        {
            get
            {
                return Name + ", ATK: " + Atk.ToString() + ", DEF: " + Def.ToString() + ", SPD: " + Spd.ToString();
            }
        }
    }
}