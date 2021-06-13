namespace LectureWebPrgBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThisOneIsTheOne : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductColors",
                c => new
                    {
                        ProductId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Name = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        CssColor = c.String(maxLength: 7, storeType: "nvarchar"),
                        Available = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductId, t.Name })
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductColors", "ProductId", "dbo.Products");
            DropIndex("dbo.ProductColors", new[] { "ProductId" });
            DropTable("dbo.ProductColors");
        }
    }
}
