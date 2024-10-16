using Microsoft.EntityFrameworkCore;
using Store.Data.Contexts;
using Store.Data.Entities;
using Store.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Repositories
{
    public class GenericRepository<TEnitty, TKey> : IGenericRepository<TEnitty, TKey> where TEnitty : BaseEntity<TKey>
    {
        private readonly StoreDbContext _context;

        public GenericRepository(StoreDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(TEnitty entity)
        => await _context.Set<TEnitty>().AddAsync(entity);

        public void Delete(TEnitty entity)
         => _context.Set<TEnitty>().Remove(entity);

        public async Task<IReadOnlyList<TEnitty>> GetAllAsync()
         => await _context.Set<TEnitty>().ToListAsync();

        public async Task<TEnitty> GetByIdAsync(TKey? id)
        => await _context.Set<TEnitty>().FindAsync(id);

        public void Update(TEnitty entity)
        => _context.Set<TEnitty>().Update(entity);
    }
}
