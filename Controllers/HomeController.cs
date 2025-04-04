using AppWhatsAppChatGPT.Models;
using AppWhatsAppChatGPT.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace AppWhatsAppChatGPT.Controllers
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
            return View();
        }

        public IActionResult MyTest()
        {
            return View();
        }
        [HttpPost]
        public IActionResult MyTest(string name)
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(UserMessage model)
        {
            var path = "App_Data/messages.csv";
            var csvLine = $"{model.Id},{model.Name},{model.Phone},{model.Message},{model.SentDate}";
            System.IO.File.AppendAllLines(path, new[] { csvLine });

            string message = $"👋 Hello {model.Name}, thank you for your message:\n\n\"{model.Message}\"\n\nWe'll get back to you shortly!";
            WhatsAppService.SendWhatsAppMessage(model.Phone, message);

            return View("Thanks");
        }


        public IActionResult Thanks()
        {
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
