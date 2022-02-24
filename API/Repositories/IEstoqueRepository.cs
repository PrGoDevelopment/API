using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories
{
    public interface IEstoqueRepository
    {
        Task<IEnumerable<T_ESTOQUE>> Get();

        Task<T_ESTOQUE> Get(int Id);

        Task<T_ESTOQUE> Create(T_ESTOQUE estoque);

        Task Update(T_ESTOQUE estoque);

        Task Delete(int Id);
    }
}
