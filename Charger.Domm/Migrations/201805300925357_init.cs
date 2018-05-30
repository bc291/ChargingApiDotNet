namespace Charger.Domm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChargOperations",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        carModel = c.String(nullable: false),
                        capacityCharged = c.Single(nullable: false),
                        averagePower = c.Single(nullable: false),
                        cost = c.Single(nullable: false),
                        elapsedTime = c.Single(nullable: false),
                        initialCapacity = c.Single(nullable: false),
                        dateAndTime = c.String(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        FullName = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChargOperations", "CustomerId", "dbo.Customers");
            DropIndex("dbo.ChargOperations", new[] { "CustomerId" });
            DropTable("dbo.Customers");
            DropTable("dbo.ChargOperations");
        }
    }
}
