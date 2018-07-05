using NoSun.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace NoSun.DAL
{
    public class RPGContext : DbContext
    {
        public RPGContext() : base("RPGContext")
        {
        }

        public DbSet<Character> Characters { get; set; }
        public DbSet<Armor> Armors { get; set; }
        public DbSet<Equip> Equips { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Monster> Monsters { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Reward> Rewards { get; set; }
        public DbSet<NPC> NPCs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Region>().HasRequired(c => c.NPCs).WithMany().WillCascadeOnDelete(false);

            //modelBuilder.Entity<NPC>().HasRequired(s => s._Region).WithMany().WillCascadeOnDelete(false);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}