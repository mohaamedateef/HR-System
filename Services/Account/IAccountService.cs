namespace HRSystem.Services.Account
{
    public interface IAccountService
    {
        Task<Hr> GetByEmail(string email);
        Hr GetByPhone(string Phone);
       Task< IdentityResult> Create(RegisterViewModel registerView);
        Task <bool> CheckPassword(Hr hr, string password);

    }
}
