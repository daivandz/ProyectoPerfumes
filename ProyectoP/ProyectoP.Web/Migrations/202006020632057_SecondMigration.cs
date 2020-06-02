namespace ProyectoP.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Perfumes", "ImgUrl", c => c.String());
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String(maxLength: 50));
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String(maxLength: 50));
            AddColumn("dbo.AspNetUsers", "ImgUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "ImgUrl");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropColumn("dbo.Perfumes", "ImgUrl");
        }
    }
}
