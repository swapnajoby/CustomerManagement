using CustomerManagement.DataAccessLayer;
using CustomerManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagement.Controllers
{
    public class CustomersController : Controller
    {
        private readonly CustomerDBContext _context;

        public CustomersController(CustomerDBContext context)
        {
            _context = context;
        }


        public ActionResult Index(string sortOrder)
        {           
            if (String.IsNullOrEmpty(sortOrder))
            {
               // ViewBag.showImage = 0;
                ViewBag.NameSortParm = "firstname_desc";
            }
            else
            {
                //ViewBag.showImage = 1;
                ViewBag.NameSortParm = "";
            }

            List<Customer> lstCustomer = new List<Customer>();
            lstCustomer = _context.Customers.ToList().OrderBy(s => s.FirstName).ToList();

            switch (sortOrder)
            {
                case "firstname_desc":
                    lstCustomer = lstCustomer.OrderByDescending(s => s.FirstName).ToList(); 
                    ViewBag.NameSortParm = "firstname_asc";
                    break;
                case "firstname_asc":
                    lstCustomer = lstCustomer.OrderBy(s => s.FirstName).ToList();
                    ViewBag.NameSortParm = "firstname_desc";
                    break;
            }

           // var t = TimeZoneInfo.GetSystemTimeZones();
            //foreach (Customer obj in lstCustomer)
            //{
            //    obj.CreatedDate = obj.CreatedDate.ToLocalTime();
            //}

            //var timeUtc = DateTime.UtcNow;
            //var easternZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");// TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            //var today = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, easternZone);

            // return View(_context.Customers.ToList());
            return View(lstCustomer);
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,FirstName,LastName,DateofBirth,BusinessName,CreatedDate")] Customer customer)
        {
            customer.DateofBirth = customer.DateofBirth.ToUniversalTime();
            customer.CreatedDate = System.DateTime.UtcNow;

            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers/Edit/5
        //[Route("Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerId,FirstName,LastName,DateofBirth,BusinessName,CreatedDate")] Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (customer.CreatedDate == null || customer.CreatedDate == new DateTime())
                    {
                        var createdDate = (from data in _context.Customers
                                           where data.CustomerId == id
                                           select data.CreatedDate).FirstOrDefault();
                        customer.CreatedDate = createdDate;
                    }
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.CustomerId))
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
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.CustomerId == id);
        }
    }
}
