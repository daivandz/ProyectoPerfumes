namespace ProyectoP.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FifthMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comments", "Usuario", c => c.String(nullable: false));
            AlterColumn("dbo.Comments", "Coment", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Perfumes", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Perfumes", "Description", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Perfumes", "Gender", c => c.String(nullable: false));
            AlterColumn("dbo.Marcas", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Marcas", "Name", c => c.String());
            AlterColumn("dbo.Perfumes", "Gender", c => c.String());
            AlterColumn("dbo.Perfumes", "Description", c => c.String());
            AlterColumn("dbo.Perfumes", "Name", c => c.String());
            AlterColumn("dbo.Comments", "Coment", c => c.String());
            AlterColumn("dbo.Comments", "Usuario", c => c.String());
        }
    }
}
