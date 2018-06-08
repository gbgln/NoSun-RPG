﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NoSun.Models
{
    [Table("Personagem")]
    public class Character
    {
        [Key]
        public int PersonagemId { get; set; }
        public string Name { get; set; }
        [Display(Name = "Attack:")]
        public int Atk { get; set; }
        [Display(Name = "Defense:")]
        public int Def { get; set; }
        [Display(Name = "Speed:")]
        public int Spd { get; set; }
        public int Hp { get; set; }
    }
}