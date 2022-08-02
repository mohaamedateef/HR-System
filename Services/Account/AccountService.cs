namespace HRSystem.Services.Account
{
    public class AccountService:IAccountService
    {
        private readonly UserManager<Hr> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly HRDbContext context;

        public AccountService(UserManager<Hr> userManager,RoleManager<IdentityRole> roleManager,HRDbContext context)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.context = context;
        }

        public async Task<bool> CheckPassword(Hr hr, string password)
        {

            return await userManager.CheckPasswordAsync(hr,password);
        }

        public async Task<IdentityResult> Create(RegisterViewModel registerView)
        {
            Hr user = new Hr()
            {
                Name = registerView.Name,
                UserName = registerView.UserName,
                Email = registerView.Email,
                PhoneNumber = registerView.PhoneNumber,
            };
            return await userManager.CreateAsync(user,registerView.Password);
        }

        public async Task<Hr> GetByEmail(string email)
        {
            Hr user=await userManager.FindByEmailAsync(email);
            return user;
        }

        public Hr GetByPhone(string Phone)
        {
            return context.Users.FirstOrDefault(n => n.PhoneNumber == Phone);
        }
    }
}
