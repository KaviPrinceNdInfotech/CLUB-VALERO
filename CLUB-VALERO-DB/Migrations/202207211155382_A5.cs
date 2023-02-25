namespace CLUB_VALERO_DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class A5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "Test", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Members", "Test");
        }
    }
}
