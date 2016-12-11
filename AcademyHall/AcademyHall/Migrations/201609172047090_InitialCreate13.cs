namespace AcademyHall.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate13 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudentDetail", "StudentRegistrationNo", c => c.String(nullable: false));
            AddColumn("dbo.StudentDetail", "EmailAddress", c => c.String());
            AddColumn("dbo.StudentDetail", "FatherEmailAddress", c => c.String());
            AddColumn("dbo.StudentDetail", "MotherEmailAddress", c => c.String());
            DropColumn("dbo.StudentDetail", "StudentID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StudentDetail", "StudentID", c => c.String(nullable: false));
            DropColumn("dbo.StudentDetail", "MotherEmailAddress");
            DropColumn("dbo.StudentDetail", "FatherEmailAddress");
            DropColumn("dbo.StudentDetail", "EmailAddress");
            DropColumn("dbo.StudentDetail", "StudentRegistrationNo");
        }
    }
}
