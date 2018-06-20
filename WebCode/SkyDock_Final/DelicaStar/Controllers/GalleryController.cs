using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SkyDock.Models;
using Microsoft.AspNetCore.Authorization;

namespace SkyDock.Controllers
{
    //Simple controller for pages due to static nature
    public class GalleryController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }

        public ViewResult CraftGallery()
        {
            return View();
        }

        public ViewResult OrbitalGallery()
        {
            return View();
        }
    }
}
