
namespace CadastroPessoas.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CadastroPessoas.Models.Conexao>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CadastroPessoas.Models.Conexao context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            // Este método será chamado após a migração para a versão mais recente.

            // Você pode usar o método de extensão auxiliar DbSet<T>.AddOrUpdate()
            // para evitar a criação de dados de seed duplicados.
        }
    }
}
