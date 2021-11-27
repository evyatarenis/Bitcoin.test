using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bitcoin_Test.Data;
using Bitcoin_Test.Models;

namespace Bitcoin_Test.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> ShowOrders()
        {
            return View(await _context.Orders.Where(x=>x.UserName == User.Identity.Name).ToListAsync());
        }
               

        // GET: Orders/Create
        public IActionResult Create()
        {
            return View(new Order());
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,Amount,Price,OrderType")] Order order)
        {
            if (ModelState.IsValid)
            {
                order.UserName = User.Identity.Name;
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction("ShowOrders", "Orders");
            }
            return View(order);
        }
       
    }
}
