using Microsoft.AspNetCore.Mvc;
using MosadMVC.Models;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;

namespace MosadMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;
        public HomeController()
        {
            _httpClient = new HttpClient();
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GeneralView()
        {
            var responseString = await _httpClient.GetStringAsync("http://localhost:5094/api/missions/GeneralView");
            GeneralView generalView = JsonConvert.DeserializeObject<GeneralView>(responseString);
            return View(generalView);
        }

        public async Task<IActionResult> AgentStatus()
        {
            var responseString = await _httpClient.GetStringAsync("http://localhost:5094/api/missions/AgentStatus");
            List<AgentStatusMVC> agentStatusMVCs = JsonConvert.DeserializeObject<List<AgentStatusMVC>>(responseString);
            return View(agentStatusMVCs);
        }

        public async Task<IActionResult> GetMissionsByID(int id)
        {
            var responseString = await _httpClient.GetStringAsync($"http://localhost:5094/api/missions/{id}");
            Missoion missoion = JsonConvert.DeserializeObject<Missoion>(responseString);

            return View(missoion);
        }

        public IActionResult TargetStatus()
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
