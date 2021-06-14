namespace Journey.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Travels",
                c => new
                    {
                        JounrneyId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        CityStart = c.String(),
                        AddressStart = c.String(),
                        HourStart = c.DateTime(nullable: false),
                        CityEnd = c.String(),
                        AddressEnd = c.String(),
                        HourEnd = c.DateTime(nullable: false),
                        FreeSpace = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.JounrneyId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Travels", "UserId", "dbo.Users");
            DropIndex("dbo.Travels", new[] { "UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.Travels");
        }
    }
}
