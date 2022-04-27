using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging.Console;

namespace ConfigParsingExample.Common
{
    /// <summary>
    /// Config class implemented with IConfig interface.
    /// </summary>
    public class Config : ConfigParsingExample.Interfaces.IConfig
    {
        private readonly ILogger _logger;

        string _host = string.Empty;
        int _serverId = 0;
        float _serverLoadAlarm = 0;
        string _user = string.Empty;
        bool _verbose = false;
        bool _testMode = false;
        bool _debugMode = false;
        string _logFilePath = string.Empty;
        bool _sendNotifications = false;
        bool _isInitialized = false;

        public string host
        {
            get
            { 
                if(!_isInitialized)
                {
                    throw new Exceptions.ConfigNotInitializedException("The configuration has not been loaded!");
                }
                return _host; 
            }
        }

        public int serverId
        {
            get
            {
                if (!_isInitialized)
                {
                    throw new Exceptions.ConfigNotInitializedException("The configuration has not been loaded!");
                }
                return _serverId;
            }
        }

        public float serverLoadAlarm
        {
            get
            {
                if (!_isInitialized)
                {
                    throw new Exceptions.ConfigNotInitializedException("The configuration has not been loaded!");
                }
                return _serverLoadAlarm;
            }
        }

        public string user
        {
            get
            {
                if (!_isInitialized)
                {
                    throw new Exceptions.ConfigNotInitializedException("The configuration has not been loaded!");
                }
                return _user;
            }
        }

        public bool verbose
        {
            get
            {
                if (!_isInitialized)
                {
                    throw new Exceptions.ConfigNotInitializedException("The configuration has not been loaded!");
                }
                return _verbose;
            }
        }
    

        public bool testMode
        {
            get
            {
                if (!_isInitialized)
                {
                    throw new Exceptions.ConfigNotInitializedException("The configuration has not been loaded!");
                }
                return _testMode;
            }
        }

        public bool debugMode
        {
            get
            {
                if (!_isInitialized)
                {
                    throw new Exceptions.ConfigNotInitializedException("The configuration has not been loaded!");
                }
                return _debugMode;
            }
        }

        public string logFilePath
        {
            get
            {
                if (!_isInitialized)
                {
                    throw new Exceptions.ConfigNotInitializedException("The configuration has not been loaded!");
                }
                return _logFilePath;
            }
        }

        public bool sendNotifications
        {
            get
            {
                if (!_isInitialized)
                {
                    throw new Exceptions.ConfigNotInitializedException("The configuration has not been loaded!");
                }
                return _sendNotifications;
            }
        }

        public Config(ILoggerFactory logger)
        {
            _logger = logger.CreateLogger(@"ConfigLogging");

            if (!_isInitialized)
            {
                InitializeConfig();
            }
        }

