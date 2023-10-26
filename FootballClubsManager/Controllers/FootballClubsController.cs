using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootballClubsManager.Infrastructure;
using FootballClubsManager.Infrastructure.Context;
using FootballClubsManager.Infrastructure.Repositories;
using FootballClubsManager.Services;
using FootballClubsManager.Models;

namespace FootballClubsManager.Controllers
{
    public class FootballClubsController : Controller
    {
        private readonly IFootballClubsService _footballClubService;

        public FootballClubsController(IFootballClubsService footballClubService)
        {
            this._footballClubService = footballClubService;
        }

        // GET: FootballClubControllercs
        public ActionResult Index()
        {
            return View(_footballClubService.GetClubs());
        }

        // GET: FootballClubControllercs/Details/5
        public ActionResult Details()
        {
            return Ok(_footballClubService.GetClubs())
        }

        // GET: FootballClubControllercs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FootballClubControllercs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] FootballClub club)
        {
            try
            {
                _footballClubService.InsertClub(club);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FootballClubControllercs/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FootballClubControllercs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FootballClubControllercs/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FootballClubControllercs/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
