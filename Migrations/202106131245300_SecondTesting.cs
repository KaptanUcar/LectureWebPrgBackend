namespace LectureWebPrgBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondTesting : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProductCategories", "Name", c => c.String(maxLength: 50, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProductCategories", "Name", c => c.String(unicode: false));
        }
    }
}
