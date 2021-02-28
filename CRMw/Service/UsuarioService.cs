using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Services.Usuario;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service
{
    public class UsuarioService : IUsuarioService
    {

        private IRepository<UsuarioEntity> _repository;

        public UsuarioService(IRepository<UsuarioEntity> repository)
        {
            _repository = repository;
        }

        public async Task<UsuarioEntity> Carregar(int id)
        {
            return await _repository.CarregarAsync(id);
        }

        public async Task<IEnumerable<UsuarioEntity>> CarregarTodos()
        {
            return await _repository.CarregarTodosAsync();
        }

        public async Task<bool> Deletar(int id)
        {
            return await _repository.DeletarAsync(id);
        }

        public async Task<UsuarioEntity> Salvar(UsuarioEntity usuario)
        {
            return await _repository.SalvarAsync(usuario);
        }
    }
}
