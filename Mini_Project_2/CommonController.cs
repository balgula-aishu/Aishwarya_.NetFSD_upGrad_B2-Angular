using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using UVEMS.DAL.Repository;
using UVEMS.DAL.Models;

namespace UVEMS.AppUI.Controllers
{
    public class CommonController : Controller
    {
        private readonly UserService _userService;
        private readonly EventService _eventService;
        private readonly ParticipantService _participantService;

        public CommonController(UserService userService, EventService eventService, ParticipantService participantService)
        {
            _userService = userService;
            _eventService = eventService;
            _participantService = participantService;
        }

        // HOME PAGE (FIXED)
        public async Task<IActionResult> Home()
        {
            var events = await _eventService.GetAllEvents(); // ✅ correct service
            return View(events);
        }

        // ADMIN LOGIN
        [HttpGet]
        public IActionResult AdminLogin() => View();

        [HttpPost]
        public async Task<IActionResult> AdminLogin(string email, string password)
        {
            var user = await _userService.Login(email, password);

            if (user != null && user.Role == "Admin")
            {
                HttpContext.Session.SetString("UserEmail", user.EmailId);
                HttpContext.Session.SetString("Role", user.Role);
                return RedirectToAction("Dashboard", "Admin");
            }

            ViewBag.Error = "Invalid Admin Credentials";
            return View();
        }

        // PARTICIPANT LOGIN
        [HttpGet]
        public IActionResult ParticipantLogin() => View();

        [HttpPost]
        public async Task<IActionResult> ParticipantLogin(string email, string password)
        {
            var user = await _userService.Login(email, password);

            if (user != null && user.Role == "Participant")
            {
                HttpContext.Session.SetString("UserEmail", user.EmailId);
                HttpContext.Session.SetString("Role", user.Role);

                // ✅ NEW: HANDLE EVENT REGISTRATION AFTER LOGIN
                var pendingEventId = HttpContext.Session.GetInt32("PendingEventId");

                if (pendingEventId != null)
                {
                    var data = new ParticipantEventDetails
                    {
                        EventId = pendingEventId.Value,
                        ParticipantEmailId = user.EmailId
                    };

                    // 🔥 CALL SERVICE TO SAVE
                    await _participantService.RegisterEvent(data);

                    // REMOVE AFTER USE
                    HttpContext.Session.Remove("PendingEventId");

                    return RedirectToAction("MyEvents", "Participant");
                }

                return RedirectToAction("Dashboard", "Participant");
            }

            ViewBag.Error = "Invalid Credentials";
            return View();
        }

        // REGISTER (NO CHANGE LOGIC)
        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(UserInfo user)
        {
            user.Role = "Participant";

            var existingUser = await _userService.Login(user.EmailId, user.Password);

            if (existingUser != null)
            {
                ViewBag.Error = "User already registered. Please login.";
                return View();
            }

            await _userService.Register(user);
            return RedirectToAction("ParticipantLogin");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // clear login session
            return RedirectToAction("Home","Common");
        }
        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(string name, string email, string message)
        {
            // You can later add email sending logic here
            ViewBag.Success = "Your message has been sent successfully!";
            return View();
        }
        [HttpGet]
        public IActionResult About()
        {
            return View();
        }

    }
}
