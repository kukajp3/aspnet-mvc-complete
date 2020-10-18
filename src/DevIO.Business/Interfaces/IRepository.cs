using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using DevIO.Business.Models;

namespace DevIO.Business.Interfaces
{
  public interface IRepository<TEntity> : IDisposable where TEntity : Entity
  {
    Task Adicionar(TEntity entity);
    Task<TEntity> ObterPorId(Guid Id);
    Task<List<TEntity>> ObterTodos();
    Task Atualizar(TEntity entity);
    Task Remover(Guid Id);
    Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);
    Task<int> SaveChanges();
  }
}