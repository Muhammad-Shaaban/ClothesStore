namespace ClothesStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editProdcutUser1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.product_user", "ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.product_user", "ProductId");
            AddForeignKey("dbo.product_user", "ProductId", "dbo.Products", "id", cascadeDelete: true);
            DropColumn("dbo.product_user", "product_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.product_user", "product_id", c => c.Int(nullable: false));
            DropForeignKey("dbo.product_user", "ProductId", "dbo.Products");
            DropIndex("dbo.product_user", new[] { "ProductId" });
            DropColumn("dbo.product_user", "ProductId");
        }
    }
}
