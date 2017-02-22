using CarPool.Db;
using CarPool.Db.Entities;
using CarPool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarPool.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            using (CpDbContext db = new CpDbContext())
            {
                IndexVModel indexVm = new IndexVModel();
                db.Messages.AsNoTracking()
                    .Where(t => t.MessageType == MessageType.Passenger)
                    .Take(5)
                    .ToList()
                    .ForEach(t=>indexVm.CarMessages.Add(t.ToVModel()));
                db.Messages.AsNoTracking()
                    .Where(t => t.MessageType == MessageType.CarOwner)
                    .Take(5)
                    .ToList()
                    .ForEach(t => indexVm.PassengerMessages.Add(t.ToVModel()));
                return View(indexVm);
            }
                
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Publish()
        {
            return View();
        }

        public ActionResult PublishMessage(MessageVModel msgVm)
        {
            using(CpDbContext db = new CpDbContext())
            {
                Message msg = new Message() {
                    Id = Guid.NewGuid().ToString(),
                    StartTime= msgVm.StartTime,
                    Description = msgVm.Description,
                    StartName = msgVm.StartName,
                    EndName = msgVm.EndName,
                    SeatCount = msgVm.SeatCount,
                    Contact = msgVm.Contact,
                    Price = msgVm.Price,
                    MessageType = (MessageType)msgVm.MessageType,
                    Phone = msgVm.Phone
                };
                db.Messages.Add(msg);
                db.SaveChanges();
                return RedirectToAction("Index");
            } 
        }

        public ActionResult LoadMessage(int page,int rows,int msgType)
        {
            using (CpDbContext db = new CpDbContext())
            {
                List<MessageVModel> msgs = new List<MessageVModel>();
                db.Messages.AsNoTracking()
                    .Where(t => t.MessageType == (MessageType)msgType)
                    .OrderBy(t=>t.StartTime)
                    .Skip((page - 1) * rows)
                    .Take(rows)
                    .ToList()
                    .ForEach(t => msgs.Add(t.ToVModel()));
                return PartialView("~/Views/PartialViews/_MessageList.cshtml", msgs);
            }
                
        }
        
    }
}