namespace CLUB_VALERO_DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migrations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "Email", c => c.String());
            AddColumn("dbo.Messages", "Time", c => c.String());
            DropColumn("dbo.Messages", "Profission");
            DropTable("dbo.EmiRemarks");
            DropTable("dbo.AmcRemarks");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AmcRemarks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        CreateRemark = c.String(),
                        CreateDate = c.String(),
                        CurrentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmiRemarks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        CreateRemark = c.String(),
                        CreateDate = c.String(),
                        CurrentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Messages", "Profission", c => c.String());
            DropColumn("dbo.Messages", "Time");
            DropColumn("dbo.Messages", "Email");
        }
    }
}
