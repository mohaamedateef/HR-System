namespace HRSystem.Services.GroupServ
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository groupRepository;

        public GroupService(IGroupRepository groupRepository)
        {
            this.groupRepository = groupRepository;
        }
        public List<IdentityRole> GetRoles()
        {
            return groupRepository.GetRoles();
        }
    }
}
