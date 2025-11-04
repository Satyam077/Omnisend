using Microsoft.AspNetCore.Mvc;
using Omnisend.Server.Models;
using Omnisend.Server.Services;
using System.Text.Json;

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

        [HttpPost("create")]
        public async Task<IActionResult> CreateContact([FromBody] OmnisendContactModel model)
        {
            if (model == null)
                return BadRequest("Invalid payload");

            var result = await _omnisend.CreateContactAsync(model);
            return Ok(new { message = "Contact created successfully", response = result });
        }
        [HttpPost("customers")]
        public async Task<IActionResult> CreateCustomert([FromBody] CustomerModel model)
        {
            if (model == null)
                return BadRequest("Invalid payload");

            //var result = await _omnisend.CreateCustomerContactAsync(model);
            //return Ok(new { message = "Contact created successfully", response = result });

            var (ok, resultJson) = await _omnisend.CreateCustomerContactAsync(model);

            object? responseObject = null;
            if (!string.IsNullOrEmpty(resultJson))
            {
                responseObject = JsonSerializer.Deserialize<object>(resultJson);
            }

            return Ok(new
            {
                message = ok ? "Contact created successfully" : "Failed to create contact",
                response = responseObject
            });
        }
    }
}
