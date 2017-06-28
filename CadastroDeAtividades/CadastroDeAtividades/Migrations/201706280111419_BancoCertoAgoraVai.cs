namespace CadastroDeAtividades.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BancoCertoAgoraVai : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Atividades",
                c => new
                    {
                        AtividadeID = c.Int(nullable: false, identity: true),
                        NomeAtividade = c.String(nullable: false),
                        DescricaoAtividade = c.String(),
                        Ativo = c.Boolean(nullable: false),
                        _Pessoa_PessoaID = c.Int(),
                    })
                .PrimaryKey(t => t.AtividadeID)
                .ForeignKey("dbo.Pessoas", t => t._Pessoa_PessoaID)
                .Index(t => t._Pessoa_PessoaID);
            
            CreateTable(
                "dbo.Pessoas",
                c => new
                    {
                        PessoaID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Parentesco = c.String(),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PessoaID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Atividades", "_Pessoa_PessoaID", "dbo.Pessoas");
            DropIndex("dbo.Atividades", new[] { "_Pessoa_PessoaID" });
            DropTable("dbo.Pessoas");
            DropTable("dbo.Atividades");
        }
    }
}
