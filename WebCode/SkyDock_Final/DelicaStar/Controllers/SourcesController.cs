using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SkyDock.Models;

namespace SkyDock.Controllers
{
    //Simple controller for pages due to static nature
    public class SourcesController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }

        public ViewResult About()
        {
            return View();
        }

        public ViewResult Careers()
        {
            return View();
        }

        public ViewResult supermegasecretpage()
        {
            return View();
        }
    }
}
