namespace HRSystem.Repositories.GroupRepo
{
    public class GroupRepository : IGroupRepository
    {
        private readonly HRDbContext context;

        public GroupRepository(HRDbContext context)
        {
            this.context = context;
        }
        public List<IdentityRole> GetRoles()
        {
            return context.Roles.ToList();
        }
    }
}
