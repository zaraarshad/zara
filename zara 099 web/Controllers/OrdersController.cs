using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using zara_099_web.DataDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zara_099_web.Models;
namespace Zara_Arshad.Controllers
{
    public class OrdersController : Controller
    {
    
        private readonly StoreDb _context;

        public OrdersController(StoreDb context)
        {
            _context = context;
        }


        // GET: Orders
        public async Task<IActionResult> Index()
        {
            
            return View("~/Views/Invoice/ViewOrder.cshtml",await _context.orders.ToListAsync());
        }


        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.orders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            double total = 0;
            total = order.quantity * order.price;
            ViewBag.message = total;
            return View("~/Views/Invoice/Details.cshtml", order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            return View("~/Views/Invoice/CreateOrder.cshtml");
        }


        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,name,descirption,quantity,price")] OrderModel order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("~/Views/Invoice/CreateOrder.cshtml", order);
        }

        
       
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.orders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View("~/Views/Invoice/DeleteOrder.cshtml", order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.orders.FindAsync(id);
            _context.orders.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.orders.Any(e => e.Id == id);
        }
    }
}
