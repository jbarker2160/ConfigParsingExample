using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Configuration;

namespace ConfigParsingExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConfigController : ControllerBase
    { 
        private readonly ILogger<ConfigController> _logger;

        public ConfigController(ILogger<ConfigController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetConfig")]
        public string Get()
        {
            ILoggerFactory loggerFactory = new LoggerFactory();

            ConfigParsingExample.Common.Config config = new ConfigParsingExample.Common.Config(loggerFactory);

            string configJSON = string.Empty;

            configJSON = @"{ ";
            configJSON += @"""host"":""" + config.host + @""", ";
            configJSON += @"""server_id"":" + config.serverId + @", ";
            configJSON += @"""server_load_alarm"":" + config.serverLoadAlarm + @", ";
            configJSON += @"""user"":""" + config.user + @""", ";
            configJSON += @"""verbose"":" + config.verbose.ToString().ToLower() + @", ";
            configJSON += @"""test_mode"":" + config.testMode.ToString().ToLower() + @", ";
            configJSON += @"""debug_mode"":" + config.debugMode.ToString().ToLower() + @", ";
            configJSON += @"""log_file_path"":""" + config.logFilePath + @""", ";
            configJSON += @"""send_notifications"":" + config.sendNotifications.ToString().ToLower();
            configJSON += @" }";

            return configJSON;
        }
    }
}