﻿using eShop.Data;
using eShop.Data.Services;
using eShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace eShop.Controllers
{
	[Authorize(Roles = "Admin")]
	public class CinemasController : Controller
    {
        private readonly ICinemasService _service;

        public CinemasController(ICinemasService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allCinemas = await _service.GetAllAsync();
            return View(allCinemas);
        }

        //GET: Cinemas/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")]Cinema cinema)
        {
            if(ModelState.IsValid) return View(cinema);

            await _service.AddAsync(cinema);
            return RedirectToAction(nameof(Index));
        }

        //GET: Cinemas/Details/Id
        public async Task<IActionResult> Details(int id)
        {
            var cinemaDetails = await _service.GetByIdAsync(id);
            if (cinemaDetails == null) return View("Not found");
            return View(cinemaDetails);
        }

		//GET: Cinema/Edit/Id
		public async Task<IActionResult> Edit(int id)
		{
			var cinemaDetails = await _service.GetByIdAsync(id);
			if (cinemaDetails == null) return View("Not found");
			return View(cinemaDetails);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, [Bind("Id,Logo,Name,Description")] Cinema cinema)
		{
			if (ModelState.IsValid) return View(cinema);
			await _service.UpdateAsync(id, cinema);
			return RedirectToAction(nameof(Index));
		}

		//GET: Cinema/Delete/Id
		public async Task<IActionResult> Delete(int id)
		{
			var cinemaDetails = await _service.GetByIdAsync(id);
			if (cinemaDetails == null) return View("Not found");
			return View(cinemaDetails);
		}

		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> DeleteConfirm(int id)
		{
			var cinemaDetails = await _service.GetByIdAsync(id);
			if (cinemaDetails == null) return View("Not found");

			await _service.DeleteAsync(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
