using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HRSystem.Controllers
{
    public class GroupController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public GroupController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddNewGroup()
        {
            var allClaims = Permissions.GenerateAllPermissions();
            var allPermissions = allClaims.Select(p => new CheckBoxViewModel { DisplayValue = p }).ToList();
            var viewModel = new PermissionsFormViewModel
            {
                RoleId = "",
                RoleName = "",
                RoleCalims = allPermissions
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNewGroup(PermissionsFormViewModel model)
        {
            int counter = 0;
            foreach(var item in model.RoleCalims)
            {
                if (!item.IsSelected)
                    counter++;
            }
            if(counter == 28)
            {
                ModelState.AddModelError("RoleCalims", "Please select the permissions");
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await roleManager.CreateAsync(new IdentityRole { Name = model.RoleName.Trim()});
            IdentityRole newGroup = await roleManager.FindByNameAsync(model.RoleName);
            var selectedClaims = model.RoleCalims.Where(c => c.IsSelected).ToList();
            foreach (var claim in selectedClaims)
                await roleManager.AddClaimAsync(newGroup, new Claim("Permission", claim.DisplayValue));
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> UniqueGroupName(string RoleName)
        {
            var role = await roleManager.FindByNameAsync(RoleName);
            if (role != null)
            {
                return Json(false); 
            }
            return Json(true);
        }
    }
}
