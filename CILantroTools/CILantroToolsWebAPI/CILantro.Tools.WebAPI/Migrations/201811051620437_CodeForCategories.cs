namespace CILantro.Tools.WebAPI.Database
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CodeForCategories : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Code", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "Code");
        }
    }
}
