namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductTypes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.Products", "ProjectType_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "ProjectType_ID");
            AddForeignKey("dbo.Products", "ProjectType_ID", "dbo.ProductTypes", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "ProjectType_ID", "dbo.ProductTypes");
            DropIndex("dbo.Products", new[] { "ProjectType_ID" });
            DropColumn("dbo.Products", "ProjectType_ID");
            DropTable("dbo.ProductTypes");
        }
    }
}
