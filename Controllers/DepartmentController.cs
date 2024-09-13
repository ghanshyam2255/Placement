using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PLACEMENT_2.Models;

namespace PLACEMENT_2.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly DepartmentDBContext _departmentDBContext;
        public DepartmentController (DepartmentDBContext departmentDBContext)
        {
            _departmentDBContext= departmentDBContext;
        }
        public IActionResult Index()
        {
            var data = _departmentDBContext.Department.ToList();
            return View(data);
        }

        //public IActionResult Update()
        //{
        //    return View();
        //}

        public IActionResult Departmentstaaf()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        //Create
        [HttpPost]
        public IActionResult Create(departmentstaaf Model)
        {
            _departmentDBContext.Department.Add(Model);
            _departmentDBContext.SaveChanges();
            return RedirectToAction("Index");
            // return View();
        }
        public IActionResult Update(int id)
        {
            return View(_departmentDBContext.Department.Where(a => a.Id == id).FirstOrDefault());
        }
        [HttpPost]
        [ActionName("Update")]
        public IActionResult Update_Post(DepartmentController emp)
        {
            _departmentDBContext.Update(emp);
            _departmentDBContext.SaveChanges();
            return RedirectToAction("Index");
        }
        //[HttpPost]
        [ActionName("Delete")]
        public IActionResult Delete(int id)
        {
            var teacher = _departmentDBContext.Department.Where(a => a.Id == id).FirstOrDefault();
            _departmentDBContext.Department.Remove(teacher);
            _departmentDBContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