        private void InitializeConfig()
        {
            string[] _configFileLines = File.ReadAllLines(@"example.config");
            foreach (string line in _configFileLines)
            {
                switch (line[0].ToString())
                {
                    case "#":
                        _logger.LogInformation($"Config Comment Read: {line}");
                        Console.WriteLine($"Config Comment Read: {line}");
                        break;

                    default:
                        string param = line.Split('=')[0].Trim();
                        string value = line.Split('=')[1].Trim();

                        switch (param)
                        {
                            case "host":
                                _logger.LogInformation($"Config Parameter({param}) Value Read: {value}");
                                Console.WriteLine($"Config Parameter({param}) Value Read: {value}");
                                _host = value;

                                break;

                            case "server_id":
                                if (int.TryParse(value, out _serverId))
                                {
                                    _logger.LogInformation($"Config Parameter({param}) Value Read: {value}");
                                    Console.WriteLine($"Config Parameter({param}) Value Read: {value}");
                                }
                                else
                                {
                                    throw new Exceptions.ConfigNotInitializedException($"Value {value} not valid for parameter {param}.");
                                }
                                
                                break;

                            case "server_load_alarm":
                                if (float.TryParse(value, out _serverLoadAlarm))
                                {
                                    _logger.LogInformation($"Config Parameter({param}) Value Read: {value}");
                                    Console.WriteLine($"Config Parameter({param}) Value Read: {value}");
                                }
                                else
                                {
                                    throw new Exceptions.ConfigNotInitializedException($"Value {value} not valid for parameter {param}.");
                                }

                                break;

                            case "user":
                                _logger.LogInformation($"Config Parameter({param}) Value Read: {value}");
                                Console.WriteLine($"Config Parameter({param}) Value Read: {value}");
                                _user = value;

                                break;

                            case "verbose":
                                if (bool.TryParse(value, out _verbose))
                                {
                                    _logger.LogInformation($"Config Parameter({param}) Value Read: {value}");
                                    Console.WriteLine($"Config Parameter({param}) Value Read: {value}");
                                }
                                else
                                {
                                    switch (value)
                                    {
                                        case "yes":
                                            _verbose = true;

                                            _logger.LogInformation($"Config Parameter({param}) Value Read: {value}");
                                            Console.WriteLine($"Config Parameter({param}) Value Read: {value}");

                                            break;

                                        case "on":
                                            _verbose = true;

                                            _logger.LogInformation($"Config Parameter({param}) Value Read: {value}");
                                            Console.WriteLine($"Config Parameter({param}) Value Read: {value}");

                                            break;

                                        case "no":
                                            _verbose = false;

                                            _logger.LogInformation($"Config Parameter({param}) Value Read: {value}");
                                            Console.WriteLine($"Config Parameter({param}) Value Read: {value}");

                                            break;

                                        case "off":
                                            _verbose = false;

                                            _logger.LogInformation($"Config Parameter({param}) Value Read: {value}");
                                            Console.WriteLine($"Config Parameter({param}) Value Read: {value}");

                                            break;

                                        default:
                                            throw new Exceptions.ConfigNotInitializedException($"Value {value} not valid for parameter {param}.");
                                    }
                                }

                                break;

                            case "test_mode":
                                if (bool.TryParse(value, out _testMode))
                                {
                                    _logger.LogInformation($"Config Parameter({param}) Value Read: {value}");
                                    Console.WriteLine($"Config Parameter({param}) Value Read: {value}");
                                }
                                else
                                {
                                    switch (value)
                                    {
                                        case "yes":
                                            _verbose = true;

                                            _logger.LogInformation($"Config Parameter({param}) Value Read: {value}");
                                            Console.WriteLine($"Config Parameter({param}) Value Read: {value}");

                                            break;

                                        case "on":
                                            _verbose = true;

                                            _logger.LogInformation($"Config Parameter({param}) Value Read: {value}");
                                            Console.WriteLine($"Config Parameter({param}) Value Read: {value}");

                                            break;

                                        case "no":
                                            _verbose = false;

                                            _logger.LogInformation($"Config Parameter({param}) Value Read: {value}");
                                            Console.WriteLine($"Config Parameter({param}) Value Read: {value}");

                                            break;

                                        case "off":
                                            _verbose = false;

                                            _logger.LogInformation($"Config Parameter({param}) Value Read: {value}");
                                            Console.WriteLine($"Config Parameter({param}) Value Read: {value}");

                                            break;

                                        default:
                                            throw new Exceptions.ConfigNotInitializedException($"Value {value} not valid for parameter {param}.");
                                    }
                                }

                                break;

                            case "debug_mode":
                                if (bool.TryParse(value, out _debugMode))
                                {
                                    _logger.LogInformation($"Config Parameter({param}) Value Read: {value}");
                                    Console.WriteLine($"Config Parameter({param}) Value Read: {value}");
                                }
                                else
                                {
                                    switch (value)
                                    {
                                        case "yes":
                                            _verbose = true;

                                            _logger.LogInformation($"Config Parameter({param}) Value Read: {value}");
                                            Console.WriteLine($"Config Parameter({param}) Value Read: {value}");

                                            break;

                                        case "on":
                                            _verbose = true;

                                            _logger.LogInformation($"Config Parameter({param}) Value Read: {value}");
                                            Console.WriteLine($"Config Parameter({param}) Value Read: {value}");

                                            break;

                                        case "no":
                                            _verbose = false;

                                            _logger.LogInformation($"Config Parameter({param}) Value Read: {value}");
                                            Console.WriteLine($"Config Parameter({param}) Value Read: {value}");

                                            break;

                                        case "off":
                                            _verbose = false;

                                            _logger.LogInformation($"Config Parameter({param}) Value Read: {value}");
                                            Console.WriteLine($"Config Parameter({param}) Value Read: {value}");

                                            break;

                                        default:
                                            throw new Exceptions.ConfigNotInitializedException($"Value {value} not valid for parameter {param}.");
                                    }
                                }

                                break;

                            case "log_file_path":
                                FileInfo fileInfo = new FileInfo(value);

                                if (true /* value.IndexOfAny(Path.GetInvalidPathChars()) > -1 && fileInfo.Exists  Can only truly evaluate this in a prod-like system! */)
                                {
                                    _logger.LogInformation($"Config Parameter({param}) Value Read: {value}");
                                    _logFilePath = value;
                                }
                                else
                                {
                                    throw new Exceptions.ConfigNotInitializedException($"Value {value} not valid for parameter {param}.");
                                }

                                break;

                            case "send_notifications":
                                if (bool.TryParse(value, out _sendNotifications))
                                {
                                    _logger.LogInformation($"Config Parameter({param}) Value Read: {value}");
                                    Console.WriteLine($"Config Parameter({param}) Value Read: {value}");
                                }
                                else
                                {
                                    switch (value)
                                    {
                                        case "yes":
                                            _verbose = true;

                                            _logger.LogInformation($"Config Parameter({param}) Value Read: {value}");
                                            Console.WriteLine($"Config Parameter({param}) Value Read: {value}");

                                            break;

                                        case "on":
                                            _verbose = true;

                                            _logger.LogInformation($"Config Parameter({param}) Value Read: {value}");
                                            Console.WriteLine($"Config Parameter({param}) Value Read: {value}");

                                            break;

                                        case "no":
                                            _verbose = false;

                                            _logger.LogInformation($"Config Parameter({param}) Value Read: {value}");
                                            Console.WriteLine($"Config Parameter({param}) Value Read: {value}");

                                            break;

                                        case "off":
                                            _verbose = false;

                                            _logger.LogInformation($"Config Parameter({param}) Value Read: {value}");
                                            Console.WriteLine($"Config Parameter({param}) Value Read: {value}");

                                            break;

                                        default:
                                            throw new Exceptions.ConfigNotInitializedException($"Value {value} not valid for parameter {param}.");
                                    }
                                }

                                break;

                            default:
                                break;
                        }
                        break;
                        
                }
            }

            _isInitialized = true;
        }

    }
    
}