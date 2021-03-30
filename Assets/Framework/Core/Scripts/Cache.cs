using System;
using System.Collections;
using System.Collections.Generic;

namespace Framework.Core
{
    
    public interface ICache<T>
    {
        Dictionary<Type, ICacheable> Storage {get; }
        
        void Add(T instance);
        T Get();

    }
    

    [Serializable]
    public class Cache<T> : ICache<T>  where T: class, ICacheable
    { 
        public Dictionary<Type, ICacheable> Storage {get; } = new Dictionary<Type, ICacheable>(25);
    
    
        public void Add(T instance)
        {
            Storage.Add(instance.GetType(), instance);
        }

        public T Get()
        {
            
            T instance = null; 
            
            if(Storage.ContainsKey(typeof(T)))
                instance = (T)Storage[typeof(T)];
                
            return null;
        }
    
    
    
    
    
    
    
    
    }
}