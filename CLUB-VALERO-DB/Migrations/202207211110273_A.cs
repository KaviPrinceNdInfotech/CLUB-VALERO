namespace CLUB_VALERO_DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class A : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        RoleMasterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RoleMasters", t => t.RoleMasterId, cascadeDelete: true)
                .Index(t => t.RoleMasterId);
            
            CreateTable(
                "dbo.RoleMasters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Password = c.String(nullable: false),
                        MemberShipId = c.String(),
                        M_FirstName = c.String(),
                        M_LastName = c.String(),
                        M_Gender = c.String(nullable: false),
                        M_DateOfBirth = c.String(),
                        M_Salution = c.String(),
                        Age = c.String(),
                        MaritalStatus = c.String(),
                        Occupation = c.String(),
                        AnnualIncome = c.String(nullable: false),
                        FoodPreference = c.String(),
                        Co_Salution = c.String(),
                        Co_Gender = c.String(),
                        Co_FirstName = c.String(nullable: false),
                        Co_LastName = c.String(nullable: false),
                        Co_Mobile = c.String(nullable: false),
                        Co_Email = c.String(nullable: false),
                        No_Co_Adults = c.String(),
                        No_Co_Children = c.String(),
                        Co_Child1 = c.String(),
                        Co_Child1_DateOfBirth = c.String(),
                        Co_Child2 = c.String(),
                        Co_Child2_DateOfBirth = c.String(),
                        Co_Child3 = c.String(),
                        Co_Child3_DateOfBirth = c.String(),
                        NameOfPremission_Building = c.String(),
                        Road_Street_Lane = c.String(),
                        Area_Locality = c.String(),
                        LandMark = c.String(),
                        State = c.String(nullable: false),
                        City = c.String(nullable: false),
                        Country = c.String(nullable: false),
                        PinCode = c.String(),
                        Mobile = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        ApptType = c.String(),
                        Tenure = c.String(),
                        NoOf_Night_Year = c.String(),
                        TenureDate = c.String(),
                        CreateByDate = c.String(),
                        Occupants = c.String(),
                        MemberShipType = c.String(),
                        AmcCharge = c.String(),
                        ClubValeroMemebr = c.String(),
                        MemberShipNo = c.String(),
                        MemberShip_Price = c.String(),
                        AdminFee = c.String(),
                        DownPayment = c.String(),
                        BalanceAmount = c.String(),
                        ModeOfPayment = c.String(),
                        CashDate = c.String(),
                        CashAmount = c.String(),
                        CashReceiptNo = c.String(),
                        CashSignature = c.String(),
                        DD_BankName_Branch = c.String(),
                        DD_Date = c.String(),
                        InstrumentNo = c.String(),
                        Debit_Credit_Card = c.String(),
                        QRCode = c.String(),
                        EMIOpted = c.String(),
                        EmiAmount = c.String(),
                        EmiStartDate = c.DateTime(nullable: false),
                        Individual = c.String(),
                        Co_applicant_kyc = c.String(),
                        ClubValero_Executive = c.String(),
                        CVE_ID = c.String(),
                        KYC_Date = c.String(),
                        ManagerName = c.String(),
                        F6 = c.String(),
                        SpecialOffer = c.String(),
                        ParchagePrice = c.String(),
                        FileName = c.String(),
                        ContentType = c.String(),
                        Data = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserAmcs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.String(),
                        Status = c.String(),
                        UserName = c.String(),
                        AmcStartDate = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                        AmcDepositDate = c.DateTime(nullable: false),
                        PaymentMode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserEmis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Amount = c.String(),
                        Status = c.String(),
                        PaymentMode = c.String(),
                        EmiStartDate = c.DateTime(nullable: false),
                        EmiDepositDate = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IndianCities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IndianFullCityPages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IndianCityId = c.Int(nullable: false),
                        CityDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Asias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AsiaName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AsiaFullCityNames",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AsiaCityName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        CheckOut = c.String(),
                        CheckIn = c.String(),
                        Nights = c.String(),
                        Days = c.String(),
                        City = c.String(),
                        Hotel = c.String(),
                        Address = c.String(),
                        TelephoneNo = c.String(),
                        ConfirmationId = c.String(),
                        RoomType = c.String(),
                        ConfirmedBy = c.String(),
                        NoOfRooms = c.String(),
                        NoOfKids = c.String(),
                        PaymentStatus = c.String(),
                        Remarks = c.String(),
                        HolidayType = c.String(),
                        MealPlan = c.String(),
                        NoOfAdult = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PaymentOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Currency = c.String(),
                        UserId = c.String(),
                        Mobileno = c.String(),
                        EmailId = c.String(),
                        Amount = c.String(),
                        PaymentType = c.String(),
                        DateTime = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UtilityPayments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Logins", new[] { "RoleMasterId" });
            DropForeignKey("dbo.Logins", "RoleMasterId", "dbo.RoleMasters");
            DropTable("dbo.UtilityPayments");
            DropTable("dbo.PaymentOrders");
            DropTable("dbo.Bookings");
            DropTable("dbo.AsiaFullCityNames");
            DropTable("dbo.Asias");
            DropTable("dbo.IndianFullCityPages");
            DropTable("dbo.IndianCities");
            DropTable("dbo.UserEmis");
            DropTable("dbo.UserAmcs");
            DropTable("dbo.Members");
            DropTable("dbo.RoleMasters");
            DropTable("dbo.Logins");
        }
    }
}
