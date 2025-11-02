using Microsoft.AspNetCore.Mvc;
using Omnisend.Server.Models;
using Omnisend.Server.Services;

namespace Omnisend.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CheckoutController : ControllerBase
    {
        private readonly OmnisendService _omnisend;
        private readonly ILogger<CheckoutController> _logger;

        public CheckoutController(OmnisendService omnisend, ILogger<CheckoutController> logger)
        {
            _omnisend = omnisend;
            _logger = logger;
        }

        [HttpPost("started-checkout")]
        public async Task<IActionResult> StartedCheckout([FromBody] StartedCheckoutEventModel model)
        {
            if (model == null)
                return BadRequest("Invalid payload");

            var (ok, msg) = await _omnisend.SendStartedCheckoutAsync(model);
            if (!ok)
            {
                _logger.LogWarning("Omnisend started-checkout failed: {msg}", msg);
                return StatusCode(500, new { success = false, message = msg });
            }

            return Ok(new { success = true, message = "Event sent to Omnisend successfully." });
        }
    }
}
