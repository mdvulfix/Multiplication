namespace Core
{
    
    public interface IHandler
    {   

    }  
    
    public interface IController
    {   
        IHandler Handler { get; }
    }  
    
    public abstract class AController: IController  
    {
        public IHandler Handler { get; private set; }

        protected abstract void Initialize(params object[] args);
        protected abstract void Dispose();
    } 

    //////////////////////////////////////////////////////////////////////////////////////////

    public interface IController<T>: IController
        where T: class
    {   
        ICache<T> Cache { get; }

    } 

    public abstract class AController<T>: AController, IController<T> 
        where T: class
    {
        public ICache<T> Cache { get; private set; }

        protected override void Initialize(params object[] args)
        {
            //TODO: DI;
            Cache = new Cache<T>();
        }

        protected override void Dispose()
        {

        }

    } 
    
}