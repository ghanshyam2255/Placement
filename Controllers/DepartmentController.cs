using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PLACEMENT_2.Models;

namespace PLACEMENT_2.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly DBContext _departmentDBContext;
        public DepartmentController (DBContext departmentDBContext)
            //upar vala constroctor h mera
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

        public IActionResult Department()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        //Create
        [HttpPost]
        public IActionResult Create(department Model)
        {
            _departmentDBContext.Department.Add(Model);
            _departmentDBContext.SaveChanges();
           // return RedirectToAction("Index");
            // return View();

          
                //modal validate
                if (ModelState.IsValid)
                {
                _departmentDBContext.Department.Add(Model);
                _departmentDBContext.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(Model);
                }



            }
        public IActionResult Update(int id)
        {
            return View(_departmentDBContext.Department.Where(a => a.Id == id).FirstOrDefault());
        }

        [HttpPost]
        //public IActionResult Update_Post(department emp)
        //{
        //    _departmentDBContext.Update(emp);
        //    _departmentDBContext.SaveChanges();
        //    return RedirectToAction("Index");
        //}


        public IActionResult Update(department updatemodel)
        {
            var old_student_entries = _departmentDBContext.Department.FirstOrDefault(e => e.Id == updatemodel.Id);
            _departmentDBContext.Entry(old_student_entries).CurrentValues.SetValues(updatemodel);
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

