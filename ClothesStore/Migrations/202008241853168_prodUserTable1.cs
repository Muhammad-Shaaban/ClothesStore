namespace ClothesStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prodUserTable1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.product_user", "Product_Quantity", c => c.String());
            AddColumn("dbo.product_user", "Prodcut_Price", c => c.String());
            AddColumn("dbo.product_user", "Product_totalPrice", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.product_user", "Product_totalPrice");
            DropColumn("dbo.product_user", "Prodcut_Price");
            DropColumn("dbo.product_user", "Product_Quantity");
        }
    }
}
