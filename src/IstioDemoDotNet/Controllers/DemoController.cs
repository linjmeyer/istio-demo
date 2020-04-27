using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace IstioDemoDotNet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DemoController : ControllerBase
    {
        private readonly ILogger<DemoController> _logger;
        private readonly DemoEnvironment _demoEnvironment;
        
        public DemoController(ILogger<DemoController> logger, DemoEnvironment demoEnvironment)
        {
            _logger = logger;
            _demoEnvironment = demoEnvironment;
        }

        [HttpGet]
        public DemoEnvironment Get()
        {
            MakeSomeLogs();
            return _demoEnvironment;
        }

        private void MakeSomeLogs()
        {
            for (var i = 0; i < 5; i++)
            {
                _logger.LogInformation("Spinnaker is great!");
                _logger.LogInformation("Istio is awesome!");
            }
        }
    }
}
