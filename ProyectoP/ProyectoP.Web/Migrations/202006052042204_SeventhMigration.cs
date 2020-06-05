namespace ProyectoP.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeventhMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Perfumes", "Image", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Perfumes", "Image");
        }
    }
}
