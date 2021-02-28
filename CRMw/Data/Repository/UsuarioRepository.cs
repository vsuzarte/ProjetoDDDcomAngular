using Data.Context;
using Domain.Entities;
using Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class UsuarioRepository : BaseRepository<UsuarioEntity>, IUsuarioRepository
    {
        private DbSet<UsuarioEntity> _dataset;

        public UsuarioRepository(DBCtx dBCtx) : base(dBCtx)
        {
            _dataset = dBCtx.Set<UsuarioEntity>();
        }
        
        public async Task<UsuarioEntity> BuscarUsuarioSenha(string usuario, string senha)
        {
            return await _dataset.FirstOrDefaultAsync(u => u.Usuario.Equals(usuario) && u.Senha.Equals(senha));
        }
    }
}
