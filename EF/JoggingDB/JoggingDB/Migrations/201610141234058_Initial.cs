namespace JoggingDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sessions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        End = c.DateTime(nullable: false),
                        Start = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AcceleroMeters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Y = c.Single(nullable: false),
                        X = c.Single(nullable: false),
                        Z = c.Single(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Session_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sessions", t => t.Session_Id)
                .Index(t => t.Session_Id);
            
            CreateTable(
                "dbo.Humidities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Humid = c.Single(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Session_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sessions", t => t.Session_Id)
                .Index(t => t.Session_Id);
            
            CreateTable(
                "dbo.Pressures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Press = c.Single(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Session_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sessions", t => t.Session_Id)
                .Index(t => t.Session_Id);
            
            CreateTable(
                "dbo.Temperatures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Temp = c.Single(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Session_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sessions", t => t.Session_Id)
                .Index(t => t.Session_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Temperatures", "Session_Id", "dbo.Sessions");
            DropForeignKey("dbo.Pressures", "Session_Id", "dbo.Sessions");
            DropForeignKey("dbo.Humidities", "Session_Id", "dbo.Sessions");
            DropForeignKey("dbo.AcceleroMeters", "Session_Id", "dbo.Sessions");
            DropIndex("dbo.Temperatures", new[] { "Session_Id" });
            DropIndex("dbo.Pressures", new[] { "Session_Id" });
            DropIndex("dbo.Humidities", new[] { "Session_Id" });
            DropIndex("dbo.AcceleroMeters", new[] { "Session_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Temperatures");
            DropTable("dbo.Pressures");
            DropTable("dbo.Humidities");
            DropTable("dbo.AcceleroMeters");
            DropTable("dbo.Sessions");
        }
    }
}
