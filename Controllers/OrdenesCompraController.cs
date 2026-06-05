using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web_Inventario.Data;
using Web_Inventario.Models;

public class OrdenesCompraController : Controller
{
    private readonly ApplicationDbContext _context;

    public OrdenesCompraController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: ORDENCOMPRAS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.OrdenesCompra.ToListAsync());
    }

    // GET: ORDENCOMPRAS/Details/5
    public async Task<IActionResult> Details(int? ordencompraid)
    {
        if (ordencompraid == null)
        {
            return NotFound();
        }

        var ordencompra = await _context.OrdenesCompra
            .FirstOrDefaultAsync(m => m.OrdenCompraId == ordencompraid);
        if (ordencompra == null)
        {
            return NotFound();
        }

        return View(ordencompra);
    }

    // GET: OrdenCompras/Create
    public IActionResult Create()
    {
        ViewData["ProveedorId"] = new SelectList(_context.Proveedores, "ProveedorId", "Nombre");
        return View();
    }


    // POST: ORDENCOMPRAS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("OrdenCompraId,Fecha,ProveedorId")] OrdenCompra ordencompra)
    {
        if (ModelState.IsValid)
        {
            _context.Add(ordencompra);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["ProveedorId"] = new SelectList(_context.Proveedores, "ProveedorId", "Nombre", ordencompra.ProveedorId);
        return View(ordencompra);
    }


    // GET: ORDENCOMPRAS/Edit/5
    public async Task<IActionResult> Edit(int? ordencompraid)
    {
        if (ordencompraid == null)
        {
            return NotFound();
        }

        var ordencompra = await _context.OrdenesCompra.FindAsync(ordencompraid);
        if (ordencompra == null)
        {
            return NotFound();
        }
        return View(ordencompra);
    }

    // POST: ORDENCOMPRAS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? ordencompraid, [Bind("OrdenCompraId,Fecha,ProveedorId,Proveedor,Detalles")] OrdenCompra ordencompra)
    {
        if (ordencompraid != ordencompra.OrdenCompraId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(ordencompra);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdenCompraExists(ordencompra.OrdenCompraId))
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
        return View(ordencompra);
    }

    // GET: ORDENCOMPRAS/Delete/5
    public async Task<IActionResult> Delete(int? ordencompraid)
    {
        if (ordencompraid == null)
        {
            return NotFound();
        }

        var ordencompra = await _context.OrdenesCompra
            .FirstOrDefaultAsync(m => m.OrdenCompraId == ordencompraid);
        if (ordencompra == null)
        {
            return NotFound();
        }

        return View(ordencompra);
    }
    
    // POST: ORDENCOMPRAS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? ordencompraid)
    {
        var ordencompra = await _context.OrdenesCompra.FindAsync(ordencompraid);
        if (ordencompra != null)
        {
            _context.OrdenesCompra.Remove(ordencompra);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool OrdenCompraExists(int? ordencompraid)
    {
        return _context.OrdenesCompra.Any(e => e.OrdenCompraId == ordencompraid);
    }
}
