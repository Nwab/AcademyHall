namespace AcademyHall.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ParentGuradian",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        DateRegistered = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AcademyRole",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleDescription = c.String(),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AcademyUserRole",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AcademyRole", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AcademyUserProfile", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.StaffDetail",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentDetail",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        DateRegistered = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AcademyUserProfile",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        studentID = c.String(),
                        StaffID = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AcademyUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AcademyUserProfile", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AcademyUserLogin",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AcademyUserProfile", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AcademyUserRole", "UserId", "dbo.AcademyUserProfile");
            DropForeignKey("dbo.AcademyUserLogin", "UserId", "dbo.AcademyUserProfile");
            DropForeignKey("dbo.AcademyUserClaim", "UserId", "dbo.AcademyUserProfile");
            DropForeignKey("dbo.AcademyUserRole", "RoleId", "dbo.AcademyRole");
            DropIndex("dbo.AcademyUserLogin", new[] { "UserId" });
            DropIndex("dbo.AcademyUserClaim", new[] { "UserId" });
            DropIndex("dbo.AcademyUserProfile", "UserNameIndex");
            DropIndex("dbo.AcademyUserRole", new[] { "RoleId" });
            DropIndex("dbo.AcademyUserRole", new[] { "UserId" });
            DropIndex("dbo.AcademyRole", "RoleNameIndex");
            DropTable("dbo.AcademyUserLogin");
            DropTable("dbo.AcademyUserClaim");
            DropTable("dbo.AcademyUserProfile");
            DropTable("dbo.StudentDetail");
            DropTable("dbo.StaffDetail");
            DropTable("dbo.AcademyUserRole");
            DropTable("dbo.AcademyRole");
            DropTable("dbo.ParentGuradian");
        }
    }
}
