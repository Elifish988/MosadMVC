using Microsoft.AspNetCore.Mvc;
using MosadMVC.Models;
using Newtonsoft.Json;
using NuGet.Common;
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

        public static string token;

        public async Task<IActionResult> Login()
        {
            var a = await _httpClient.PostAsJsonAsync($"http://localhost:5094/Login", new { Id = "MVCServer" });

            a.EnsureSuccessStatusCode();

            var responseContent = await a.Content.ReadAsStringAsync();

            MosadMVC.Models.Token Token = JsonConvert.DeserializeObject<MosadMVC.Models.Token>(responseContent);
            token = Token.token;

            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GeneralView()
        {
            var responseString = await _httpClient.GetStringAsync("http://localhost:5094/missions/GeneralView");
            GeneralView generalView = JsonConvert.DeserializeObject<GeneralView>(responseString);
            return View(generalView);
        }

        public async Task<IActionResult> AgentStatus()
        {
            var responseString = await _httpClient.GetStringAsync("http://localhost:5094/missions/AgentStatus");
            List<AgentStatusMVC> agentStatusMVCs = JsonConvert.DeserializeObject<List<AgentStatusMVC>>(responseString);
            return View(agentStatusMVCs);
        }

        public async Task<IActionResult> GetMissionsByID(int id)
        {
            var responseString = await _httpClient.GetStringAsync($"http://localhost:5094/missions/{id}");
            Missoion missoion = JsonConvert.DeserializeObject<Missoion>(responseString);

            return View(missoion);
        }

        public async Task<IActionResult> TargetStatus()
        {
            var responseString = await _httpClient.GetStringAsync("http://localhost:5094/missions/TargetStatus");
            List<TargetStatusMVC> targetStatusMVCs = JsonConvert.DeserializeObject<List<TargetStatusMVC>>(responseString);
            return View(targetStatusMVCs);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
