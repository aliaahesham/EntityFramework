namespace ITI.Smart.UI.EF.CF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelationUsersBooks : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UsersBooks",
                c => new
                    {
                        Fk_BookId = c.Int(nullable: false),
                        Fk_UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Fk_BookId, t.Fk_UserId })
                .ForeignKey("dbo.Books", t => t.Fk_BookId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.Fk_UserId, cascadeDelete: true)
                .Index(t => t.Fk_BookId)
                .Index(t => t.Fk_UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsersBooks", "Fk_UserId", "dbo.User");
            DropForeignKey("dbo.UsersBooks", "Fk_BookId", "dbo.Books");
            DropIndex("dbo.UsersBooks", new[] { "Fk_UserId" });
            DropIndex("dbo.UsersBooks", new[] { "Fk_BookId" });
            DropTable("dbo.UsersBooks");
        }
    }
}
