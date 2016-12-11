namespace AcademyHall.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ParentGuradian", "AcademyUserId", c => c.Int(nullable: false));
            AddColumn("dbo.StaffDetail", "StaffID", c => c.String());
            AddColumn("dbo.StaffDetail", "StaffEmail", c => c.String());
            AddColumn("dbo.AcademyUserProfile", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.StudentDetail", "StudentID", c => c.String(nullable: false));
            AddColumn("dbo.StudentDetail", "ParentGuardianId", c => c.Int(nullable: false));
            AlterColumn("dbo.StaffDetail", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.StaffDetail", "LastName", c => c.String(nullable: false));
            CreateIndex("dbo.ParentGuradian", "AcademyUserId");
            CreateIndex("dbo.StudentDetail", "ParentGuardianId");
            AddForeignKey("dbo.ParentGuradian", "AcademyUserId", "dbo.AcademyUserProfile", "Id", cascadeDelete: true);
            AddForeignKey("dbo.StudentDetail", "ParentGuardianId", "dbo.ParentGuradian", "Id", cascadeDelete: true);
            DropColumn("dbo.ParentGuradian", "DateRegistered");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ParentGuradian", "DateRegistered", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.StudentDetail", "ParentGuardianId", "dbo.ParentGuradian");
            DropForeignKey("dbo.ParentGuradian", "AcademyUserId", "dbo.AcademyUserProfile");
            DropIndex("dbo.StudentDetail", new[] { "ParentGuardianId" });
            DropIndex("dbo.ParentGuradian", new[] { "AcademyUserId" });
            AlterColumn("dbo.StaffDetail", "LastName", c => c.String());
            AlterColumn("dbo.StaffDetail", "FirstName", c => c.String());
            DropColumn("dbo.StudentDetail", "ParentGuardianId");
            DropColumn("dbo.StudentDetail", "StudentID");
            DropColumn("dbo.AcademyUserProfile", "DateCreated");
            DropColumn("dbo.StaffDetail", "StaffEmail");
            DropColumn("dbo.StaffDetail", "StaffID");
            DropColumn("dbo.ParentGuradian", "AcademyUserId");
        }
    }
}
