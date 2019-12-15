using System;
using LordoftheRings.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LordoftheRings.Controllers
{
    public class RaceController : Controller
    {
        private readonly IRaceRepository repo;

        public RaceController(IRaceRepository repo)
        {
            this.repo = repo;
        }

        // GET: Race
        public IActionResult Index()
        {
            return View(repo.Get());
        }

        // GET: Race/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var race = repo.Get((int)id);
            if (race == null)
            {
                return NotFound();
            }

            return View(race);
        }

        // GET: Race/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Race/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("RaceId,Name,Description")] Race race)
        {
            if (ModelState.IsValid)
            {
                repo.Save(race);

                return RedirectToAction(nameof(Index));
            }
            return View(race);
        }

        // GET: Race/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var race = repo.Get((int)id);
            if (race == null)
            {
                return NotFound();
            }
            return View(race);
        }

        // POST: Race/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("RaceId,Name,Description")] Race race)
        {
            if (id != race.RaceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    repo.Save(race);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RaceExist(race.RaceId))
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
            return View(race);
        }

        // GET: Race/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var race = repo.Get((int)id);
            if (race == null)
            {
                return NotFound();
            }

            return View(race);
        }

        // POST: Race/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            repo.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        private bool RaceExist(int id)
        {
            // I did this so we could unit test. TODO: Fix this..
            return false;
        }
    }
}
