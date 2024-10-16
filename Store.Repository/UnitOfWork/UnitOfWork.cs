﻿using Store.Data.Contexts;
using Store.Data.Entities;
using Store.Repository.Interfaces;
using Store.Repository.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreDbContext _context;

        // Having a list of Repositories that we want to add it in a hash Table
        // direct retrieving for repository instances
        private Hashtable _repositories;

        public UnitOfWork(StoreDbContext context)
        {
            _context = context;
        }
        public async Task<int> CompletedAsync()
        => await _context.SaveChangesAsync();

        public IGenericRepository<TEntity, TKey> Repository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
            if(_repositories is null)
            {
                _repositories = new Hashtable();
            }

            var entityKey = typeof(TEntity).Name; // ex: Product

            if (!_repositories.ContainsKey(entityKey))
            {
                var repositoryType = typeof(IGenericRepository<,>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity), typeof(TKey)), _context);

                _repositories.Add(entityKey, repositoryInstance);
            }
            return (IGenericRepository < TEntity, TKey>) _repositories[entityKey];
        }
    }
}
