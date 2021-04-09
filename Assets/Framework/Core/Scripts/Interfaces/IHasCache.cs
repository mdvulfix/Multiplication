using System.Collections.Generic;

namespace Framework.Core
{
    public interface IHasCache<T> where T: class, ICacheable
    {
        IDataStats  DataStats {get; } 
        ICache<T>   Cache {get; }
        
        T SetToCache(T instance) ;
        void SetToCache(List<T> instances);
            
    }

}