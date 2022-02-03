using System.Security.Claims;
using System.Security.Cryptography;
using WhatsCookin.Dtos;
using WhatsCookin.Models;
using WhatsCookin.Repositories.Interfaces;

namespace WhatsCookin.Services.UserService;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
    {
        _unitOfWork = unitOfWork;
        _httpContextAccessor = httpContextAccessor;
    }

    public string GetMyName()
    {
        var result = string.Empty;
        if (_httpContextAccessor.HttpContext != null)
        {
            result = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
        }
        return result;
    }

    public User RegisterUser(RegisterUserDto request)
    {
        if (_unitOfWork.UserRepository.CheckIdByUsername(request.Username).Result)
        {
            throw new BadHttpRequestException("Username exists");
        }

        if (_unitOfWork.UserRepository.CheckIdByEmail(request.Email).Result)
        {
            throw new BadHttpRequestException("Email exists");
        }
        
        CreatePasswordHash(request.Password, out var passwordHash, out var passwordSalt);
        var user = new User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            DateOfBirth = request.DateOfBirth,
            Email = request.Email,
            Username = request.Username,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt
        };
        
        var result = _unitOfWork.UserRepository.Add(user);
        _unitOfWork.SaveChanges();
        
        if (result == null)
            throw new BadHttpRequestException("Error creating users");
        return user;
    }

    public User LoginUser(LoginUserDto request)
    {
        var user = _unitOfWork.UserRepository.GetUserByUsername(request.Username).Result; 
        if (user == null)
        {
            throw new BadHttpRequestException("User not found");
        }
        //TODO might want to merge these two and generalise them for security?
        if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt)) 
        {
            throw new BadHttpRequestException("Incorrect password");
        }

        return user;
    }
    
    private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using var hmac = new HMACSHA512();
        passwordSalt = hmac.Key;
        passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
    }

    private static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using var hmac = new HMACSHA512(passwordSalt);
        var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        return computedHash.SequenceEqual(passwordHash);
    }
}