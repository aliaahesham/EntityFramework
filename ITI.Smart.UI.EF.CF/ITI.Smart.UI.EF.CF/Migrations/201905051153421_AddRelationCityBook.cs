namespace ITI.Smart.UI.EF.CF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelationCityBook : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cities", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.UsersBooks", "Fk_BookId", "dbo.Books");
            DropIndex("dbo.Cities", new[] { "CountryId" });
            RenameColumn(table: "dbo.Cities", name: "CountryId", newName: "Country_Id");
            DropPrimaryKey("dbo.Books");
            AddColumn("dbo.Cities", "Fk_CountryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Books", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Cities", "Country_Id", c => c.Int());
            AddPrimaryKey("dbo.Books", "Id");
            CreateIndex("dbo.Books", "Id");
            CreateIndex("dbo.Cities", "Country_Id");
            AddForeignKey("dbo.Books", "Id", "dbo.Cities", "Id");
            AddForeignKey("dbo.Cities", "Country_Id", "dbo.Countries", "Id");
            AddForeignKey("dbo.UsersBooks", "Fk_BookId", "dbo.Books", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsersBooks", "Fk_BookId", "dbo.Books");
            DropForeignKey("dbo.Cities", "Country_Id", "dbo.Countries");
            DropForeignKey("dbo.Books", "Id", "dbo.Cities");
            DropIndex("dbo.Cities", new[] { "Country_Id" });
            DropIndex("dbo.Books", new[] { "Id" });
            DropPrimaryKey("dbo.Books");
            AlterColumn("dbo.Cities", "Country_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Books", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Cities", "Fk_CountryId");
            AddPrimaryKey("dbo.Books", "Id");
            RenameColumn(table: "dbo.Cities", name: "Country_Id", newName: "CountryId");
            CreateIndex("dbo.Cities", "CountryId");
            AddForeignKey("dbo.UsersBooks", "Fk_BookId", "dbo.Books", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Cities", "CountryId", "dbo.Countries", "Id", cascadeDelete: true);
        }
    }
}
