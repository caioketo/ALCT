namespace ALCT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPlanta : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ImagemModels",
                c => new
                    {
                        ImagemId = c.Int(nullable: false, identity: true),
                        Caminho = c.String(),
                        ImovelModel_ImovelId = c.Int(),
                    })
                .PrimaryKey(t => t.ImagemId)
                .ForeignKey("dbo.ImovelModels", t => t.ImovelModel_ImovelId)
                .Index(t => t.ImovelModel_ImovelId);
            
            AddColumn("dbo.ImovelModels", "ImagemID", c => c.Int());
            AddForeignKey("dbo.ImovelModels", "ImagemID", "dbo.ImagemModels", "ImagemId");
            CreateIndex("dbo.ImovelModels", "ImagemID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.ImagemModels", new[] { "ImovelModel_ImovelId" });
            DropIndex("dbo.ImovelModels", new[] { "ImagemID" });
            DropForeignKey("dbo.ImagemModels", "ImovelModel_ImovelId", "dbo.ImovelModels");
            DropForeignKey("dbo.ImovelModels", "ImagemID", "dbo.ImagemModels");
            DropColumn("dbo.ImovelModels", "ImagemID");
            DropTable("dbo.ImagemModels");
        }
    }
}
