using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ToDoAppBE.Database;
using ToDoAppBE.Entities;
using ToDoAppBE.Exceptions;
using ToDoAppBE.Repository.IRepository;
using ToDoAppBE.Services.Interfaces;

namespace ToDoAppBE.Services;

public class UserService : IUserService
{
    
   
    private readonly IConfiguration _configuration;
    private readonly IUserRepository _userRepository;

    public UserService( IConfiguration configuration, IUserRepository userRepository)
    {
        
        _configuration = configuration;
        _userRepository = userRepository;
    }

    public async Task<int> Register(UserEntity user, string password)
    {
        if (await UserExist(user.Username))
        {
            throw new BadRequestException($"User : {user.Username} already exist !");
        }

        CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;
        
        await _userRepository.AddUser(user);
        await _userRepository.SaveChange();
        
        return user.Id;
    }

    public async Task<string> Login(string username, string password)
    {
        var user = await _userRepository.GetUserByName(username);

        if (user is null)
        {
            throw new NotFoundException($"Username : {username} not exist !");
        }

        if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
        {
            throw new UnauthorizedException($"Combination username : {username} and password : {password} is incorrect !");
        }

        return CreateToken(user);
    }

    public async Task<bool> UserExist(string username)
    {
        var user = await _userRepository.GetUserByName(username);

        if (user is null)
        {
            return false;
        }

        return true;
    }

    public async Task<int> GetUserIdByName(string username)
    {
        var user = await _userRepository.GetUserByName(username);
        
        if (user is null)
        {
            throw new NotFoundException($"Username : {username} not exist !");
        }
        
        var userId = user.Id;
        
        return userId;
    }

    private void CreatePasswordHash( string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new System.Security.Cryptography.HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }

    private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
        {
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);
        }
    }

    private string CreateToken(UserEntity user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Username)
        };

        var tokenKey = _configuration["Token:Key"];
        var issuer = _configuration["Token:Issuer"];
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(1),
            SigningCredentials = credentials,
            Issuer = issuer
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var securityToken = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(securityToken);
    }
}