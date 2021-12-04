using ExchangeOffice.IRepositories;
using ExchangeOffice.IServices;
using System.Security.Cryptography;
using System.Text;

namespace ExchangeOffice.Services
{
    public class AuthService : IAuthService
    {
        IRepositoryCashers repositoryCashers;

        public AuthService(IRepositoryCashers repositoryCashers)
        {
            this.repositoryCashers = repositoryCashers;
        }

        public bool Authentificate(string login, string password)
        {
            string hash;
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                hash = BitConverter.ToString(hashedBytes);
            }
            var casher = repositoryCashers.GetAllQueryable().Where(c => c.Login == login && c.PasswordHash == hash).Any();

            return casher;
        }
    }
}
