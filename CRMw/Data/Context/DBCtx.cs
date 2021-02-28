using Data.Mapping;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class DBCtx : DbContext
    {
        public const string ConecctionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CRMw;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public DbSet<UsuarioEntity> Usuarios { get; set; }

        public DBCtx(DbContextOptions<DBCtx> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UsuarioEntity>(new UsuarioMap().Configure);
        }

    }
}
