using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories
{
    public interface IEstoqueRepository
    {
        Task<IEnumerable<ESTOQUE>> Get();

        Task<ESTOQUE> Get(int Id);

        Task<ESTOQUE> Create(ESTOQUE estoque);

        Task Update(ESTOQUE estoque);

        Task Delete(int Id);
    }
}
