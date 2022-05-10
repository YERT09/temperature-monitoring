using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proyecto.Models;

namespace Proyecto.Controllers
{
    [Filtro.Autorizacion]
    public class TablasController : Controller
    {
        UserContext db = new UserContext();
        public IActionResult Device()
        {
            return View();
        }

        public IActionResult agregar()
        {
            return View();
        }

        public IActionResult CambioContra()
        {
            return View();
        }

        public IActionResult editDevice()
        {
            return View();
        }

        public IActionResult monitoreo()
        {
            var device = db.Dispositivos.ToList();
            return View(device);
        }

    }
}
