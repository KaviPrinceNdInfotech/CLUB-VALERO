namespace CLUB_VALERO_DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class k1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Members", "Age", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Members", "Age", c => c.String());
        }
    }
}
