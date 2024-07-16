namespace KarapinhaDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BookingId = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ActivationDate = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.BookingId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.BookingServices",
                c => new
                    {
                        BookingId = c.Int(nullable: false),
                        ServiceId = c.Int(nullable: false),
                        ProfessionalId = c.Int(nullable: false),
                        TimeId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.BookingId, t.ServiceId, t.ProfessionalId, t.TimeId })
                .ForeignKey("dbo.Bookings", t => t.BookingId, cascadeDelete: true)
                .ForeignKey("dbo.Professionals", t => t.ProfessionalId, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .ForeignKey("dbo.Times", t => t.TimeId, cascadeDelete: true)
                .Index(t => t.BookingId)
                .Index(t => t.ServiceId)
                .Index(t => t.ProfessionalId)
                .Index(t => t.TimeId);
            
            CreateTable(
                "dbo.Professionals",
                c => new
                    {
                        ProfessionalId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        EmailAddress = c.String(),
                        PhotoUrl = c.String(),
                        IdCard = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProfessionalId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: false)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Imagem = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        ServiceId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Image = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EstimatedTime = c.Int(nullable: false),
                        Status = c.String(),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ServiceId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.ProfessionalTimes",
                c => new
                    {
                        ProfessionalId = c.Int(nullable: false),
                        TimeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProfessionalId, t.TimeId })
                .ForeignKey("dbo.Professionals", t => t.ProfessionalId, cascadeDelete: true)
                .ForeignKey("dbo.Times", t => t.TimeId, cascadeDelete: true)
                .Index(t => t.ProfessionalId)
                .Index(t => t.TimeId);
            
            CreateTable(
                "dbo.Times",
                c => new
                    {
                        TimeId = c.Int(nullable: false, identity: true),
                        Hour = c.Int(nullable: false),
                        Minute = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TimeId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        EmailAdress = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                        PhotoUrl = c.String(),
                        IdCard = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        ConfirmPassword = c.String(),
                        Role = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "UserId", "dbo.Users");
            DropForeignKey("dbo.ProfessionalTimes", "TimeId", "dbo.Times");
            DropForeignKey("dbo.BookingServices", "TimeId", "dbo.Times");
            DropForeignKey("dbo.ProfessionalTimes", "ProfessionalId", "dbo.Professionals");
            DropForeignKey("dbo.Services", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.BookingServices", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.Professionals", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.BookingServices", "ProfessionalId", "dbo.Professionals");
            DropForeignKey("dbo.BookingServices", "BookingId", "dbo.Bookings");
            DropIndex("dbo.ProfessionalTimes", new[] { "TimeId" });
            DropIndex("dbo.ProfessionalTimes", new[] { "ProfessionalId" });
            DropIndex("dbo.Services", new[] { "CategoryId" });
            DropIndex("dbo.Professionals", new[] { "CategoryId" });
            DropIndex("dbo.BookingServices", new[] { "TimeId" });
            DropIndex("dbo.BookingServices", new[] { "ProfessionalId" });
            DropIndex("dbo.BookingServices", new[] { "ServiceId" });
            DropIndex("dbo.BookingServices", new[] { "BookingId" });
            DropIndex("dbo.Bookings", new[] { "UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.Times");
            DropTable("dbo.ProfessionalTimes");
            DropTable("dbo.Services");
            DropTable("dbo.Categories");
            DropTable("dbo.Professionals");
            DropTable("dbo.BookingServices");
            DropTable("dbo.Bookings");
        }
    }
}
