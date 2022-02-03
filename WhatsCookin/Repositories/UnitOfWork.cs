using WhatsCookin.Data;
using WhatsCookin.Repositories.Interfaces;

namespace WhatsCookin.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    
    public IUserRepository UserRepository { get; }

    public UnitOfWork(
        AppDbContext context,
        IUserRepository userRepository)
    {
        _context = context;
        UserRepository = userRepository;
    }
    
    public int SaveChanges() => _context.SaveChanges(); // Can use the return int for validation, its like the number of writes
    
    public void Dispose() // When we calling this?
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _context.Dispose();
        }
    }
}