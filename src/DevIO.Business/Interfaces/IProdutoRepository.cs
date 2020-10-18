using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using DevIO.Business.Models;

namespace DevIO.Business.Interfaces
{
  public interface IProdutoRepository : IRepository<Produto>
  {
    Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId);
    Task<IEnumerable<Produto>> ObterProdutosFornecedores();

    Task<Produto> ObterFornecedorEndereco(Guid id);
  }
}