using System.ComponentModel.DataAnnotations;

namespace WhatsCookin.Dtos;

public class RegisterUserDto
{
    [Required]
    public string FirstName { get; set; } = string.Empty;
    
    [Required]
    public string LastName { get; set; } = string.Empty;

    [Required] 
    [DataType(DataType.Date)]
    public DateTime? DateOfBirth { get; set; } = null;
    
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    
    [Required]
    public string Username { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;
    // Potentially Confirmed Password property
}