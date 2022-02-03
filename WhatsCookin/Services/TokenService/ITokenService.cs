using WhatsCookin.Models;

namespace WhatsCookin.Services.TokenService;

public interface ITokenService
{
    string CreateToken(User? user);
}