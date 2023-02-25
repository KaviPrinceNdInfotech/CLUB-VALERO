namespace CLUB_VALERO_DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class A2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Members", "AnnualIncome", c => c.String());
            AlterColumn("dbo.Members", "Co_FirstName", c => c.String());
            AlterColumn("dbo.Members", "Co_LastName", c => c.String());
            AlterColumn("dbo.Members", "Co_Mobile", c => c.String());
            AlterColumn("dbo.Members", "Co_Email", c => c.String());
            AlterColumn("dbo.Members", "State", c => c.String());
            AlterColumn("dbo.Members", "City", c => c.String());
            AlterColumn("dbo.Members", "Country", c => c.String());
            AlterColumn("dbo.Members", "Mobile", c => c.String());
            AlterColumn("dbo.Members", "Email", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Members", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Members", "Mobile", c => c.String(nullable: false));
            AlterColumn("dbo.Members", "Country", c => c.String(nullable: false));
            AlterColumn("dbo.Members", "City", c => c.String(nullable: false));
            AlterColumn("dbo.Members", "State", c => c.String(nullable: false));
            AlterColumn("dbo.Members", "Co_Email", c => c.String(nullable: false));
            AlterColumn("dbo.Members", "Co_Mobile", c => c.String(nullable: false));
            AlterColumn("dbo.Members", "Co_LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Members", "Co_FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Members", "AnnualIncome", c => c.String(nullable: false));
        }
    }
}
