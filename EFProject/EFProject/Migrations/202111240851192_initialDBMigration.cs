namespace EFProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialDBMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MunicipalityClasses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MunicipalityName = c.String(),
                        RegionClass_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RegionClasses", t => t.RegionClass_Id, cascadeDelete: true)
                .Index(t => t.RegionClass_Id);
            
            CreateTable(
                "dbo.RegionClasses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegionName = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.RegionName, unique: true, name: "RegionName");
            
            CreateTable(
                "dbo.SettlementClasses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SettlementName = c.String(),
                        Municipality_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MunicipalityClasses", t => t.Municipality_Id, cascadeDelete: true)
                .Index(t => t.Municipality_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SettlementClasses", "Municipality_Id", "dbo.MunicipalityClasses");
            DropForeignKey("dbo.MunicipalityClasses", "RegionClass_Id", "dbo.RegionClasses");
            DropIndex("dbo.SettlementClasses", new[] { "Municipality_Id" });
            DropIndex("dbo.RegionClasses", "RegionName");
            DropIndex("dbo.MunicipalityClasses", new[] { "RegionClass_Id" });
            DropTable("dbo.SettlementClasses");
            DropTable("dbo.RegionClasses");
            DropTable("dbo.MunicipalityClasses");
        }
    }
}
