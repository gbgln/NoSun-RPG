using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NoSun.Models
{
    public class Level
    {
        [Key]
        public int LevelId { get; set; }
        public string Lvl { get; set; }

        public virtual IEnumerable<Reward> Rewards { get; set; }
    }
}