namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        answer = c.String(),
                        Question_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Questions", t => t.Question_ID)
                .Index(t => t.Question_ID);
            
            CreateTable(
                "dbo.DoctorAnswers",
                c => new
                    {
                        DoctorID = c.Int(nullable: false),
                        AnswerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DoctorID, t.AnswerID })
                .ForeignKey("dbo.Answers", t => t.AnswerID)
                .ForeignKey("dbo.Doctors", t => t.DoctorID)
                .Index(t => t.DoctorID)
                .Index(t => t.AnswerID);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Clinics",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ClinicName = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        Doctor_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Doctors", t => t.Doctor_ID)
                .Index(t => t.Doctor_ID);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        question = c.String(),
                        Mother_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Mothers", t => t.Mother_ID)
                .Index(t => t.Mother_ID);
            
            CreateTable(
                "dbo.Mothers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Shops",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ShopName = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        SalesPerson_ID = c.Int(nullable: false),
                        Category_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Categories", t => t.Category_ID)
                .ForeignKey("dbo.SalesPersons", t => t.SalesPerson_ID)
                .Index(t => t.SalesPerson_ID)
                .Index(t => t.Category_ID);
            
            CreateTable(
                "dbo.SalesPersons",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.ShopProducts",
                c => new
                    {
                        ShopID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ShopID, t.ProductID })
                .ForeignKey("dbo.Products", t => t.ProductID)
                .ForeignKey("dbo.Shops", t => t.ShopID)
                .Index(t => t.ShopID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        Price = c.Double(nullable: false),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShopProducts", "ShopID", "dbo.Shops");
            DropForeignKey("dbo.ShopProducts", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Shops", "SalesPerson_ID", "dbo.SalesPersons");
            DropForeignKey("dbo.Shops", "Category_ID", "dbo.Categories");
            DropForeignKey("dbo.Answers", "Question_ID", "dbo.Questions");
            DropForeignKey("dbo.Questions", "Mother_ID", "dbo.Mothers");
            DropForeignKey("dbo.DoctorAnswers", "DoctorID", "dbo.Doctors");
            DropForeignKey("dbo.Clinics", "Doctor_ID", "dbo.Doctors");
            DropForeignKey("dbo.DoctorAnswers", "AnswerID", "dbo.Answers");
            DropIndex("dbo.ShopProducts", new[] { "ProductID" });
            DropIndex("dbo.ShopProducts", new[] { "ShopID" });
            DropIndex("dbo.Shops", new[] { "Category_ID" });
            DropIndex("dbo.Shops", new[] { "SalesPerson_ID" });
            DropIndex("dbo.Questions", new[] { "Mother_ID" });
            DropIndex("dbo.Clinics", new[] { "Doctor_ID" });
            DropIndex("dbo.DoctorAnswers", new[] { "AnswerID" });
            DropIndex("dbo.DoctorAnswers", new[] { "DoctorID" });
            DropIndex("dbo.Answers", new[] { "Question_ID" });
            DropTable("dbo.Products");
            DropTable("dbo.ShopProducts");
            DropTable("dbo.SalesPersons");
            DropTable("dbo.Shops");
            DropTable("dbo.Categories");
            DropTable("dbo.Mothers");
            DropTable("dbo.Questions");
            DropTable("dbo.Clinics");
            DropTable("dbo.Doctors");
            DropTable("dbo.DoctorAnswers");
            DropTable("dbo.Answers");
        }
    }
}
