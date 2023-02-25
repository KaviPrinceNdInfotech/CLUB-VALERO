namespace CLUB_VALERO_DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class A7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "MobileNo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "MobileNo");
        }
    }
}
