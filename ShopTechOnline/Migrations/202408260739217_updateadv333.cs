namespace ShopTechOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateadv333 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductImage", "Adv_ID", c => c.Int());
            CreateIndex("dbo.ProductImage", "Adv_ID");
            AddForeignKey("dbo.ProductImage", "Adv_ID", "dbo.Adv", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductImage", "Adv_ID", "dbo.Adv");
            DropIndex("dbo.ProductImage", new[] { "Adv_ID" });
            DropColumn("dbo.ProductImage", "Adv_ID");
        }
    }
}
