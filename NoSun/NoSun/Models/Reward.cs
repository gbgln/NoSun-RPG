using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NoSun.Models
{
    public class Reward
    {
        [Key]
        public int RewardId { get; set; }

        [Required]
        public int LevelID { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual Level _Level { get; set; }
    }
}