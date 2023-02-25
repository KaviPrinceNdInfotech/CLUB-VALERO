namespace CLUB_VALERO_DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class A1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Members", "Password", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Members", "Password", c => c.String(nullable: false));
        }
    }
}
