using System;
using System.Threading.Tasks;
using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Business.Models.Validations;

namespace DevIO.Business.Services
{
  public abstract class ProdutoService : BaseService, IProdutoService
  {
    public async Task Adicionar(Produto produto)
    {
      if (!ExecutarValidacao(new ProdutoValidation(), produto))
        return;
    }

    public async Task Atualizar(Produto produto)
    {
      if (!ExecutarValidacao(new ProdutoValidation(), produto))
        return;
    }

    public Task Remover(Guid id)
    {
      throw new NotImplementedException();
    }
  }
}