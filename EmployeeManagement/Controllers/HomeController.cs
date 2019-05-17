using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class HomeController : Controller
    {
        private IEmployeeRepository _employeeRepository;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public ViewResult Index()
        {
          return View( _employeeRepository.GetAllEmployee());
        }


        public ViewResult Employee(int Id)
        {
            return View(_employeeRepository.GetEmployee(Id));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                Employee emp = _employeeRepository.Add(employee);
                return RedirectToAction("Employee", new { Id = emp.Id });
            }
            else
            {
                return View();
            }
           
        }

    }
}