using Microsoft.AspNetCore.Mvc;
using OpenAI.Chat;

namespace KairaWebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetOutfitSuggestion(string season, string occasion)
        {
            try
            {
                var apiKey = _configuration["OpenAI:ApiKey"];
                var client = new ChatClient("gpt-4o-mini", apiKey);

                var prompt = $@"Provide a short outfit suggestion for {season} season and {occasion} occasion in English. 

Write each item on a separate line in the following format:
Top: [suggestion]
Bottom: [suggestion]
Shoes: [suggestion]
Accessories: [suggestion]

Maximum 100 words, write in a simple and clear language.";

                var response = await client.CompleteChatAsync(prompt);
                var suggestion = response.Value.Content[0].Text;

                return Json(new { success = true, suggestion });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }
    }
}
