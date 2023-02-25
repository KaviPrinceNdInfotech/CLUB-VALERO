namespace CLUB_VALERO_DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class z1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Members", "M_Gender", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Members", "M_Gender", c => c.String(nullable: false));
        }
    }
}
