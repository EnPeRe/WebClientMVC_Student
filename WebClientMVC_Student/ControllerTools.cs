using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using WebClientMVC_Student.Models;

namespace WebClientMVC_Student
{
    public static class ControllerTools
    {
        // Url del WebService
        private static string Baseurl = "http://localhost:50134/";


        public static async Task<List<Student>> Get()
        {
            List<Student> studentlist = new List<Student>();

            using (var client = new HttpClient())
            {

                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                var Res = await client.GetAsync("api/Student/GetAll");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    studentlist = JsonConvert.DeserializeObject<List<Student>>(EmpResponse);

                }
                return studentlist;
            }
        }

        public static void Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                var deleteTask = client.DeleteAsync("api/Student/DeleteById?id=" + id);
                deleteTask.Wait();
                var result = deleteTask.Result;
                if (!result.IsSuccessStatusCode)
                {
                    //logear el notSuccssesful
                }
            }
        }

        public static void Put()
        {
            using (HttpClient client = new HttpClient())
            {




            }

        }

        public static async Task Post(Student student)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);

                var myContent = JsonConvert.SerializeObject(student);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await client.PostAsync("api/Student/Add", byteContent);

                response.EnsureSuccessStatusCode();
            }
        }
    }
}