namespace Framework.Core
{
    public interface IAwakable
    {
        bool IsProject {get; }
        
        void OnAwake();
    
    }

}
