namespace Framework.Core
{
    public interface IDebug
    {
        bool UseDebug {get; set;}
        
        void Log(string instance, string message);
        void LogWarning(string instance, string message);
    }
}
