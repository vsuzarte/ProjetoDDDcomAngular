using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data.Context
{
    /// <summary>
    /// Constroi o banco de dados. Construímos para que em execução a base seja construida.
    /// </summary>
    public class ContextFactory : IDesignTimeDbContextFactory<DBCtx>
    {
        public DBCtx CreateDbContext(string[] args)
        {
            var connectionString = DBCtx.ConecctionString;
            var optionsBuilder = new DbContextOptionsBuilder<DBCtx>();
            optionsBuilder.UseSqlServer(connectionString);
            return new DBCtx(optionsBuilder.Options);
        }
    }
}
