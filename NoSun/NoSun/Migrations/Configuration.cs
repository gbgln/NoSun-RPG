namespace NoSun.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using NoSun.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<NoSun.DAL.RPGContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            //ContextKey = "NoSun.DAL.RPGContext";
        }

        protected override void Seed(NoSun.DAL.RPGContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Regions.AddOrUpdate(
                p => p.RegionName,
                new Region
                {
                    RegionName = "Reino1",
                    NPCs = new List<NPC> {
                        new NPC{NPCName = "John"},
                        new NPC{NPCName = "Paul"},
                        new NPC{NPCName = "George"},
                        new NPC{NPCName = "Ringo"}
                    }

                },

                new Region
                {
                    RegionName = "Cidade1",
                    NPCs = new List<NPC>
                    {
                        new NPC{NPCName = "Jason"},
                        new NPC{NPCName = "Billy"},
                        new NPC{NPCName = "Zack"},
                        new NPC{NPCName = "Kimberly"},
                        new NPC{NPCName = "Trinny"}
                    }
                },

                new Region
                {
                    RegionName = "Ilha1",
                    NPCs = new List<NPC>
                    {
                        new NPC{NPCName = "Donald"},
                        new NPC{NPCName = "Sora"},
                        new NPC{NPCName = "Goofy"}
                    }
                },

                 new Region
                 {
                     RegionName = "Books",
                     NPCs = new List<NPC>
                    {
                        new NPC{NPCName = "Anthony"},
                        new NPC{NPCName = "Flea"},
                        new NPC{NPCName = "John"},
                        new NPC{NPCName = "Chad"}
                    }
                 }

                );
        }
    }
}
