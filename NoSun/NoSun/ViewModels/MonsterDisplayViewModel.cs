using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NoSun.ViewModels
{
    public class MonsterDisplayViewModel
    {
        [Display(Name = "Monster Number")]
        public Guid MonsterID { get; set; }

        [Display(Name = "Monster Name")]
        public string MonsterName { get; set; }

        [Display(Name = "Level")]
        public string LevelName { get; set; }

        [Display(Name = "Reward")]
        public string RewardName { get; set; }


    }
}