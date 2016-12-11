namespace AcademyHall.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StaffDetail", "AcademyUserId", c => c.Int(nullable: false));
            CreateIndex("dbo.StaffDetail", "AcademyUserId");
            AddForeignKey("dbo.StaffDetail", "AcademyUserId", "dbo.AcademyUserProfile", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StaffDetail", "AcademyUserId", "dbo.AcademyUserProfile");
            DropIndex("dbo.StaffDetail", new[] { "AcademyUserId" });
            DropColumn("dbo.StaffDetail", "AcademyUserId");
        }
    }
}
