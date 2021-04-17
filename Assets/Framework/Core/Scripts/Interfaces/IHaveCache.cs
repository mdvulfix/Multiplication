using System.Collections.Generic;

namespace Framework.Core
{
    public interface IHaveCache<T> 
        where T: class, ICacheable
    {
        ICache<T> Cache {get; }
        T SetToCache(T instance);
        List<T> SetToCache(List<T> instances);
    
    }

}
