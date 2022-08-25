using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AirLines.Data;
using AirLines.Models;
using AirLines.Services;
using AirLines.customMiddleware;

namespace AirLines.Controllers
{
   // [CustomAuthorize("Operator")]
    public class OperatorController : Controller
    {
        private readonly DataServisce _context;
        [CustomAuthorize("Operator")]
        public OperatorController(DataServisce context)
        {
            _context = context;
        }

        // GET: Operator
        [CustomAuthorize("Operator")]
        public IActionResult Index()
        {
            ViewData["UserName"] = HttpContext.Session.GetString("Name");
            return  View(_context.GetAirlines());
                        
        }


        //// GET: Operator/Create
        public IActionResult Create()
        {
            ViewData["UserName"] = HttpContext.Session.GetString("Name");
            return View();
        }
        [CustomAuthorize("Operator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,FromCity,ToCity,Fare")] AirlineViewModel airlineViewModel)
        {
            if (ModelState.IsValid)
            {
               
                _context.AddAirLines(airlineViewModel);
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserName"] = HttpContext.Session.GetString("Name");
            return View(airlineViewModel);
        }

        // GET: Operator/Edit/5
        [CustomAuthorize("Operator")]
        public IActionResult Edit(int? id)
        {
            if (id == null || _context.GetAirlines == null)
            {
                return NotFound();
            }

            var airlineViewModel = _context.GetById(id);
            if (airlineViewModel == null)
            {
                return NotFound();
            }
            ViewData["UserName"] = HttpContext.Session.GetString("Name");
            return View(airlineViewModel);
        }
        [CustomAuthorize("Operator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("Id,Name,FromCity,ToCity,Fare")] AirlineViewModel airlineViewModel)
        {
            
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(airlineViewModel);
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    return View();
                }
                ViewData["UserName"] = HttpContext.Session.GetString("Name");
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserName"] = HttpContext.Session.GetString("Name");
            return View(airlineViewModel);
        }

       

       
    }
}
