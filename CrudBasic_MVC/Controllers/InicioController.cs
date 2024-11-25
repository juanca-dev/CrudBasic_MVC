using CrudBasic_MVC.Datos;
using CrudBasic_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CrudBasic_MVC.Controllers
{
    public class InicioController : Controller
    {
       
        // Generamos una instancia a la clase ContextoDb para poder enviar y recibir información
        // de la base de datos.
        private readonly ContextoDb _contextoDb;
        public InicioController(ContextoDb contexto)
        {
           _contextoDb = contexto;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _contextoDb.MContacto.ToListAsync());
        }

        // Crear un método para mostrar la pagina para el ingreso de usuarios
        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }
        //METODO POS PARA ENVIAR LA INFORMACIÓN A LA BASE DE DATOS
        [HttpPost]
        [ValidateAntiForgeryToken] // Protege contra ataques xcss
        public async Task<IActionResult> Crear(MContacto contacto)
        {
            if (ModelState.IsValid)
            {
                //agregar la fecha  al sistema
                contacto.FechaCreacion =DateTime.Now;
                _contextoDb.MContacto.Add(contacto);
                await _contextoDb.SaveChangesAsync(); //Guardar la información en la base de datos.
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        //Metodo para  editar los datos del usuario
        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            //crear una variable contacto
            var contacto = _contextoDb.MContacto.Find(id);
            if (contacto == null)
            {
                return NotFound();
            }
            return View(contacto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken] // Protege contra ataques xcss
        public async Task<IActionResult> Editar(MContacto contacto)
        {
            if (ModelState.IsValid)
            {
                //agregar la fecha  al sistema
                contacto.FechaCreacion =DateTime.Now;
                _contextoDb.Update(contacto);
                await _contextoDb.SaveChangesAsync(); //Guardar la información en la base de datos.
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        //MÉTODO PARA VER ELA INFORMACIÓN DE LOS USUARIOS
        [HttpGet]
        public IActionResult Detalle(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            //crear una variable contacto
            var contacto = _contextoDb.MContacto.Find(id);
            if (contacto == null)
            {
                return NotFound();
            }
            return View(contacto);
        }

        // MÉTODO PARA ELIMINAR LOS USUARIOS

        [HttpGet]
        public IActionResult Borrar(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            //crear una variable contacto
            var contacto = _contextoDb.MContacto.Find(id);
            if (contacto == null)
            {
                return NotFound();
            }
            return View(contacto);
        }

        [HttpPost, ActionName("Borrar")]
        [ValidateAntiForgeryToken] // Protege contra ataques xcss
        public async Task<IActionResult> BorrarContacto(int? id)
        {
            var contacto = await _contextoDb.MContacto.FindAsync(id);
            if (contacto == null)
            {
                return View();
            }
            // ejecutamos el proceso de borrado
                _contextoDb.MContacto.Remove(contacto);
                await _contextoDb.SaveChangesAsync(); // GUARDA LA INFORMACIÓN EN LA BASE DE DATOS
                return RedirectToAction(nameof(Index));            
         }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
