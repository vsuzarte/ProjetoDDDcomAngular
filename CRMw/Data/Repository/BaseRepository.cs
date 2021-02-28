using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly DBCtx _dBCtx;

        private DbSet<T> _dataSet;

        public BaseRepository(DBCtx dBCtx)
        {
            _dBCtx = dBCtx;
            _dataSet = _dBCtx.Set<T>();
        }

        public async Task<T> CarregarAsync(int id)
        {
            try
            {
                return await _dataSet.SingleOrDefaultAsync(p => p.Id == id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<T>> CarregarTodosAsync()
        {
            try
            {
                return await _dataSet.ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> DeletarAsync(int id)
        {
            try
            {
                var result = await _dataSet.SingleOrDefaultAsync(e => e.Id == id);

                if (result == null)
                    return false;

                result.DataAtualizacao = DateTime.Now;
                result.DataCriacao = result.DataCriacao;
                result.Deletado = true;

                _dBCtx.Entry(result);

                await _dBCtx.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<T> SalvarAsync(T entidade)
        {
            try
            {
                if(entidade.Id <= 0)
                {
                    entidade.DataCriacao = DateTime.Now;
                    _dataSet.Add(entidade);

                    await _dBCtx.SaveChangesAsync();

                    return entidade;
                }
                else
                {
                    var result = await _dataSet.SingleOrDefaultAsync(e => e.Id == entidade.Id);

                    if (result == null)
                        throw new NullReferenceException($"A entidade de id {entidade.Id} não foi encontrada no contexto atual.");

                    entidade.DataAtualizacao = DateTime.Now;
                    entidade.DataCriacao = result.DataCriacao;

                    _dBCtx.Entry(result).CurrentValues.SetValues(entidade);

                    await _dBCtx.SaveChangesAsync();
                    
                    return entidade;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
