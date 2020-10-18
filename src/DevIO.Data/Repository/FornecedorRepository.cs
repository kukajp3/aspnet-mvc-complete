using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Repository
{
  public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
  {
    public FornecedorRepository(DataContext context) : base(context)
    {

    }

    public async Task<Fornecedor> ObterFornecedorEndereco(Guid id)
    {
      return await Db.Fornecedores.AsNoTracking().Include(e => e.Endereco)
        .FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id)
    {
      return await Db.Fornecedores.AsNoTracking().Include(e => e.Endereco).Include(p => p.Produtos)
        .FirstOrDefaultAsync(f => f.Id == id);
    }
  }
}