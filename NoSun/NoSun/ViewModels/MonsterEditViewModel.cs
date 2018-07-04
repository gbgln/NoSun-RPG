using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NoSun.ViewModels
{
    public class MonsterEditViewModel
    {
        [Display(Name = "Monster Number")]
        public string MonsterID { get; set; }

        [Required]
        [Display(Name = "Monster Name")]
        [StringLength(75)]
        public string MonsterName { get; set; }

        [Required]
        [Display(Name = "Level: ")]
        public string SelectedLevel { get; set; }
        public IEnumerable<SelectListItem> Levels { get; set; }

        [Required]
        [Display(Name = "Reward: ")]
        public string SelectedReward { get; set; }
        public IEnumerable<SelectListItem> Rewards { get; set; }

    }
}