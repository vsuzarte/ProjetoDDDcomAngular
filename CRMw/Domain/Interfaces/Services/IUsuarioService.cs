using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services.Usuario
{
    public interface IUsuarioService
    {
        Task<UsuarioEntity> Carregar(int id);

        Task<IEnumerable<UsuarioEntity>> CarregarTodos();

        Task<UsuarioEntity> Salvar(UsuarioEntity usuario);

        Task<bool> Deletar(int id);
    }
}
