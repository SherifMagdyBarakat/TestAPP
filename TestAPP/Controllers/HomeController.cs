using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Reflection;
using TestAPP.Models;

namespace TestAPP.Controllers
{
    [Authorize]
    public class HomeController:Controller
    {
        private IEmployeeRepository _employeeRepository;
        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public string getdetails()
        {
            return "this is just for testing";
        }
        [AllowAnonymous]
        public IActionResult Index() 
        {
            var model = _employeeRepository.GetAllEmployees();

            
          
            ViewData["Rows"] = "2";
            ViewData["Columns"] = "4";
            return View(model);
        }
        //[Authorize(Roles = "HR")]
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(Employee emp)
        {
            //Stream the photo and set the class photo

            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);


            FileInfo fileInfo = new FileInfo(emp.FilePath.FileName);
            string fileName = emp.FilePath.FileName;

            string fileNameWithPath = Path.Combine(path, fileName);
            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                emp.FilePath.CopyTo(stream);
            }


            // Convert the file into binary array

            FileStream fs = new FileStream(fileNameWithPath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            Byte[] bytes = br.ReadBytes((Int32)fs.Length);
            br.Close();
            fs.Close();

            emp.photo = bytes;

          
                _employeeRepository.AddEmployee(emp);
                return RedirectToAction("Index");
         

    


        }

        public IActionResult Details(int id)
        {
            Employee e = _employeeRepository.GetOneEmployee(id);

            return View(e);
        }
        [HttpPost]
        public IActionResult Details()
        {
            return RedirectToAction("Index");
        }


        
        public IActionResult Update(int id)
        {
            Employee emp = _employeeRepository.GetOneEmployee(id);

            return View(emp);
        }

        [HttpPost]
        public IActionResult Update(Employee emp)
        {
            //Stream the photo and set the class photo

            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);


            FileInfo fileInfo = new FileInfo(emp.FilePath.FileName);
            string fileName = emp.FilePath.FileName;

            string fileNameWithPath = Path.Combine(path, fileName);
            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                emp.FilePath.CopyTo(stream);
            }


            // Convert the file into binary array

            FileStream fs = new FileStream(fileNameWithPath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            Byte[] bytes = br.ReadBytes((Int32)fs.Length);
            br.Close();
            fs.Close();

            emp.photo = bytes;

            _employeeRepository.UpdateEmployee(emp);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Employee emp = _employeeRepository.GetOneEmployee(id);

            return View(emp);
        }


        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {

            _employeeRepository.DeleteEmployee(id);

            return RedirectToAction("Index");

        }



    }
}
