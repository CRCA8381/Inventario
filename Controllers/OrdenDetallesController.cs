using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Inventario.Models;
using Web_Inventario.Data;

public class OrdenDetallesController : Controller
{
    private readonly ApplicationDbContext _context;

    public OrdenDetallesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: ORDENDETALLES
    public async Task<IActionResult> Index()    
    {
        return View(await _context.OrdenesDetalle.ToListAsync());
    }

    // GET: ORDENDETALLES/Details/5
    public async Task<IActionResult> Details(int? ordendetalleid)
    {
        if (ordendetalleid == null)
        {
            return NotFound();
        }

        var ordendetalle = await _context.OrdenesDetalle
            .FirstOrDefaultAsync(m => m.OrdenDetalleId == ordendetalleid);
        if (ordendetalle == null)
        {
            return NotFound();
        }

        return View(ordendetalle);
    }

    // GET: ORDENDETALLES/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: ORDENDETALLES/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("OrdenDetalleId,OrdenCompraId,OrdenCompra,ProductoId,Producto,Cantidad,PrecioUnitario")] OrdenDetalle ordendetalle)
    {
        if (ModelState.IsValid)
        {
            _context.Add(ordendetalle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(ordendetalle);
    }

    // GET: ORDENDETALLES/Edit/5
    public async Task<IActionResult> Edit(int? ordendetalleid)
    {
        if (ordendetalleid == null)
        {
            return NotFound();
        }

        var ordendetalle = await _context.OrdenesDetalle.FindAsync(ordendetalleid);
        if (ordendetalle == null)
        {
            return NotFound();
        }
        return View(ordendetalle);
    }

    // POST: ORDENDETALLES/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? ordendetalleid, [Bind("OrdenDetalleId,OrdenCompraId,OrdenCompra,ProductoId,Producto,Cantidad,PrecioUnitario")] OrdenDetalle ordendetalle)
    {
        if (ordendetalleid != ordendetalle.OrdenDetalleId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(ordendetalle);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdenDetalleExists(ordendetalle.OrdenDetalleId))
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
        return View(ordendetalle);
    }

    // GET: ORDENDETALLES/Delete/5
    public async Task<IActionResult> Delete(int? ordendetalleid)
    {
        if (ordendetalleid == null)
        {
            return NotFound();
        }

        var ordendetalle = await _context.OrdenesDetalle
            .FirstOrDefaultAsync(m => m.OrdenDetalleId == ordendetalleid);
        if (ordendetalle == null)
        {
            return NotFound();
        }

        return View(ordendetalle);
    }

    // POST: ORDENDETALLES/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? ordendetalleid)
    {
        var ordendetalle = await _context.OrdenesDetalle.FindAsync(ordendetalleid);
        if (ordendetalle != null)
        {
            _context.OrdenesDetalle.Remove(ordendetalle);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool OrdenDetalleExists(int? ordendetalleid)
    {
        return _context.OrdenesDetalle.Any(e => e.OrdenDetalleId == ordendetalleid);
    }
}
