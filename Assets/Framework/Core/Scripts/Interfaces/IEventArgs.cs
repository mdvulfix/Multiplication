namespace Core
{
    
    public interface IEventArgs
    {

    }
    
    public interface IEventArgs<T>
    {
        T Handler {get; }
    }



}