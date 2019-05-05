namespace ITI.Smart.UI.EF.CF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateUserVisitsTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserCities", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserCities", "City_Id", "dbo.Cities");
            DropIndex("dbo.UserCities", new[] { "User_Id" });
            DropIndex("dbo.UserCities", new[] { "City_Id" });
            CreateTable(
                "dbo.UserVisits",
                c => new
                    {
                        Fk_UserId = c.Int(nullable: false),
                        Fk_CityId = c.Int(nullable: false),
                        when = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.Fk_UserId, t.Fk_CityId })
                .ForeignKey("dbo.Cities", t => t.Fk_CityId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Fk_UserId, cascadeDelete: true)
                .Index(t => t.Fk_UserId)
                .Index(t => t.Fk_CityId);
            
            DropTable("dbo.UserCities");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserCities",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        City_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.City_Id });
            
            DropForeignKey("dbo.UserVisits", "Fk_UserId", "dbo.Users");
            DropForeignKey("dbo.UserVisits", "Fk_CityId", "dbo.Cities");
            DropIndex("dbo.UserVisits", new[] { "Fk_CityId" });
            DropIndex("dbo.UserVisits", new[] { "Fk_UserId" });
            DropTable("dbo.UserVisits");
            CreateIndex("dbo.UserCities", "City_Id");
            CreateIndex("dbo.UserCities", "User_Id");
            AddForeignKey("dbo.UserCities", "City_Id", "dbo.Cities", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserCities", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
