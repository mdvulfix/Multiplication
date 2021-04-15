namespace Framework.Core
{
    public interface IHaveFactory
    {
        IFactory<TCacheable> GetFactory<TCacheable>(IFactory<TCacheable> factory) 
            where TCacheable: class, ICacheable;
    
    }

}