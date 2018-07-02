using System;
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
        [Display(Name = "Name:")]
        public string Name { get; set; }

        [Display(Name = "Attack:")]
        public int Atk
        {
            get
            {
                return _Armor.Atk + _Race.AtkMod + _Weapon.Atk + _Equip.Atk;
            }

        }

        [Display(Name = "Defense:")]
        public int Def
        {
            get
            {
                return _Armor.Def + _Race.DefMod + _Weapon.Def + _Equip.Def;
            }

        }

        [Display(Name = "Speed:")]
        public int Spd
        {
            get
            {
                return _Armor.Spd + _Race.SpdMod + _Weapon.Spd + _Equip.Spd;
            }

        }

        [Display(Name = "HP:")]
        public int Hp { get; set; }

        [Display(Name = "Race:")]
        public int RaceID { get; set; }
        public virtual Race _Race { get; set; }

        [Display(Name = "Armor:")]
        public int ArmorID { get; set; }
        public virtual Armor _Armor { get; set; }

        [Display(Name = "Weapon:")]
        public int WeaponID { get; set; }
        public virtual Weapon _Weapon { get; set; }

        [Display(Name = "Equipment:")]
        public int EquipID { get; set; }
        public virtual Equip _Equip { get; set; }

    }
}