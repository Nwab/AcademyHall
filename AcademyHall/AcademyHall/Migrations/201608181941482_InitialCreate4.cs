namespace AcademyHall.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ParentGuradian", "AcademyUserId", "dbo.AcademyUserProfile");
            DropForeignKey("dbo.AcademyUserClaim", "UserId", "dbo.AcademyUserProfile");
            DropForeignKey("dbo.AcademyUserLogin", "UserId", "dbo.AcademyUserProfile");
            DropForeignKey("dbo.AcademyUserRole", "UserId", "dbo.AcademyUserProfile");
            DropForeignKey("dbo.AcademyUserRole", "RoleId", "dbo.AcademyRole");
            DropForeignKey("dbo.StaffDetail", "AcademyUserId", "dbo.AcademyUserProfile");
            DropForeignKey("dbo.StudentDetail", "ParentGuardianId", "dbo.ParentGuradian");
            CreateTable(
                "dbo.AssessmentType",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Attendance",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Attended = c.Boolean(nullable: false),
                        DateAttended = c.DateTime(nullable: false),
                        StudentDetailId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.StudentDetail", t => t.StudentDetailId)
                .Index(t => t.StudentDetailId);
            
            CreateTable(
                "dbo.GradeLevel",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Principle = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Grade",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Observation = c.String(),
                        GradeLevelID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.GradeLevel", t => t.GradeLevelID)
                .Index(t => t.GradeLevelID);
            
            CreateTable(
                "dbo.ScoreRecord",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StudentDetailID = c.Int(nullable: false),
                        SubjectID = c.Int(nullable: false),
                        FinalCumulativeGrade = c.String(),
                        TrimesterAssessmentBreakDownID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.StudentDetail", t => t.StudentDetailID)
                .ForeignKey("dbo.Subject", t => t.SubjectID)
                .ForeignKey("dbo.TrimesterAssessmentBreakDown", t => t.TrimesterAssessmentBreakDownID)
                .Index(t => t.StudentDetailID)
                .Index(t => t.SubjectID)
                .Index(t => t.TrimesterAssessmentBreakDownID);
            
            CreateTable(
                "dbo.Subject",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SubjAbbreviation = c.String(),
                        SubjectAreaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.SubjectArea", t => t.SubjectAreaID)
                .Index(t => t.SubjectAreaID);
            
            CreateTable(
                "dbo.SubjectArea",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TrimesterAssessmentBreakDown",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AssessmentScore = c.Int(nullable: false),
                        AssessmentDescription = c.String(),
                        DateAssessmentCreated = c.DateTime(nullable: false),
                        AssessmentTypeID = c.Int(nullable: false),
                        TrimesterNameID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AssessmentType", t => t.AssessmentTypeID)
                .ForeignKey("dbo.TrimesterName", t => t.AssessmentTypeID)
                .Index(t => t.AssessmentTypeID);
            
            CreateTable(
                "dbo.TrimesterName",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.StudentGradeHistory",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StudentDetailID = c.Int(nullable: false),
                        GradeID = c.Int(nullable: false),
                        StaffDetailID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Grade", t => t.GradeID)
                .ForeignKey("dbo.StaffDetail", t => t.StaffDetailID)
                .ForeignKey("dbo.StudentDetail", t => t.StudentDetailID)
                .Index(t => t.StudentDetailID)
                .Index(t => t.GradeID)
                .Index(t => t.StaffDetailID);
            
            CreateTable(
                "dbo.SubjectGrade",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SubjectId = c.Int(nullable: false),
                        GradeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Grade", t => t.GradeID)
                .ForeignKey("dbo.Subject", t => t.SubjectId)
                .Index(t => t.SubjectId)
                .Index(t => t.GradeID);
            
            AddForeignKey("dbo.ParentGuradian", "AcademyUserId", "dbo.AcademyUserProfile", "Id");
            AddForeignKey("dbo.AcademyUserClaim", "UserId", "dbo.AcademyUserProfile", "Id");
            AddForeignKey("dbo.AcademyUserLogin", "UserId", "dbo.AcademyUserProfile", "Id");
            AddForeignKey("dbo.AcademyUserRole", "UserId", "dbo.AcademyUserProfile", "Id");
            AddForeignKey("dbo.AcademyUserRole", "RoleId", "dbo.AcademyRole", "Id");
            AddForeignKey("dbo.StaffDetail", "AcademyUserId", "dbo.AcademyUserProfile", "Id");
            AddForeignKey("dbo.StudentDetail", "ParentGuardianId", "dbo.ParentGuradian", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentDetail", "ParentGuardianId", "dbo.ParentGuradian");
            DropForeignKey("dbo.StaffDetail", "AcademyUserId", "dbo.AcademyUserProfile");
            DropForeignKey("dbo.AcademyUserRole", "RoleId", "dbo.AcademyRole");
            DropForeignKey("dbo.AcademyUserRole", "UserId", "dbo.AcademyUserProfile");
            DropForeignKey("dbo.AcademyUserLogin", "UserId", "dbo.AcademyUserProfile");
            DropForeignKey("dbo.AcademyUserClaim", "UserId", "dbo.AcademyUserProfile");
            DropForeignKey("dbo.ParentGuradian", "AcademyUserId", "dbo.AcademyUserProfile");
            DropForeignKey("dbo.SubjectGrade", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.SubjectGrade", "GradeID", "dbo.Grade");
            DropForeignKey("dbo.StudentGradeHistory", "StudentDetailID", "dbo.StudentDetail");
            DropForeignKey("dbo.StudentGradeHistory", "StaffDetailID", "dbo.StaffDetail");
            DropForeignKey("dbo.StudentGradeHistory", "GradeID", "dbo.Grade");
            DropForeignKey("dbo.ScoreRecord", "TrimesterAssessmentBreakDownID", "dbo.TrimesterAssessmentBreakDown");
            DropForeignKey("dbo.TrimesterAssessmentBreakDown", "AssessmentTypeID", "dbo.TrimesterName");
            DropForeignKey("dbo.TrimesterAssessmentBreakDown", "AssessmentTypeID", "dbo.AssessmentType");
            DropForeignKey("dbo.ScoreRecord", "SubjectID", "dbo.Subject");
            DropForeignKey("dbo.Subject", "SubjectAreaID", "dbo.SubjectArea");
            DropForeignKey("dbo.ScoreRecord", "StudentDetailID", "dbo.StudentDetail");
            DropForeignKey("dbo.Grade", "GradeLevelID", "dbo.GradeLevel");
            DropForeignKey("dbo.Attendance", "StudentDetailId", "dbo.StudentDetail");
            DropIndex("dbo.SubjectGrade", new[] { "GradeID" });
            DropIndex("dbo.SubjectGrade", new[] { "SubjectId" });
            DropIndex("dbo.StudentGradeHistory", new[] { "StaffDetailID" });
            DropIndex("dbo.StudentGradeHistory", new[] { "GradeID" });
            DropIndex("dbo.StudentGradeHistory", new[] { "StudentDetailID" });
            DropIndex("dbo.TrimesterAssessmentBreakDown", new[] { "AssessmentTypeID" });
            DropIndex("dbo.Subject", new[] { "SubjectAreaID" });
            DropIndex("dbo.ScoreRecord", new[] { "TrimesterAssessmentBreakDownID" });
            DropIndex("dbo.ScoreRecord", new[] { "SubjectID" });
            DropIndex("dbo.ScoreRecord", new[] { "StudentDetailID" });
            DropIndex("dbo.Grade", new[] { "GradeLevelID" });
            DropIndex("dbo.Attendance", new[] { "StudentDetailId" });
            DropTable("dbo.SubjectGrade");
            DropTable("dbo.StudentGradeHistory");
            DropTable("dbo.TrimesterName");
            DropTable("dbo.TrimesterAssessmentBreakDown");
            DropTable("dbo.SubjectArea");
            DropTable("dbo.Subject");
            DropTable("dbo.ScoreRecord");
            DropTable("dbo.Grade");
            DropTable("dbo.GradeLevel");
            DropTable("dbo.Attendance");
            DropTable("dbo.AssessmentType");
            AddForeignKey("dbo.StudentDetail", "ParentGuardianId", "dbo.ParentGuradian", "Id", cascadeDelete: true);
            AddForeignKey("dbo.StaffDetail", "AcademyUserId", "dbo.AcademyUserProfile", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AcademyUserRole", "RoleId", "dbo.AcademyRole", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AcademyUserRole", "UserId", "dbo.AcademyUserProfile", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AcademyUserLogin", "UserId", "dbo.AcademyUserProfile", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AcademyUserClaim", "UserId", "dbo.AcademyUserProfile", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ParentGuradian", "AcademyUserId", "dbo.AcademyUserProfile", "Id", cascadeDelete: true);
        }
    }
}
