namespace ProyectoP.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SixthMigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Perfumes", "ImgUrl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Perfumes", "ImgUrl", c => c.String());
        }
    }
}
