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

        [Display(Name = "Attack:"), NotMapped]
        public int Atk
        {
            get
            {
                int _atk = 0;

                if (_Armor != null)
                    _atk += _Armor.Atk;
                else _atk += 0;

                if (_Race != null)
                    _atk += _Race.AtkMod;
                else _atk += 0;

                if (_Equip != null)
                    _atk += _Equip.Atk;
                else _atk += 0;

                if (_Weapon != null)
                    _atk += _Weapon.Atk;
                else _atk += 0;
                //if (_Armor != null && _Race != null && _Weapon != null && _Equip != null)

                return _atk;
            }

        }

        [Display(Name = "Defense:")]
        public int Def
        {
            get
            {
                int _def = 0;

                if (_Armor != null)
                    _def += _Armor.Def;
                else _def += 0;

                if (_Race != null)
                    _def += _Race.DefMod;
                else _def += 0;

                if (_Equip != null)
                    _def += _Equip.Def;
                else _def += 0;

                if (_Weapon != null)
                    _def += _Weapon.Def;
                else _def += 0;

                return _def;

                //return _Armor.Def + _Race.DefMod + _Weapon.Def + _Equip.Def;
            }

        }

        [Display(Name = "Speed:")]
        public int Spd
        {
            get
            {
                int _spd = 0;

                if (_Armor != null)
                    _spd += _Armor.Spd;
                else _spd += 0;

                if (_Race != null)
                    _spd += _Race.SpdMod;
                else _spd += 0;

                if (_Equip != null)
                    _spd += _Equip.Spd;
                else _spd += 0;

                if (_Weapon != null)
                    _spd += _Weapon.Spd;
                else _spd += 0;

                return _spd;

                //    return _Armor.Spd + _Race.SpdMod + _Weapon.Spd + _Equip.Spd;
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