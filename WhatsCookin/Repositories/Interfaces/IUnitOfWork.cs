namespace WhatsCookin.Repositories.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IUserRepository UserRepository { get; }
    
    int SaveChanges();
}