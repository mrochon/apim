using Microsoft.AspNetCore.Mvc;
using Reflector.Models;
using System.Diagnostics;
using System.Reflection.PortableExecutable;

namespace Reflector.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [HttpPost]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("=============New request===================");
            //await HttpResponseWritingExtensions.WriteAsync(HttpContext.Response, $"<ul>");
            foreach (var h in Request.Headers)
            {
                _logger.LogInformation($"{h.Key} ---> {h.Value}");
            }
            var rdr = new StreamReader(Request.Body);
            var body = await rdr.ReadToEndAsync();
            _logger.LogInformation($"BODY: {body}");
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