using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MosadMVC.Models;
using Newtonsoft.Json;


namespace MosadMVC.Controllers
{
    public class taskManagementController : Controller
    {
        private readonly HttpClient _httpClient;
        public taskManagementController()
        {
            _httpClient = new HttpClient();
        }

        // הצגת כל המשימות להצעה
        public async Task<IActionResult> Index()
        {
            var responseString = await _httpClient.GetStringAsync("http://localhost:5094/missions/GetOptions");
            List<MissionsMVC> missionsMVCs = JsonConvert.DeserializeObject<List<MissionsMVC>>(responseString);

            return View(missionsMVCs);
        }

        // הצגת משימה ספציפית
        public async Task<IActionResult> Details(int id)
        {
            var responseString = await _httpClient.GetStringAsync($"http://localhost:5094/missions/{id}");
            Missoion missoion = JsonConvert.DeserializeObject<Missoion>(responseString);

            return View(missoion);
        }


        // ציוות משימה בפועל
        public async Task<IActionResult> connect(int id)
        {
            _httpClient.PutAsJsonAsync($"http://localhost:5094/missions/{id}", "{ “status”: “assigned”}");


            return RedirectToAction("Index");
        }
    }
}
