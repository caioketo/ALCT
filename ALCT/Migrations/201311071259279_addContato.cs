namespace ALCT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addContato : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContatoModels",
                c => new
                    {
                        ContatoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.ContatoId);
            
            CreateTable(
                "dbo.TelefoneModels",
                c => new
                    {
                        TelefoneId = c.Int(nullable: false, identity: true),
                        ContatoID = c.Int(),
                        Numero = c.String(),
                    })
                .PrimaryKey(t => t.TelefoneId)
                .ForeignKey("dbo.ContatoModels", t => t.ContatoID)
                .Index(t => t.ContatoID);
            
            AddColumn("dbo.ImovelModels", "ContatoID", c => c.Int());
            AddForeignKey("dbo.ImovelModels", "ContatoID", "dbo.ContatoModels", "ContatoId");
            CreateIndex("dbo.ImovelModels", "ContatoID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.TelefoneModels", new[] { "ContatoID" });
            DropIndex("dbo.ImovelModels", new[] { "ContatoID" });
            DropForeignKey("dbo.TelefoneModels", "ContatoID", "dbo.ContatoModels");
            DropForeignKey("dbo.ImovelModels", "ContatoID", "dbo.ContatoModels");
            DropColumn("dbo.ImovelModels", "ContatoID");
            DropTable("dbo.TelefoneModels");
            DropTable("dbo.ContatoModels");
        }
    }
}
