using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proyecto.Models;

namespace Proyecto.Controllers
{
    public class SeguridadController : Controller
    {
        UserContext db = new UserContext();
        public string Login(string user, string password)
        {
            var usuario = db.Usuarios.ToList();
            var flag = usuario.Exists(x => x.Nombre == user && x.Contraseña == password);

            if (flag)
                HttpContext.Session.SetString("usuario", "OK");
            else
                return "Usuario o Contraseña invalidos";
            return "Ingreso";
        }
    }
}
