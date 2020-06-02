namespace ProyectoP.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdMigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "ImgUrl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "ImgUrl", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String(maxLength: 50));
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String(maxLength: 50));
        }
    }
}
