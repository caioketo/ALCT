namespace ALCT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.EstadoModels",
                c => new
                    {
                        EstadoId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        Codigo = c.String(),
                    })
                .PrimaryKey(t => t.EstadoId);
            
            CreateTable(
                "dbo.CidadeModels",
                c => new
                    {
                        CidadeId = c.Int(nullable: false, identity: true),
                        EstadoID = c.Int(),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.CidadeId)
                .ForeignKey("dbo.EstadoModels", t => t.EstadoID)
                .Index(t => t.EstadoID);
            
            CreateTable(
                "dbo.ImovelModels",
                c => new
                    {
                        ImovelId = c.Int(nullable: false, identity: true),
                        CidadeID = c.Int(),
                        Descricao = c.String(),
                        Valor = c.Double(nullable: false),
                        Condominio = c.Double(nullable: false),
                        IPTU = c.Double(nullable: false),
                        AreaUtil = c.Double(nullable: false),
                        Vagas = c.Int(nullable: false),
                        Dormitorios = c.Int(nullable: false),
                        Suites = c.Int(nullable: false),
                        Endereco = c.String(),
                        Tipo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ImovelId)
                .ForeignKey("dbo.CidadeModels", t => t.CidadeID)
                .Index(t => t.CidadeID);
            
            CreateTable(
                "dbo.ParedeModels",
                c => new
                    {
                        ParedeId = c.Int(nullable: false, identity: true),
                        ImovelID = c.Int(),
                        X = c.Int(nullable: false),
                        Z = c.Int(nullable: false),
                        Width = c.Int(nullable: false),
                        Depth = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ParedeId)
                .ForeignKey("dbo.ImovelModels", t => t.ImovelID)
                .Index(t => t.ImovelID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.ParedeModels", new[] { "ImovelID" });
            DropIndex("dbo.ImovelModels", new[] { "CidadeID" });
            DropIndex("dbo.CidadeModels", new[] { "EstadoID" });
            DropForeignKey("dbo.ParedeModels", "ImovelID", "dbo.ImovelModels");
            DropForeignKey("dbo.ImovelModels", "CidadeID", "dbo.CidadeModels");
            DropForeignKey("dbo.CidadeModels", "EstadoID", "dbo.EstadoModels");
            DropTable("dbo.ParedeModels");
            DropTable("dbo.ImovelModels");
            DropTable("dbo.CidadeModels");
            DropTable("dbo.EstadoModels");
            DropTable("dbo.UserProfile");
        }
    }
}
