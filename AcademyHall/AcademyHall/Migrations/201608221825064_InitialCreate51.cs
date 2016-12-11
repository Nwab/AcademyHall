namespace AcademyHall.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate51 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.StudentDetail", new[] { "ParentGuardianId" });
            AddColumn("dbo.ParentGuradian", "PhoneNumber", c => c.String());
            AddColumn("dbo.ParentGuradian", "ContactAddress", c => c.String());
            AddColumn("dbo.ParentGuradian", "HouseAddress", c => c.String());
            AlterColumn("dbo.StudentDetail", "ParentGuardianId", c => c.Int());
            CreateIndex("dbo.StudentDetail", "ParentGuardianId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.StudentDetail", new[] { "ParentGuardianId" });
            AlterColumn("dbo.StudentDetail", "ParentGuardianId", c => c.Int(nullable: false));
            DropColumn("dbo.ParentGuradian", "HouseAddress");
            DropColumn("dbo.ParentGuradian", "ContactAddress");
            DropColumn("dbo.ParentGuradian", "PhoneNumber");
            CreateIndex("dbo.StudentDetail", "ParentGuardianId");
        }
    }
}
