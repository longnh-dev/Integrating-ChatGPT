using Microsoft.AspNetCore.Mvc;
using OpenAI_API;
using OpenAI_API.Completions;

namespace OpenAI_ChatGPT_API.Controllers
{
    public class OpenAiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        //LongNH
        [HttpPost]
        [Route("OpenAPI")]
        public IActionResult GetResult([FromBody] string prompt)
        {
            string apiKey = "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";
            string answer = string.Empty;
            var openai = new OpenAIAPI(apiKey);

            CompletionRequest completion = new CompletionRequest();
            completion.Prompt = prompt;

            completion.Model = OpenAI_API.Models.Model.DavinciText;
            completion.MaxTokens = 100;
            var result = openai.Completions.CreateCompletionsAsync(completion);

            if (result != null)
            {
                foreach (var item in result.Result.Completions)
                {
                    answer = item.Text;
                }
                return Ok(answer);
            }
            else
            {
                return BadRequest("Something wrong");
            }
        }
    }
}
