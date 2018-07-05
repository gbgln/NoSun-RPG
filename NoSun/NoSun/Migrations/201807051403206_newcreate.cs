namespace NoSun.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newcreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NPC",
                c => new
                    {
                        NPCID = c.Int(nullable: false, identity: true),
                        NPCName = c.String(),
                        RegionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NPCID)
                .ForeignKey("dbo.Region", t => t.RegionID, cascadeDelete: false)
                .Index(t => t.RegionID);
            
            CreateTable(
                "dbo.Region",
                c => new
                    {
                        RegionID = c.Int(nullable: false, identity: true),
                        RegionName = c.String(),
                    })
                .PrimaryKey(t => t.RegionID);
            
            CreateTable(
                "dbo.Reward",
                c => new
                    {
                        RewardID = c.Int(nullable: false, identity: true),
                        RewardDesc = c.String(),
                        RegionID = c.Int(nullable: false),
                        NPCID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RewardID)
                .ForeignKey("dbo.NPC", t => t.NPCID, cascadeDelete: false)
                .ForeignKey("dbo.Region", t => t.RegionID, cascadeDelete: false)
                .Index(t => t.RegionID)
                .Index(t => t.NPCID);
            
            CreateIndex("dbo.Personagem", "RaceID");
            CreateIndex("dbo.Personagem", "ArmorID");
            CreateIndex("dbo.Personagem", "WeaponID");
            CreateIndex("dbo.Personagem", "EquipID");
            AddForeignKey("dbo.Personagem", "ArmorID", "dbo.Armor", "ArmorId", cascadeDelete: true);
            AddForeignKey("dbo.Personagem", "EquipID", "dbo.Equip", "EquipId", cascadeDelete: true);
            AddForeignKey("dbo.Personagem", "RaceID", "dbo.Race", "RaceId", cascadeDelete: true);
            AddForeignKey("dbo.Personagem", "WeaponID", "dbo.Weapon", "WeaponId", cascadeDelete: true);
            DropColumn("dbo.Personagem", "Atk");
            DropColumn("dbo.Personagem", "Def");
            DropColumn("dbo.Personagem", "Spd");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Personagem", "Spd", c => c.Int(nullable: false));
            AddColumn("dbo.Personagem", "Def", c => c.Int(nullable: false));
            AddColumn("dbo.Personagem", "Atk", c => c.Int(nullable: false));
            DropForeignKey("dbo.Reward", "RegionID", "dbo.Region");
            DropForeignKey("dbo.Reward", "NPCID", "dbo.NPC");
            DropForeignKey("dbo.NPC", "RegionID", "dbo.Region");
            DropForeignKey("dbo.Personagem", "WeaponID", "dbo.Weapon");
            DropForeignKey("dbo.Personagem", "RaceID", "dbo.Race");
            DropForeignKey("dbo.Personagem", "EquipID", "dbo.Equip");
            DropForeignKey("dbo.Personagem", "ArmorID", "dbo.Armor");
            DropIndex("dbo.Reward", new[] { "NPCID" });
            DropIndex("dbo.Reward", new[] { "RegionID" });
            DropIndex("dbo.NPC", new[] { "RegionID" });
            DropIndex("dbo.Personagem", new[] { "EquipID" });
            DropIndex("dbo.Personagem", new[] { "WeaponID" });
            DropIndex("dbo.Personagem", new[] { "ArmorID" });
            DropIndex("dbo.Personagem", new[] { "RaceID" });
            DropTable("dbo.Reward");
            DropTable("dbo.Region");
            DropTable("dbo.NPC");
        }
    }
}
