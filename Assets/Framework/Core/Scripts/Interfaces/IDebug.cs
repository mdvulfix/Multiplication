namespace Core
{
    public interface IDebug
    {
        bool IsDebug {get; set;}
        
        void Log(string instance, string message);
        void LogWarning(string instance, string message);
    }
}
