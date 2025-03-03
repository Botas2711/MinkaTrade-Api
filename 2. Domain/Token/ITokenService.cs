using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._Domain.Token
{
    public interface ITokenService
    {
        public Task<string> GenerateToken(string username);
        public Task<string> ValidateToken(string token);
    }
}
