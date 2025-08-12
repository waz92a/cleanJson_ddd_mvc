using CleanJson.Application.UseCases;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CleanJson.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class CleanController : ControllerBase
{
    private readonly CleanRemoteJsonHandler _handler;
    private readonly ILogger<CleanController> _logger;

    public CleanController(CleanRemoteJsonHandler handler, ILogger<CleanController> logger)
    {
        _handler = handler;
        _logger = logger;
    }

    /// <summary>
    /// Fetches the remote JSON and returns a cleaned object with invalid values removed.
    /// </summary>
    /// <remarks>
    /// Rules: Remove object properties equal to "", "-", or "N/A". Remove those string items from arrays.
    /// </remarks>
    /// <response code="200">The cleaned JSON document.</response>
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(CancellationToken ct)
    {
        JToken cleaned = await _handler.HandleAsync(ct);

        // Log the modified object as a compact string (like the console log requirement)
        string asString = JsonConvert.SerializeObject(cleaned, Formatting.None);
        _logger.LogInformation("Cleaned JSON: {Json}", asString);

        return Ok(cleaned); // Returned as JSON
    }
}
