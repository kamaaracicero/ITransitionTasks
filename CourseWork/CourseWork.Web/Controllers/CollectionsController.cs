using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseWork.Web.Controllers
{
    public class CollectionsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
