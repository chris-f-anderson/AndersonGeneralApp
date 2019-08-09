using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AndersonGeneralApp.Controllers;

namespace AndersonGeneralApp.Controllers
{
    public class RoomController : Controller
    {
        // GET: Room
        public ActionResult Index()
        {
            RoomRepository repo = new RoomRepository();
            List<Room> allRooms = repo.GetAllRooms();
            return View(allRooms);
        }
        public IActionResult ViewRoom(int id)
        {
            RoomRepository repo = new RoomRepository();
            Room room = repo.GetRoom(id);

            if (room == null)
            {
                return View("RoomNotFound");
            }

            return View("Room", room);
        }
        public IActionResult NewRoom()
        {
            return View();
        }

        public IActionResult Add(Room room)
        {
            RoomRepository repo = new RoomRepository();
            repo.AddRoomToDatabase(room);
            return RedirectToAction("Index", "Room");
        }

        public IActionResult UpdateRoom(int id)
        {
            RoomRepository repo = new RoomRepository();
            Room room = repo.GetRoom(id);
            return View(room);
        }
        public IActionResult Update(Room room)
        {
            RoomRepository repo = new RoomRepository();
            repo.UpdateRoom(room);
            return RedirectToAction("ViewRoom", "Room", new { id = room.Id });
        }
        public IActionResult Delete(int id)
        {
            RoomRepository repo = new RoomRepository();
            repo.DeleteRoomFromDatabase(id);
            return RedirectToAction("Index", "Room");
        }
    }
}