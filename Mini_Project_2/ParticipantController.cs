using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using UVEMS.DAL.Repository;
using UVEMS.DAL.Models;

namespace UVEMS.AppUI.Controllers
{
    public class ParticipantController : Controller
    {
        private readonly ParticipantService _participantService;
        private readonly SessionService _sessionService;

        public ParticipantController(
            EventService eventService,
            ParticipantService participantService,
            SessionService sessionService)
        {
            _participantService = participantService;
            _sessionService = sessionService;
        }

        private bool IsLoggedIn()
        {
            return HttpContext.Session.GetString("UserEmail") != null;
        }

        // ================= EVENTS =================
        public async Task<IActionResult> EventList()
        {
            var events = await _participantService.GetAllEvents();
            return View(events);
        }

        // ================= SESSIONS =================
        public async Task<IActionResult> Sessions(int eventId)
        {
            if (eventId <= 0)
                return RedirectToAction("EventList");
            var sessions = await _sessionService.GetSessionsByEvent(eventId);
            ViewBag.EventId = eventId;
            return View(sessions);
        }

        // ================= JOIN EVENT =================
        public IActionResult Register(int eventId)
        {
            HttpContext.Session.SetInt32("PendingEventId", eventId);
            return RedirectToAction("ParticipantLogin", "Common");
        }

        // ================= DASHBOARD =================
        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("UserEmail")==null)
                return RedirectToAction("ParticipantLogin", "Common");

            return View();
        }

        // ================= MY EVENTS =================
        public async Task<IActionResult> MyEvents()
        {
            //if (!IsLoggedIn())
            //    return RedirectToAction("ParticipantLogin", "Common");

            var email = HttpContext.Session.GetString("UserEmail");
            if (string.IsNullOrEmpty(email))
                return RedirectToAction("ParticipantLogin", "Common");

            var data = await _participantService.GetUserEvents(email);

            return View(data);
        }
    }
}