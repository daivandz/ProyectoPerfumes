namespace ProyectoP.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuarterMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Usuario = c.String(),
                        Coment = c.String(),
                        PerfumeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Perfumes", t => t.PerfumeId, cascadeDelete: true)
                .Index(t => t.PerfumeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "PerfumeId", "dbo.Perfumes");
            DropIndex("dbo.Comments", new[] { "PerfumeId" });
            DropTable("dbo.Comments");
        }
    }
}
