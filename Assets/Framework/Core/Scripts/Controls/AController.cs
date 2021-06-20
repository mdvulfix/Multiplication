using Core.Data;

namespace Core
{
    
    public interface IController<T>
    {   
        void Initialize(params object[] args);
        void Dispose();
    }  
    
    
    public interface IController
    {   
        void Initialize(params object[] args);
        void Dispose();
    }  

    public abstract class AController: IController  
    {
        public abstract void Initialize(params object[] args);
        public abstract void Dispose();

    } 
    
}