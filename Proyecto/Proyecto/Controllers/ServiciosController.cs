using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proyecto.Models;
using Newtonsoft.Json;

namespace Proyecto.Controllers
{
    [Filtro.Autorizacion]
    public class ServiciosController : Controller
    {
        UserContext db = new UserContext();

        //Agregar dispositivo
        public string agregaDispositivo(string nombre, int max, int min)
        {
            if(String.IsNullOrEmpty(nombre) || max==min)
                return "Datos erroneos";

            using (UserContext context = new UserContext())
            {
                Dispositivo device = new Dispositivo();
                device.Nombre = nombre;
                device.Max = max;
                device.Min = min;
                device.Usuario = "Hacienda";
                context.Dispositivos.Add(device);
                context.SaveChanges();
                return "El dispositivo: " + nombre+" fue agregado";
            }
        }

        //cambiar contraseña
        public string cambioContra(string password)
        {
            using (UserContext context = new UserContext())
            {
                Usuario user = context.Usuarios.FirstOrDefault(x=>x.Nombre=="Hacienda");
                user.Contraseña = password;
                context.SaveChanges();
            }
            return "Se ha cambiado la contraseña";
        }

        //Lista los dispositivo (JSON)
        public string ListDevice()
        {
            var device = db.Dispositivos.ToList();
            string stringJSON = JsonConvert.SerializeObject(device);
            return stringJSON;
        }

        //Elimina device
        public string elimDevice(string num)
        {
            using (UserContext context = new UserContext())
            {
                Dispositivo device = context.Dispositivos.FirstOrDefault(x => x.Id == int.Parse(num));
                context.Remove(device);
                context.SaveChanges();
            }
            return "Dispositivo eliminado";
        }

        //editar dispositivos
        public string editaDispositivo(string D_id, string nombre, int max, int min)
        {
            
            if (String.IsNullOrEmpty(nombre) || max == min)
                return "Datos erroneos";

            using (UserContext context = new UserContext())
            {
                Dispositivo device = context.Dispositivos.FirstOrDefault(x => x.Id == int.Parse(D_id));
                device.Nombre = nombre;
                device.Max = max;
                device.Min = min;
                context.SaveChanges();
                return "El dispositivo " + nombre + " fue editado";
            }
        }

        //lista los valores de temp. (Json)
        public string ListDatos()
        {
            var datos = db.Datos.ToList();
            string stringJSON = JsonConvert.SerializeObject(datos);
            return stringJSON;
        }

        //Envia el numero de dispositivos y sus los id
        public int[] nDevice()
        {
            List<int> ids = new List<int>();
            var device = db.Dispositivos.ToList();
            foreach(var e in device)
                ids.Add(e.Id);
            return ids.ToArray();
        }
        //Envia los datos por dispositivo 
        public string[] getDevice(int id)
        {
            var device = db.Dispositivos.ToList();
            int max = device.Single(x => x.Id == id).Max;
            int min = device.Single(x => x.Id == id).Min;
            var datos = db.Datos.ToList();
            var dato = datos.Where(x => x.Dispositivo == id);
            string stringJSON = JsonConvert.SerializeObject(dato);
            return new string[] { stringJSON, max.ToString(), min.ToString()} ;
        }
        
    }
}
