using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace CleanJson.Web.Controllers;

/// <summary>
/// Provides a static JSON payload for testing without relying on the external Coderbyte service.
/// </summary>
[ApiController]
[Route("api/test-json")]
public sealed class TestJsonController : ControllerBase
{
    /// <summary>
    /// Returns sample JSON data similar to the Coderbyte challenge.
    /// </summary>
    [HttpGet]
    [Produces("application/json")]
    public IActionResult Get()
    {
        var payload = new JObject
        {
            ["name"] = "Robert",
            ["age"] = 45,
            ["children"] = new JArray("Sara", "Alex", "Jack"),
            ["favMovie"] = "N/A",
            ["favColor"] = "-",
            ["education"] = new JObject
            {
                ["highschool"] = "",
                ["college"] = "Yale"
            }
        };

        return Ok(payload);
    }
}
