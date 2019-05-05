namespace ITI.Smart.UI.EF.CF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterUserTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Users", newName: "User");
            AlterColumn("dbo.User", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "Name", c => c.String());
            RenameTable(name: "dbo.User", newName: "Users");
        }
    }
}
