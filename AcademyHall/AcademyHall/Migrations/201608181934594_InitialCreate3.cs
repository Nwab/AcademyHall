namespace AcademyHall.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StaffDetail", "PlaceOfBirth", c => c.String());
            AddColumn("dbo.StaffDetail", "HomeAdddress", c => c.String(nullable: false));
            AddColumn("dbo.StaffDetail", "Gender", c => c.String());
            AddColumn("dbo.StaffDetail", "Telephone", c => c.String());
            AddColumn("dbo.StaffDetail", "MobilePhone", c => c.String(nullable: false));
            AddColumn("dbo.StaffDetail", "DateOfHire", c => c.DateTime(nullable: false));
            AddColumn("dbo.StudentDetail", "PlaceOfBirth", c => c.String());
            AddColumn("dbo.StudentDetail", "Gender", c => c.String(nullable: false));
            AddColumn("dbo.StudentDetail", "Address", c => c.String(nullable: false));
            AddColumn("dbo.StudentDetail", "Telephone", c => c.String());
            AddColumn("dbo.StudentDetail", "MobilePhone", c => c.String());
            AddColumn("dbo.StudentDetail", "FatherFullName", c => c.String());
            AddColumn("dbo.StudentDetail", "MotherFullName", c => c.String());
            AddColumn("dbo.StudentDetail", "FatherMobilePhone", c => c.String());
            AddColumn("dbo.StudentDetail", "MotherMobilePhone", c => c.String());
            AddColumn("dbo.StudentDetail", "FatherProfession", c => c.String());
            AddColumn("dbo.StudentDetail", "MotherProfession", c => c.String());
            AddColumn("dbo.StudentDetail", "FatherPlaceOfWork", c => c.String());
            AddColumn("dbo.StudentDetail", "MotherPlaceOfWork", c => c.String());
            AddColumn("dbo.StudentDetail", "Observations", c => c.String(nullable: false));
            AlterColumn("dbo.StudentDetail", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.StudentDetail", "LastName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StudentDetail", "LastName", c => c.String());
            AlterColumn("dbo.StudentDetail", "FirstName", c => c.String());
            DropColumn("dbo.StudentDetail", "Observations");
            DropColumn("dbo.StudentDetail", "MotherPlaceOfWork");
            DropColumn("dbo.StudentDetail", "FatherPlaceOfWork");
            DropColumn("dbo.StudentDetail", "MotherProfession");
            DropColumn("dbo.StudentDetail", "FatherProfession");
            DropColumn("dbo.StudentDetail", "MotherMobilePhone");
            DropColumn("dbo.StudentDetail", "FatherMobilePhone");
            DropColumn("dbo.StudentDetail", "MotherFullName");
            DropColumn("dbo.StudentDetail", "FatherFullName");
            DropColumn("dbo.StudentDetail", "MobilePhone");
            DropColumn("dbo.StudentDetail", "Telephone");
            DropColumn("dbo.StudentDetail", "Address");
            DropColumn("dbo.StudentDetail", "Gender");
            DropColumn("dbo.StudentDetail", "PlaceOfBirth");
            DropColumn("dbo.StaffDetail", "DateOfHire");
            DropColumn("dbo.StaffDetail", "MobilePhone");
            DropColumn("dbo.StaffDetail", "Telephone");
            DropColumn("dbo.StaffDetail", "Gender");
            DropColumn("dbo.StaffDetail", "HomeAdddress");
            DropColumn("dbo.StaffDetail", "PlaceOfBirth");
        }
    }
}
