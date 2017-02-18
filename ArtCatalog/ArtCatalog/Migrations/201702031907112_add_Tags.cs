namespace ArtCatalog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_Tags : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        TagId = c.Int(nullable: false, identity: true),
                        TagName = c.String(),
                    })
                .PrimaryKey(t => t.TagId);
            
            CreateTable(
                "dbo.TagProducts",
                c => new
                    {
                        Tag_TagId = c.Int(nullable: false),
                        Product_ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_TagId, t.Product_ProductID })
                .ForeignKey("dbo.Tags", t => t.Tag_TagId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_ProductID, cascadeDelete: true)
                .Index(t => t.Tag_TagId)
                .Index(t => t.Product_ProductID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TagProducts", "Product_ProductID", "dbo.Products");
            DropForeignKey("dbo.TagProducts", "Tag_TagId", "dbo.Tags");
            DropIndex("dbo.TagProducts", new[] { "Product_ProductID" });
            DropIndex("dbo.TagProducts", new[] { "Tag_TagId" });
            DropTable("dbo.TagProducts");
            DropTable("dbo.Tags");
        }
    }
}
