namespace ShopTechOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateadv33 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Adv", "IsHot", c => c.Boolean(nullable: false));
            AddColumn("dbo.Adv", "IsNew", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Adv", "IsNew");
            DropColumn("dbo.Adv", "IsHot");
        }
    }
}
