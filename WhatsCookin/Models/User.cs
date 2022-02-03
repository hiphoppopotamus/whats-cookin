using System.ComponentModel.DataAnnotations;

namespace WhatsCookin.Models;

public class User
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public string FirstName { get; set; } = string.Empty;
    
    [Required]
    public string LastName { get; set; } = string.Empty;
    
    [Required]
    public DateTime? DateOfBirth { get; set; }
    
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    
    [Required]
    [MinLength(6), MaxLength(36)]
    public string Username { get; set; } = string.Empty;

    [Required]
    public byte[] PasswordHash { get; set; } = Array.Empty<byte>();
    
    [Required]
    public byte[] PasswordSalt { get; set; } = Array.Empty<byte>();
}