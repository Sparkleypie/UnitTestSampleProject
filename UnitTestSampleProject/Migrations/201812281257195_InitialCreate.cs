namespace UnitTestSampleProject.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        DateOfPublication = c.DateTime(nullable: false),
                        Genre = c.String(),
                        IsComic = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExpectedDeliveryDate = c.DateTime(nullable: false),
                        OrderNumber = c.Int(nullable: false),
                        Person_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Person_Id)
                .Index(t => t.Person_Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderBooks",
                c => new
                    {
                        Order_Id = c.Int(nullable: false),
                        Book_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Order_Id, t.Book_Id })
                .ForeignKey("dbo.Orders", t => t.Order_Id, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_Id, cascadeDelete: true)
                .Index(t => t.Order_Id)
                .Index(t => t.Book_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Person_Id", "dbo.People");
            DropForeignKey("dbo.OrderBooks", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.OrderBooks", "Order_Id", "dbo.Orders");
            DropIndex("dbo.OrderBooks", new[] { "Book_Id" });
            DropIndex("dbo.OrderBooks", new[] { "Order_Id" });
            DropIndex("dbo.Orders", new[] { "Person_Id" });
            DropTable("dbo.OrderBooks");
            DropTable("dbo.People");
            DropTable("dbo.Orders");
            DropTable("dbo.Books");
        }
    }
}
