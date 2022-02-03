using Microsoft.EntityFrameworkCore;
using WhatsCookin.Data;
using WhatsCookin.Models;
using WhatsCookin.Repositories.Interfaces;

namespace WhatsCookin.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly AppDbContext _context;
    
    public UserRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public Task<User?> GetUserByUsername(string username)
    {
        return _context.Users.FirstOrDefaultAsync(user => user.Username.Equals(username));
    }

    public Task<bool> CheckIdByUsername(string username)
    {
        return _context.Users.AnyAsync(user => user.Username.Equals(username));
    }
    
    public Task<bool> CheckIdByEmail(string email)
    {
        return _context.Users.AnyAsync(user => user.Email.Equals(email));
    }
}

