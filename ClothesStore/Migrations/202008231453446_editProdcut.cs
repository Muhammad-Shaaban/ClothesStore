namespace ClothesStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editProdcut : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Category_id", "dbo.Categories");
            DropForeignKey("dbo.Products", "Size_id", "dbo.sizes");
            DropIndex("dbo.Products", new[] { "Category_id" });
            DropIndex("dbo.Products", new[] { "Size_id" });
            RenameColumn(table: "dbo.Products", name: "Category_id", newName: "CategoryId");
            RenameColumn(table: "dbo.Products", name: "Size_id", newName: "sizeId");
            AlterColumn("dbo.Products", "CategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "sizeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "CategoryId");
            CreateIndex("dbo.Products", "sizeId");
            AddForeignKey("dbo.Products", "CategoryId", "dbo.Categories", "id", cascadeDelete: true);
            AddForeignKey("dbo.Products", "sizeId", "dbo.sizes", "id", cascadeDelete: true);
            DropColumn("dbo.Products", "Prod_Category");
            DropColumn("dbo.Products", "Prod_Size");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Prod_Size", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "Prod_Category", c => c.Int(nullable: false));
            DropForeignKey("dbo.Products", "sizeId", "dbo.sizes");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "sizeId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            AlterColumn("dbo.Products", "sizeId", c => c.Int());
            AlterColumn("dbo.Products", "CategoryId", c => c.Int());
            RenameColumn(table: "dbo.Products", name: "sizeId", newName: "Size_id");
            RenameColumn(table: "dbo.Products", name: "CategoryId", newName: "Category_id");
            CreateIndex("dbo.Products", "Size_id");
            CreateIndex("dbo.Products", "Category_id");
            AddForeignKey("dbo.Products", "Size_id", "dbo.sizes", "id");
            AddForeignKey("dbo.Products", "Category_id", "dbo.Categories", "id");
        }
    }
}
