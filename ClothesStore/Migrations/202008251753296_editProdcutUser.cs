namespace ClothesStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editProdcutUser : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.product_user", "Product_Quantity", c => c.Int(nullable: false));
            AlterColumn("dbo.product_user", "Prodcut_Price", c => c.Int(nullable: false));
            AlterColumn("dbo.product_user", "Product_totalPrice", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.product_user", "Product_totalPrice", c => c.String());
            AlterColumn("dbo.product_user", "Prodcut_Price", c => c.String());
            AlterColumn("dbo.product_user", "Product_Quantity", c => c.String());
        }
    }
}
