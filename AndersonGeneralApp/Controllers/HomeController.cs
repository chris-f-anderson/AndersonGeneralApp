using AndersonGeneralApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace AndersonGeneralApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            RoomRepository repo = new RoomRepository();
            List<Room> room = repo.GetAllRooms();
            
            return View(room);
        }
        public IActionResult AvailableRooms()
        {
            RoomRepository repo = new RoomRepository();
            List<Room> room = repo.GetAvailableRooms();

            return View(room);
        }
        public IActionResult DirtyRooms()
        {
            RoomRepository repo = new RoomRepository();
            List<Room> room = repo.GetDirtyRooms();

            return View(room);
        }
        public IActionResult UpdateRoom(Room RoomToUpdate)
        {
            RoomRepository repo = new RoomRepository();
            repo.UpdateRoom(RoomToUpdate);

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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
