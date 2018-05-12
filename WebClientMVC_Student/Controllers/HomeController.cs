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
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public async Task<ActionResult> StudentList()
        {
            ViewBag.Message = "Your student list page.";

            //returning the employee list to view  
            return View(await ControllerTools.Get());
        }

        public async Task<ActionResult> Delete(int id)
        {
            ViewBag.Message = "Your student list deleted page.";

            ControllerTools.Delete(id);

            return RedirectToAction("StudentList");
        }

        public async Task<ActionResult> Create()
        {
            return View();
        }

        [HttpPost()]
        public async Task<ActionResult> Create(Student student)
        {
            ViewBag.Message = "Your creation student page.";

            await ControllerTools.Post(student);

            return RedirectToAction("StudentList");
        }

        public async Task<ActionResult> Edit(int id)
        {
            return View(await ControllerTools.Get(id));
        }

        [HttpPost()]
        public async Task<ActionResult> Edit(Student student)
        {
            ViewBag.Message = "Your edit student page.";

            await ControllerTools.Put(student);

            return RedirectToAction("StudentList");
        }

        public async Task<ActionResult> Details(int id)
        {
            return View(await ControllerTools.Get(id));
        }

    }
}