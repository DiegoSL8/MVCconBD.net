using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCconBD2.Data;
using MVCconBD2.Models;

namespace MVCconBD2.Controllers
{
    public class PeliculasController : Controller
    {
        private readonly MVCconBD2Context _context;

        public PeliculasController(MVCconBD2Context context)
        {
            _context = context;
        }

        // GET: Peliculas
        // Recibe el texto a buscar y la página actual
        public async Task<IActionResult> Index(string buscarTitulo, int? numeroPagina)
        {
            // 1. Preparamos la consulta a la base de datos
            var peliculas = from p in _context.Pelicula
                            select p;

            // 2. Lógica del Buscador: Si el usuario escribió algo, filtramos
            if (!String.IsNullOrEmpty(buscarTitulo))
            {
                peliculas = peliculas.Where(s => s.Titulo!.Contains(buscarTitulo));
            }

            // 3. Lógica de Paginación
            int pageSize = 5; // Requisito del profesor: 5 o 10 registros
            int pageIndex = numeroPagina ?? 1; // Si no hay página, vamos a la 1

            int totalRegistros = await peliculas.CountAsync(); // Contamos cuántas hay en total
            int totalPaginas = (int)Math.Ceiling(totalRegistros / (double)pageSize);

            // Guardamos datos en el ViewBag para poder dibujar los botones HTML
            ViewBag.TotalPaginas = totalPaginas;
            ViewBag.PaginaActual = pageIndex;
            ViewBag.BuscarTitulo = buscarTitulo; // Guarda la búsqueda al cambiar de página

            // .Skip() se salta las páginas anteriores y .Take() toma los 5 registros correspondientes
            var peliculasPaginadas = await peliculas
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return View(peliculasPaginadas);
        }

        // GET: Peliculas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pelicula = await _context.Pelicula
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pelicula == null)
            {
                return NotFound();
            }

            return View(pelicula);
        }

        // GET: Peliculas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Peliculas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Anio,Genero,Recaudacion,Director,Sinopsis")] Pelicula pelicula)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pelicula);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pelicula);
        }

        // GET: Peliculas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pelicula = await _context.Pelicula.FindAsync(id);
            if (pelicula == null)
            {
                return NotFound();
            }
            return View(pelicula);
        }

        // POST: Peliculas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Anio,Genero,Recaudacion,Director,Sinopsis")] Pelicula pelicula)
        {
            if (id != pelicula.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pelicula);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PeliculaExists(pelicula.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pelicula);
        }

        // GET: Peliculas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pelicula = await _context.Pelicula
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pelicula == null)
            {
                return NotFound();
            }

            return View(pelicula);
        }

        // POST: Peliculas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pelicula = await _context.Pelicula.FindAsync(id);
            if (pelicula != null)
            {
                _context.Pelicula.Remove(pelicula);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PeliculaExists(int id)
        {
            return _context.Pelicula.Any(e => e.Id == id);
        }
    }
}
