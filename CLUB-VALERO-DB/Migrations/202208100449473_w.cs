namespace CLUB_VALERO_DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class w : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "Data", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Members", "Data");
        }
    }
}
