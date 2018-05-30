using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SammysAuto.Data;
using SammysAuto.Models;

namespace SammysAuto.Controllers
{
    public class ServiceTypesController : Controller
    {
        
        //public delegate void Message(string s);

        private readonly ApplicationDbContext _db;
        //Declarar Delegate
        public delegate void Imprimir();

        public static void WriteToScreen()
        {
            Console.WriteLine("Hello World");
        }

        public ServiceTypesController(ApplicationDbContext db)
        {
            _db = db;
        }
        //GET: ServiceTypes
        public IActionResult Index()
        {
            return View(_db.ServiceTypes.ToList());
        }
        //GET: ServiceTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        //Details: ServiceTypes/Details/1
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var serviceType = await _db.ServiceTypes.SingleOrDefaultAsync(m => m.Id == id);
            if (serviceType == null) return NotFound();
            return View(serviceType);
        }

        //Edit: ServiceTypes/Edit/1
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var serviceType = await _db.ServiceTypes.SingleOrDefaultAsync(m => m.Id == id);
            if (serviceType == null) return NotFound();
        
            return View(serviceType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ServiceType serviceType)
        {
            if (id != serviceType.Id) return NotFound();
            if (ModelState.IsValid)
            {
                _db.Update(serviceType);
                await _db.SaveChangesAsync();
                TempData["Message"] = "Service Type edit Successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(serviceType);
        }

        //Delete: ServiceTypes/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            
            var serviceType = await _db.ServiceTypes.FindAsync(id);            
            _db.ServiceTypes.Remove(serviceType);
            await _db.SaveChangesAsync();
            TempData["Message"] = "Service Type removed Successfully";
            var escrever = new Imprimir(WriteToScreen);
            escrever();
           
            return RedirectToAction(nameof(Index));
        }
        //POST: ServiceTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServiceType serviceType)
        {
            if (ModelState.IsValid)
            {
                _db.Add(serviceType);
                await _db.SaveChangesAsync();
                TempData["Message"] = "Service Type created Successfully";
                return RedirectToAction(nameof(Index));

            }
            return View(serviceType);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing) _db.Dispose();
            
        }
    }
}