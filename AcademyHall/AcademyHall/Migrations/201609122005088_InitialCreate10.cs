namespace AcademyHall.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuditRecordField",
                c => new
                    {
                        AuditFldId = c.Int(nullable: false, identity: true),
                        AuditRecordId = c.Int(),
                        MemberName = c.String(maxLength: 4000),
                        OldValue = c.String(),
                        NewValue = c.String(),
                    })
                .PrimaryKey(t => t.AuditFldId)
                .ForeignKey("dbo.AuditRecord", t => t.AuditRecordId)
                .Index(t => t.AuditRecordId);
            
            CreateTable(
                "dbo.AuditRecord",
                c => new
                    {
                        AuditRecordId = c.Int(nullable: false, identity: true),
                        UserAction = c.String(),
                        TableName = c.String(maxLength: 140),
                        TableKey = c.String(),
                        Username = c.String(nullable: false, maxLength: 140),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AuditRecordId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AuditRecordField", "AuditRecordId", "dbo.AuditRecord");
            DropIndex("dbo.AuditRecordField", new[] { "AuditRecordId" });
            DropTable("dbo.AuditRecord");
            DropTable("dbo.AuditRecordField");
        }
    }
}
