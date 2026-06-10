public interface IJwtTokenService
{
    string GenerateToken(User user);
}