using Microsoft.AspNetCore.Identity;

public class User : IdentityUser
{
    public string? DisplayName { get; set; }
    public DateTime CreatedAt { get; set; }
}