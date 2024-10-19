using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;
using X.PagedList.Extensions;
using Libreria.Data;
using Libreria.Models;

namespace Libreria.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BibliotecaContext _context;

        public HomeController(ILogger<HomeController> logger, BibliotecaContext context)
        {
            _logger = logger;
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public IActionResult Index(int? page)
        {
            int pageSize = 10; // Número de elementos por página
            int pageNumber = (page ?? 1); // Número de página actual

            // Obtiene la lista de libros, asegurándote de incluir los autores
            var libros = _context.Libros.Include(libro => libro.Autor).ToList();

            // Convierte la lista a IPagedList
            var pagedList = libros.ToPagedList(pageNumber, pageSize);

            // Pobla ViewBag con los autores para la vista
            ViewBag.Autores = _context.Autores.ToList(); // Ajusta según sea necesario para obtener los autores

            return View(pagedList); // Retorna la lista paginada
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CrearLibro(Libro libro)
        {
            if (ModelState.IsValid)
            {
                _context.Libros.Add(libro);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Libro creado exitosamente";
                return RedirectToAction("Index");
            }

            ViewBag.Autores = _context.Autores.ToList(); // Para volver a cargar los autores en caso de error
            return View(libro);
        }

        [HttpPost]
        public IActionResult CrearAutor(Autor autor)
        {
            if (ModelState.IsValid)
            {
                _context.Autores.Add(autor);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Autor creado exitosamente";
                return RedirectToAction("Index");
            }

            return View(autor);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
