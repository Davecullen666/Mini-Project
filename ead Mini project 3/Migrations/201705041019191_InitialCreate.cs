namespace ead_Mini_project_3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BandName = c.String(nullable: false),
                        Albums = c.String(),
                        Genres = c.Int(nullable: false),
                        Members = c.String(),
                        BandWebsite = c.String(),
                        Youtube = c.String(),
                        Contact = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Shows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ShowName = c.String(nullable: false),
                        Venue = c.String(nullable: false),
                        Time = c.DateTime(nullable: false),
                        Price = c.Double(nullable: false),
                        MainBand = c.String(nullable: false),
                        SupportBand = c.String(),
                        TicketsAvailable = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Shows");
            DropTable("dbo.Bands");
        }
    }
}
