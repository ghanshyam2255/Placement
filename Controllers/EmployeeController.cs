using Microsoft.AspNetCore.Mvc;
using PLACEMENT_2.Models;

namespace PLACEMENT_2.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly DBContext dbContext;
        public EmployeeController(DBContext employeeDBContext)
        {
            dbContext = employeeDBContext;
        }
        public IActionResult Index()
        {
            var employee = dbContext.Employee.ToList();
            return View(employee);
        }

        public IActionResult CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateEmployee(Employee Model)
        {
            //modal validate
            if (ModelState.IsValid)
            {
                dbContext.Employee.Add(Model);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(Model);
            }
        }
        public IActionResult Update(int id)
        {
            return View(dbContext.Employee.Where(a => a.Id == id).FirstOrDefault());
        }
        [HttpPost]
        [ActionName("Update")]
        public IActionResult Update_Post(Employee emp)
        {
            dbContext.Employee.Update(emp);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        //[HttpPost]
        [ActionName("Delete")]
        public IActionResult Delete(int id)
        {
            var teacher = dbContext.Employee.Where(a => a.Id == id).FirstOrDefault();
            dbContext.Employee.Remove(teacher);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

