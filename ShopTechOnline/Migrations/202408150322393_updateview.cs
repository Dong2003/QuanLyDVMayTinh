namespace ShopTechOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateview : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.New", "ViewCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.New", "ViewCount");
        }
    }
}
