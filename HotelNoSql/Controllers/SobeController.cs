using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using static HotelNoSql.DbConfig.DbConfig;
using MongoDB.Bson;
using System.Text.Json;
using MongoDB.Driver;

namespace HotelNoSql.Controllers
{
    public class SobeController : Controller
    {

        // GET: SobeController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SobeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SobeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SobeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: SobeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SobeController/Edit/5
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

        // GET: SobeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SobeController/Delete/5
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
