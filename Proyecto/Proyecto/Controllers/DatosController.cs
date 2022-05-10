using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proyecto.Models;

namespace Proyecto.Controllers
{
    public class DatosController : Controller
    {
        //ingreso de datos
        public String Index(int device, int valor, DateTime date)
        {
            using (UserContext context = new UserContext())
            {
                Dato datos = new Dato();
                datos.Dispositivo = device;
                datos.Valor = valor;
                datos.Fecha = date;
                context.Datos.Add(datos);
                context.SaveChanges();
            }
            return device.ToString() + " valor:" + valor.ToString() + " fecha: " + date.ToString();
        }

        //Para pruebas de conexiones Http
        public string hola()
        {
            return "hola";
        }

    }
}
