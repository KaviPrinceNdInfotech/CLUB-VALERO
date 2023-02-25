namespace CLUB_VALERO_DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class h1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Remarks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        CreateRemark = c.String(),
                        CreateDate = c.String(),
                        CurrentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Remarks");
        }
    }
}
