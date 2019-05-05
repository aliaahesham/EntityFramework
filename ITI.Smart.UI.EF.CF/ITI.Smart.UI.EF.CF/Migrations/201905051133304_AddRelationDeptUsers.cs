namespace ITI.Smart.UI.EF.CF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelationDeptUsers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "Fk_DepartmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.User", "Fk_DepartmentId");
            AddForeignKey("dbo.User", "Fk_DepartmentId", "dbo.Department", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "Fk_DepartmentId", "dbo.Department");
            DropIndex("dbo.User", new[] { "Fk_DepartmentId" });
            DropColumn("dbo.User", "Fk_DepartmentId");
        }
    }
}
