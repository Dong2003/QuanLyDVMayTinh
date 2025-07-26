namespace ShopTechOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update234 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Adv", "Alias", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Adv", "Alias");
        }
    }
}
