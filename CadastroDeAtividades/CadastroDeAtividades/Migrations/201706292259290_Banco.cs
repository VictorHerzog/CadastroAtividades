namespace CadastroDeAtividades.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Banco : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comodoes",
                c => new
                    {
                        ComodoID = c.Int(nullable: false, identity: true),
                        NomeComodo = c.String(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ComodoID);
            
            AddColumn("dbo.Atividades", "ComodoID", c => c.Int(nullable: false));
            CreateIndex("dbo.Atividades", "ComodoID");
            AddForeignKey("dbo.Atividades", "ComodoID", "dbo.Comodoes", "ComodoID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Atividades", "ComodoID", "dbo.Comodoes");
            DropIndex("dbo.Atividades", new[] { "ComodoID" });
            DropColumn("dbo.Atividades", "ComodoID");
            DropTable("dbo.Comodoes");
        }
    }
}
