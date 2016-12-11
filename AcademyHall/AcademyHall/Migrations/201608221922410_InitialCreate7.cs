namespace AcademyHall.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StudentDetail", "ParentGuardianId", "dbo.ParentGuradian");
            DropIndex("dbo.StudentDetail", new[] { "ParentGuardianId" });
            CreateTable(
                "dbo.ParentGuardianStudent",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StudentDetailID = c.Int(nullable: false),
                        ParentGuardianID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ParentGuradian", t => t.ParentGuardianID)
                .ForeignKey("dbo.StudentDetail", t => t.StudentDetailID)
                .Index(t => t.StudentDetailID)
                .Index(t => t.ParentGuardianID);
            
            AddColumn("dbo.StudentDetail", "AcademyUserId", c => c.Int(nullable: false));
            CreateIndex("dbo.StudentDetail", "AcademyUserId");
            AddForeignKey("dbo.StudentDetail", "AcademyUserId", "dbo.AcademyUserProfile", "Id");
            DropColumn("dbo.StudentDetail", "ParentGuardianId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StudentDetail", "ParentGuardianId", c => c.Int());
            DropForeignKey("dbo.ParentGuardianStudent", "StudentDetailID", "dbo.StudentDetail");
            DropForeignKey("dbo.ParentGuardianStudent", "ParentGuardianID", "dbo.ParentGuradian");
            DropForeignKey("dbo.StudentDetail", "AcademyUserId", "dbo.AcademyUserProfile");
            DropIndex("dbo.ParentGuardianStudent", new[] { "ParentGuardianID" });
            DropIndex("dbo.ParentGuardianStudent", new[] { "StudentDetailID" });
            DropIndex("dbo.StudentDetail", new[] { "AcademyUserId" });
            DropColumn("dbo.StudentDetail", "AcademyUserId");
            DropTable("dbo.ParentGuardianStudent");
            CreateIndex("dbo.StudentDetail", "ParentGuardianId");
            AddForeignKey("dbo.StudentDetail", "ParentGuardianId", "dbo.ParentGuradian", "Id");
        }
    }
}
