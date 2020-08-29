namespace ClothesStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prodUserTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.product_user",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        product_id = c.Int(nullable: false),
                        User_id = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.product_user");
        }
    }
}
