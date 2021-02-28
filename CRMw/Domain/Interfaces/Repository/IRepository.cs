using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    /// <summary>
    /// Interface para respositorios das entidades que herdam de BaseEntity.
    /// </summary>
    /// <typeparam name="T">Qualquer entidade que herde de BaseEntity</typeparam>
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> SalvarAsync(T entidade);

        Task<bool> DeletarAsync(int id);

        Task<T> CarregarAsync(int id);

        Task<IEnumerable<T>> CarregarTodosAsync();
    }
}