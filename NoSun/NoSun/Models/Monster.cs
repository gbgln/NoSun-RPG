using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NoSun.Models
{
    [Table("Monster")]
    public class Monster
    {
        [Key]
        public Guid MonsterId { get; set; }
        public string Name { get; set; }
        [Display(Name = "Attack:")]
        public int Atk { get; set; }
        [Display(Name = "Defense:")]
        public int Def { get; set; }
        [Display(Name = "Speed:")]
        public int Spd { get; set; }
        public int Hp { get; set; }

        public int LevelID { get; set; }
        public int RewardID { get; set; }

        public virtual Level _Level { get; set; }

        public virtual Reward _Reward { get; set; }

    }
}