namespace KarapinhaDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddActicationDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "ActivationDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bookings", "ActivationDate");
        }
    }
}
