namespace NoSun.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correction : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Personagem", "RaceID", c => c.Int(nullable: false));
            AddColumn("dbo.Personagem", "ArmorID", c => c.Int(nullable: false));
            AddColumn("dbo.Personagem", "WeaponID", c => c.Int(nullable: false));
            AddColumn("dbo.Personagem", "EquipID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Personagem", "EquipID");
            DropColumn("dbo.Personagem", "WeaponID");
            DropColumn("dbo.Personagem", "ArmorID");
            DropColumn("dbo.Personagem", "RaceID");
        }
    }
}
