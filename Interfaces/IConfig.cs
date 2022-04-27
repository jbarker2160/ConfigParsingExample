namespace ConfigParsingExample.Interfaces
{
    public interface IConfig
    {
        string host { get; }
        int serverId { get; }
        float serverLoadAlarm { get; }
        string user { get; }
        bool verbose { get; }
        bool testMode { get; }
        bool debugMode { get; }
        string logFilePath { get; }
        bool sendNotifications { get; }
    }
}
