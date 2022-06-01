using HotelNoSql.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using static HotelNoSql.DbConfig.DbConfig;
using MongoDB.Bson;
using System.Text.Json;
using MongoDB.Driver;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace HotelNoSql.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var collection = connectDB();

            var allRoms = collection.Find(x => x.ime.Length > 1 ).ToList();

             HttpClient client = new HttpClient();


            ViewData["collection"] = allRoms;
            return View();
        }

        public IActionResult RoomPage(string id)
        {
           // Console.Write(id);
            var collection = connectDB();
            var singleRoom = collection.Find(x => x.id == id).ToList();
            ViewData["collection"] = singleRoom;
            return View();
        }

        public IActionResult NewRoom(Soba soba)
        {
            var collection = connectDB();
            collection.InsertOne(soba);
            return RedirectToAction(nameof(Index));
        }


        public IActionResult DeleteRoom(string id)
        {
            // Console.Write(id);
            try
            {
                var collection = connectDB();
                var singleRoom = collection.FindOneAndDelete(x => x.id == id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }
         
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateRoom(Soba soba, IFormCollection form)
        {
            Console.WriteLine(form["hrana"]);
       
            try
            {

                var newRoom = new Soba();
                newRoom.ime = form["ime"];
                newRoom.brojKreveta = Int32.Parse(form["brojKrevet"]);
                newRoom.opis = form["opis"];
                if (form["hrana"] == "on")
                {
                newRoom.Hrana = true;

                }
                else
                {
                    newRoom.Hrana = false;
                }

                if (form["minibar"] == "on")
                {
                    newRoom.miniBar = true;

                }
                else
                {
                    newRoom.miniBar = false;
                }
                newRoom.cena = float.Parse(form["cena"]);
                var collection = connectDB();
                var singleRoom = collection.FindOneAndDelete(x => x.id == form["id"]);
                collection.InsertOne(newRoom);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                return RedirectToAction(nameof(Index));
            }

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
