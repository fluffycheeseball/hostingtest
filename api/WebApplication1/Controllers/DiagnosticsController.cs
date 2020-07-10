using Microsoft.AspNetCore.Mvc;

using Serilog;

using Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    public class DiagnosticsController : ControllerBase
    {
        // We can use the nice Serilog type format instead of Microsoft ILogger<someclass> here
        // Serilog will support the ILogger<someclass> as well if you must
        private readonly ILogger _logger;

        private readonly IDiagnosticsService _diagnosticsService;
        private readonly IProfileService _profileService;

        public DiagnosticsController(ILogger logger, IDiagnosticsService diagnosticsService, IProfileService profileService) {
            _logger = logger;
            _diagnosticsService = diagnosticsService;
            _profileService = profileService;
        }

        [HttpGet("[action]")]
        public ActionResult<string> Ping() {
            var t = _diagnosticsService.Ping();
            // These are just so I can see them in the Seq tool
            var Jude = "hey jude";
            var someint = 5;
            _logger.Error("Some error: {Jude}", Jude);
            _logger.Warning("Some warning: {SomeInt}", someint);

            _logger.Information("diagnostics controller log");
            return Ok("Pong");
        }
    }
}
