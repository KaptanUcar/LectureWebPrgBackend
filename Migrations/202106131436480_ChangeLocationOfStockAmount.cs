namespace LectureWebPrgBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeLocationOfStockAmount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductColors", "StockAmount", c => c.Int(nullable: false, defaultValue: 0));
            DropColumn("dbo.Products", "StockAmount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "StockAmount", c => c.Int(nullable: false));
            DropColumn("dbo.ProductColors", "StockAmount");
        }
    }
}
