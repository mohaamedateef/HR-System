using Microsoft.AspNetCore.Mvc;

namespace HRSystem.Controllers
{
    public class UserController : Controller
    { 
        private readonly IGroupService groupService;
        private readonly IAccountService accountService;
        private readonly UserManager<Hr> userManager;

        public UserController(IGroupService groupService,IAccountService accountService,UserManager<Hr> userManager)
        {
            this.groupService = groupService;
            this.accountService = accountService;
            this.userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            List<UserDataViewModel> allUsers = await accountService.GetAllUsers();
            return View(allUsers);
        }
        [HttpGet]
        public IActionResult AddNewUser()
        {
            List<IdentityRole> roles = groupService.GetRoles();
            ViewBag.roles = roles;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNewUser(UserViewModel user)
        {
            if (!ModelState.IsValid)
            {
                List<IdentityRole> roles = groupService.GetRoles();
                ViewBag.roles = roles;
                return View(user);
            }
            else if(user.GroupName==null)
            {
                ModelState.AddModelError("GroupName", "Please select group");
                List<IdentityRole> roles = groupService.GetRoles();
                ViewBag.roles = roles;
                return View(user);
            }
            else if(await accountService.GetByEmail(user.Email)!=null)
            {

                ModelState.AddModelError("Email", "This Email already used");
                List<IdentityRole> roles = groupService.GetRoles();
                ViewBag.roles = roles;
                return View(user);
            }
            IdentityResult result = await accountService.AddUser(user);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("modelError", error.Description);
                }
                return View(user);
            }
            else
            {
                Hr addedUser = await accountService.GetByEmail(user.Email);
                await userManager.AddToRoleAsync(addedUser, user.GroupName);
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            List<IdentityRole> roles = groupService.GetRoles();
            ViewBag.roles = roles;
            string GroupName;
            Hr user = accountService.GetById(id);
            IList<string> userRoles = await userManager.GetRolesAsync(user);
            if (userRoles.Count != 0)
                GroupName = userRoles[0];
            else
                GroupName = "";
            UserViewModel viewModel = new UserViewModel() {
            Name =user.Name ,
            Email= user.Email,
            PassWord = user.PasswordHash,
            GroupName=GroupName
            };
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UserViewModel viewModel)
        {
            List<IdentityRole> roles = groupService.GetRoles();
            ViewBag.roles = roles;
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            else if (viewModel.GroupName == null)
            {
                ModelState.AddModelError("GroupName", "Please select group");
                return View(viewModel);
            }
            else
            {
                Hr user = await accountService.GetByEmail(viewModel.Email);
                if (user!=null&&user.Id!=viewModel.Id)
                {
                ModelState.AddModelError("Email", "This Email already used");
                return View(viewModel);
                }
            }
            accountService.Update(viewModel);
            Hr User = accountService.GetById(viewModel.Id);
            IList<string> userRoles = await userManager.GetRolesAsync(User);
            await userManager.RemoveFromRolesAsync(User, userRoles);
            await userManager.AddToRoleAsync(User, viewModel.GroupName);
            return RedirectToAction("Index");
            
        }
        public IActionResult Delete(string id)
        {
            accountService.Delete(id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> UniqueEmail(string Email)
        {
            if (await accountService.GetByEmail(Email) != null)
                return Json(false);
            return Json(true);
        }
    }
}
