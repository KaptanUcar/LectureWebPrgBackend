    namespace LectureWebPrgBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstTesting : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProductCategories");
        }
    }
}
