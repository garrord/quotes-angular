using Data.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace web_application_api.Controllers
{
    [ApiController]
    [Route("api/quotes")]
    public class QuoteController : ControllerBase
    {
        private readonly IQuoteManager _quoteManager;

        public QuoteController(IQuoteManager quoteManager)
        {
            _quoteManager = quoteManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var quotes = await _quoteManager.Get();
            return new JsonResult(quotes);
        }

        [HttpGet("category")]
        public async Task<IActionResult> Get(string category)
        {
            var quotes = await _quoteManager.Get(category);
            return new JsonResult(quotes);
        }
    }
}