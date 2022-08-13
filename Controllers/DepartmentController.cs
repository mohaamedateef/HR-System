using Microsoft.AspNetCore.Mvc;

namespace HRSystem.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }
        public IActionResult Index()
        {
            return View(departmentService.GetAll());
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(DepartmentViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            departmentService.Add(viewModel);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Department department = departmentService.GetById(Id);
            DepartmentViewModel viewModel = new DepartmentViewModel { Id = department.Id, Name = department.Name };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Edit(DepartmentViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            departmentService.Edit(viewModel);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int Id)
        {
            departmentService.Delete(Id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Unique(string Name,int Id)
        {
            Department department = departmentService.GetByName(Name);
            if (department==null||department.Id==Id)
                return Json(true);
            return Json(false);
        }
    }
}
