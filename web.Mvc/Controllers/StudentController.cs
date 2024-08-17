using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;
using System.Text.Unicode;
using web.Mvc.Models;

namespace web.Mvc.Controllers
{
    public class StudentController : Controller
    {
        Uri baseAddress = new Uri("http://localhost:48855/api");

        private readonly HttpClient _httpClient;

        public StudentController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<UserViewModel> users = new List<UserViewModel>();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/Student/Get").Result;
            if(response.IsSuccessStatusCode)
            {
                string data=response.Content.ReadAsStringAsync().Result;
                users =JsonConvert.DeserializeObject<List<UserViewModel>>(data);
            }

            return View(users);
        }

        [HttpGet]
        public IActionResult Create()
        {
            List<Department> ListDepartments = new List<Department>()
            {
                new Department() {Id = "IT", Name="IT" },
                new Department() {Id = "CSE", Name="CSE" },
                new Department() {Id = "EEE", Name="EEE" },
                new Department() {Id ="BME", Name="BME" }
            };
            // Retrieve departments and build SelectList
            ViewBag.Department = new SelectList(ListDepartments, "Id", "Name");
            return View();

         
        }
        [HttpPost]
        public IActionResult Create(UserViewModel model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = _httpClient.PostAsync(_httpClient.BaseAddress + "/Student/Create", content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id) 
        {
            List<Department> ListDepartments = new List<Department>()
            {
                new Department() {Id = "IT", Name="IT" },
                new Department() {Id = "CSE", Name="CSE" },
                new Department() {Id = "EEE", Name="EEE" },
                new Department() {Id ="BME", Name="BME" }
            };
            // Retrieve departments and build SelectList
            ViewBag.Department = new SelectList(ListDepartments, "Id", "Name");

            UserViewModel model = new UserViewModel();
                HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/Student/GetById/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    model = JsonConvert.DeserializeObject<UserViewModel>(data);
                }
                return View(model);
            
            
        }
        [HttpPost]
        public IActionResult Edit(UserViewModel model)
        {
            string data =JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = _httpClient.PutAsync(_httpClient.BaseAddress + "/Student/Update", content).Result;
            if(response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            UserViewModel model = new UserViewModel();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/Student/GetById/" + id).Result;
            if(response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                model =JsonConvert.DeserializeObject<UserViewModel>(data);
            }
   
            return View(model);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            HttpResponseMessage response = _httpClient.DeleteAsync(_httpClient.BaseAddress + "/Student/Delete/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
