using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories
{
    public class T_ESTOQUE_Repository : IT_ESTOQUE_Repository
    {
        public readonly T_ESTOQUE_Context _context;

        public T_ESTOQUE_Repository(T_ESTOQUE_Context context)
        {
            _context = context;
        }
        public async Task<T_ESTOQUE> Create(T_ESTOQUE estoque)
        {
            _context.Estoques.Add(estoque);
            await _context.SaveChangesAsync();

            return estoque;
        }

        public async Task Delete(int id)
        {
            var estoqueDelete = await _context.Estoques.FindAsync(id);
            _context.Estoques.Remove(estoqueDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T_ESTOQUE>> Get()
        {
            return await _context.Estoques.ToListAsync();
        }

        public async Task<T_ESTOQUE> Get(int id)
        {
            return await _context.Estoques.FindAsync(id);
        }

        public async Task Update(T_ESTOQUE estoque)
        {
            _context.Entry(estoque).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
