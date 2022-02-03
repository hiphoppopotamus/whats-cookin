using Microsoft.AspNetCore.Mvc;
using WhatsCookin.Dtos;
using WhatsCookin.Models;

namespace WhatsCookin.Services.UserService;

public interface IUserService
{
    string GetMyName();

    User RegisterUser(RegisterUserDto request);

    User? LoginUser(LoginUserDto request);
}