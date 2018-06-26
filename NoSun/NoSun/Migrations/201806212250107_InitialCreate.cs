namespace NoSun.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Armor",
                c => new
                    {
                        ArmorId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Atk = c.Int(nullable: false),
                        Def = c.Int(nullable: false),
                        Spd = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ArmorId);
            
            CreateTable(
                "dbo.Personagem",
                c => new
                    {
                        PersonagemId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Atk = c.Int(nullable: false),
                        Def = c.Int(nullable: false),
                        Spd = c.Int(nullable: false),
                        Hp = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PersonagemId);
            
            CreateTable(
                "dbo.Equip",
                c => new
                    {
                        EquipId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Atk = c.Int(nullable: false),
                        Def = c.Int(nullable: false),
                        Spd = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EquipId);
            
            CreateTable(
                "dbo.Monster",
                c => new
                    {
                        MonsterId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Atk = c.Int(nullable: false),
                        Def = c.Int(nullable: false),
                        Spd = c.Int(nullable: false),
                        Hp = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MonsterId);
            
            CreateTable(
                "dbo.Race",
                c => new
                    {
                        RaceId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AtkMod = c.Int(nullable: false),
                        DefMod = c.Int(nullable: false),
                        SpdMod = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RaceId);
            
            CreateTable(
                "dbo.Weapon",
                c => new
                    {
                        WeaponId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Atk = c.Int(nullable: false),
                        Def = c.Int(nullable: false),
                        Spd = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WeaponId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Weapon");
            DropTable("dbo.Race");
            DropTable("dbo.Monster");
            DropTable("dbo.Equip");
            DropTable("dbo.Personagem");
            DropTable("dbo.Armor");
        }
    }
}
