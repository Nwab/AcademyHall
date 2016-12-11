namespace AcademyHall.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ParentGuradian", "Relationship", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ParentGuradian", "Relationship");
        }
    }
}
