using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using UVEMS.DAL.Repository;
using UVEMS.DAL.Models;

namespace UVEMS.AppUI.Controllers
{
    public class AdminController : Controller
    {
        private readonly EventService _eventService;
        private readonly SpeakerService _speakerService;
        private readonly SessionService _sessionService;

        public AdminController(
            EventService eventService,
            SpeakerService speakerService,
            SessionService sessionService)
        {
            _eventService = eventService;
            _speakerService = speakerService;
            _sessionService = sessionService;
        }

        // ================= DASHBOARD =================
        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
                return RedirectToAction("AdminLogin", "Common");

            return View();
        }

        // ================= EVENTS =================
        public async Task<IActionResult> EventList()
        {
            var events = await _eventService.GetAllEvents();
            return View(events);
        }

        [HttpGet]
        public IActionResult AddEvent()
        {
            return View(new EventDetails());
        }

        [HttpPost]
        public async Task<IActionResult> AddEvent(EventDetails model)
        {
            if (ModelState.IsValid)
            {
                if (model.EventDate <= DateTime.Now)
                {
                    ViewBag.Error = "Event date must be future";
                    return View(model);
                }

                await _eventService.AddEvent(model);
                return RedirectToAction("EventList");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditEvent(int id)
        {
            return View(await _eventService.GetEventById(id));
        }

        [HttpPost]
        public async Task<IActionResult> EditEvent(EventDetails model)
        {
            await _eventService.UpdateEvent(model);
            return RedirectToAction("EventList");
        }

        public async Task<IActionResult> DeleteEvent(int id)
        {
            await _eventService.DeleteEvent(id);
            return RedirectToAction("EventList");
        }

        // ================= SPEAKERS =================
        public async Task<IActionResult> SpeakerList()
        {
            return View(await _speakerService.GetAllSpeakers());
        }

        [HttpGet]
        public IActionResult AddSpeaker()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSpeaker(SpeakerDetails model)
        {
            if (ModelState.IsValid)
            {
                await _speakerService.AddSpeaker(model);
                return RedirectToAction("SpeakerList");
            }
            return View(model);
        }

        public async Task<IActionResult> DeleteSpeaker(int id)
        {
            await _speakerService.DeleteSpeaker(id);
            return RedirectToAction("SpeakerList");
        }

        // ================= SESSION FLOW =================

        // Step 1: Select Event
        public async Task<IActionResult> SessionEvents()
        {
            return View(await _eventService.GetAllEvents());
        }

        // Step 2: View Sessions of Event
        public async Task<IActionResult> SessionList(int eventId)
        {
            var sessions = await _sessionService.GetSessionsByEvent(eventId);
            ViewBag.EventId = eventId;
            return View(sessions);
        }

        // Step 3: Add Session
        [HttpGet]
        public IActionResult AddSession(int eventId)
        {
            return View(new SessionInfo
            {
                EventId = eventId,
                SessionStart = DateTime.Now,
                SessionEnd = DateTime.Now.AddHours(1)
            });
        }

        [HttpPost]
        public async Task<IActionResult> AddSession(SessionInfo model)
        {
            if (model.SessionStart >= model.SessionEnd)
            {
                ViewBag.Error = "Start must be before End";
                return View(model);
            }

            await _sessionService.AddSession(model);

            return RedirectToAction("SessionList", new { eventId = model.EventId });
        }

        // Step 4: Assign Speaker
        [HttpGet]
        public async Task<IActionResult> AssignSpeaker(int sessionId)
        {
            ViewBag.Speakers = await _speakerService.GetAllSpeakers();

            return View(new SessionInfo
            {
                SessionId = sessionId
            });
        }

        [HttpPost]
        public async Task<IActionResult> AssignSpeaker(SessionInfo model)
        {
            if (model.SpeakerId == null)
            {
                ViewBag.Speakers = await _speakerService.GetAllSpeakers();
                ViewBag.Error = "Select Speaker";
                return View(model);
            }

            await _sessionService.AssignSpeaker(model.SessionId, model.SpeakerId.Value);

            return RedirectToAction("SessionEvents");
        }
    }
}