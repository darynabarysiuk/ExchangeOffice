namespace ExchangeOffice.IServices
{
    public interface IAuthService
    {
        public Task<bool> Authentificate(string login, string password);
    }
}
