using WhatsCookin.Models;

namespace WhatsCookin.Repositories.Interfaces;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User?> GetUserByUsername(string username);
    
    Task<bool> CheckIdByUsername(string username);
    
    Task<bool> CheckIdByEmail(string email);
}