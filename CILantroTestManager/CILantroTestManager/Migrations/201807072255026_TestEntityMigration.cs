namespace CILantroTestManager.Database
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestEntityMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Subcategories", "CategoryId", "dbo.Categories");
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Path = c.String(),
                        CategoryId = c.Guid(nullable: false),
                        SubcategoryId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .ForeignKey("dbo.Subcategories", t => t.SubcategoryId)
                .Index(t => t.CategoryId)
                .Index(t => t.SubcategoryId);
            
            AddForeignKey("dbo.Subcategories", "CategoryId", "dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subcategories", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Tests", "SubcategoryId", "dbo.Subcategories");
            DropForeignKey("dbo.Tests", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Tests", new[] { "SubcategoryId" });
            DropIndex("dbo.Tests", new[] { "CategoryId" });
            DropTable("dbo.Tests");
            AddForeignKey("dbo.Subcategories", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
