﻿using Microsoft.AspNetCore.Mvc;

namespace HRSystem.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }
        public IActionResult Index()
        {
            List<Employee> employee = employeeService.GetAllEmployee();

            return View(employee);
        }
        [HttpGet]
        public IActionResult GetByName(string id)
        {
            List<Employee> employee = employeeService.GetEmployeeByName(id);
            return Json(employee);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            Employee employee=employeeService.GetEmployeeById(id);
            if(employee!=null)
            return View(employee);

            return NotFound();
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(EmployeeViewModel employeeViewModel)
        {
            if (ModelState.IsValid)
            {
                if (employeeViewModel.Gender == "0") 
                {
                    if(employeeViewModel.DeptId==0)
                    {
                        ModelState.AddModelError("Gender", "Gender is required");
                        ModelState.AddModelError("DeptId", "Department is required");
                        return View(employeeViewModel);


                    }
                    else
                    {
                        ModelState.AddModelError("Gender", "Gender is required");
                        return View(employeeViewModel);
                    }
                    
                }
                else if (employeeViewModel.DeptId == 0)
                {
                    ModelState.AddModelError("DeptId", "Department is required");
                    return View(employeeViewModel);
                }
                try
                    {

                        employeeService.InsertViewModel(employeeViewModel);
                        return RedirectToAction("Index");

                    }
                catch
                {
                    ModelState.AddModelError("Other", "Faild To Add Employee Please Try Again");
                    return View(employeeViewModel);

                }

            }
            return View(employeeViewModel);

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            EmployeeViewModel employeeViewModel = employeeService.GetViewModel(id);
            employeeViewModel.Id = id;

            return View(employeeViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EmployeeViewModel employeeViewModel)
        {
            if (ModelState.IsValid)
            {
                if (employeeViewModel.Gender == "0")
                {
                    if (employeeViewModel.DeptId == 0)
                    {
                        ModelState.AddModelError("Gender", "Gender is required");
                        ModelState.AddModelError("DeptId", "Department is required");
                        return View(employeeViewModel);


                    }
                    else
                    {
                        ModelState.AddModelError("Gender", "Gender is required");
                        return View(employeeViewModel);
                    }

                }
                else if (employeeViewModel.DeptId == 0)
                {
                    ModelState.AddModelError("DeptId", "Department is required");
                    return View(employeeViewModel);
                }
                employeeService.UpdateEmployeeWithViewModel(employeeViewModel);
                return RedirectToAction("Index");
            }
            return View(employeeViewModel);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            employeeService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}