using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_realtime_chat.DTOs;

public class RegisterRequest
{
    [Required]
    public required string Username { get; set; }
    [Required]
    public required string Password { get; set; }
}