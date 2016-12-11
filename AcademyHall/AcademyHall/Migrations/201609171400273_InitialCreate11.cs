namespace AcademyHall.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate11 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LGA",
                c => new
                    {
                        LgaID = c.Int(nullable: false, identity: true),
                        LGAName = c.String(nullable: false, maxLength: 140),
                        StateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LgaID)
                .ForeignKey("dbo.State", t => t.StateId)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.State",
                c => new
                    {
                        StateId = c.Int(nullable: false, identity: true),
                        StateName = c.String(maxLength: 140),
                        StateCapital = c.String(maxLength: 140),
                    })
                .PrimaryKey(t => t.StateId);
            
            CreateTable(
                "dbo.Bank",
                c => new
                    {
                        BankId = c.Int(nullable: false, identity: true),
                        BankName = c.String(),
                        BankCode = c.String(),
                        BankSortCode = c.String(),
                    })
                .PrimaryKey(t => t.BankId);
            
            AddColumn("dbo.StudentDetail", "LGAOfOriginID", c => c.Int());
            CreateIndex("dbo.StudentDetail", "LGAOfOriginID");
            AddForeignKey("dbo.StudentDetail", "LGAOfOriginID", "dbo.LGA", "LgaID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentDetail", "LGAOfOriginID", "dbo.LGA");
            DropForeignKey("dbo.LGA", "StateId", "dbo.State");
            DropIndex("dbo.LGA", new[] { "StateId" });
            DropIndex("dbo.StudentDetail", new[] { "LGAOfOriginID" });
            DropColumn("dbo.StudentDetail", "LGAOfOriginID");
            DropTable("dbo.Bank");
            DropTable("dbo.State");
            DropTable("dbo.LGA");
        }
    }
}
