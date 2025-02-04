using Capstone_BE.Models;

namespace Capstone_BE.Interfaces;

public interface ITokenService
{
    string CreateToken(User aUser);
}