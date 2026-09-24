using dataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using dataAccess.Models;
namespace Companydetail.Controllers
{
    public class EmployeeController : Controller
    {

        public readonly IEmployee _iemployee;
        public EmployeeController(IEmployee iemployee)
        {
            _iemployee = iemployee;
        }
        [HttpGet]
       public IActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee data)
        {
            await _iemployee.AddEmployee(data);
            return RedirectToAction("EmployeeLogin");
        }
        [HttpGet]
        public IActionResult EmployeeLogin() {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EmployeeLogin(Login data)
        {
            if (ModelState.IsValid)
            {
                await _iemployee.EmployeeLogin(data);
                return RedirectToAction("GetEmployee");

            }
            else
            {
                return View();
            }
        }   
        [HttpGet]
        public async Task<IActionResult> GetEmployee()
        {
            var res = await _iemployee.GetEmployee();
            return View(res);
        }
        [HttpGet]
        public async Task<IActionResult> EditEmployee(int id)
        {
            var res = await _iemployee.GetEmployeeById(id);
            return View(res);
        }

        [HttpPost]
        public async Task<IActionResult> EditEmployee(Employee data)
        {
            await _iemployee.EditEmployee(data);
            return RedirectToAction("GetEmployee");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
             var res = await _iemployee.GetEmployeeById(id);
            return View(res);
        }
        [HttpPost,ActionName("DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployeeConfirm(int id)
        //IActionResult means that the method can return
        //different types of responses,
        //such as a view, a redirect, or a JSON result.
        {
            await _iemployee.DeleteEmployee(id);
            return RedirectToAction("GetEmployee");
        }   

        public IActionResult Homepage()
        {
            return View();
        }

        public async Task<IActionResult> FunctionEmployee()
        {
            HttpClient client = new HttpClient();

            string json =
                await client.GetStringAsync(
                "http://localhost:7036/api/GetEmployee");

            ViewBag.Data = json; //viewbag means dynamic data that can be
                                 //passed from controller to view

            return View();
        }
    }
}
