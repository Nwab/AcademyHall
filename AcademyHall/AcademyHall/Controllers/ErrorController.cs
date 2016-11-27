using AcademyHall.Models.ViewModels;
using System;
using System.Web.Mvc;

namespace AcademyHall.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index(int statusCode, Exception exception)
        {
            Response.StatusCode = statusCode;
            return View(new HttpErrorViewModel(Response.StatusCode,exception.Message));
        }
    }
}