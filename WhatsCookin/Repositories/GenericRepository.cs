using Microsoft.EntityFrameworkCore;
using WhatsCookin.Data;
using WhatsCookin.Repositories.Interfaces;

namespace WhatsCookin.Repositories;

public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly AppDbContext _context;

    protected GenericRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<T?> Get(int id) => await _context.Set<T>().FindAsync(id);
    public async Task<IEnumerable<T>> GetAll() => await _context.Set<T>().ToListAsync();
    public async Task Add(T entity) => await _context.Set<T>().AddAsync(entity);
    public void Delete(T entity) =>_context.Set<T>().Remove(entity);
    public void Update(T entity) => _context.Set<T>().Update(entity);
}