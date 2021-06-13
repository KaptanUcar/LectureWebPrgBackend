namespace LectureWebPrgBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedStockAmount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "StockAmount", c => c.Int(nullable: false, defaultValue: 0));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "StockAmount");
        }
    }
}
