using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebClientMVC_Student.Models;

namespace WebClientMVC_Student.Controllers
{
    public class StudentController : Controller
    {
        string Baseurl = "http://localhost:50134/";

        // GET: Student
        [HttpGet()]
        public ActionResult Index()
        {
            return View();
        }

        [HttpDelete()]
        public async Task<ActionResult> Delete()
        {
            using (var client = new HttpClient())
            {

                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.DeleteAsync("api/Student");

                //Checking the response is successful or not which is sent using HttpClient  
                //if (Res.IsSuccessStatusCode)
                //{
                //    //Storing the response details recieved from web api   
                //    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                //    //Deserializing the response recieved from web api and storing into the Employee list  
                //    studentlist = JsonConvert.DeserializeObject<List<Student>>(EmpResponse);

                //}
                //returning the employee list to view  
                return View(/*studentlist*/);
            }
        }
    }
}