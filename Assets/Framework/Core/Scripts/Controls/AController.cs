namespace Core
{
    public interface IController
    {   
        void Init();
        void Dispose();
    }  

    public abstract class AController: IController  
    {
        public abstract void Init();
        public abstract void Dispose();

    } 
    
}