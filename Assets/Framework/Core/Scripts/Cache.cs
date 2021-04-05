using System;
using System.Collections;
using System.Collections.Generic;

namespace Framework.Core
{
    
    public interface ICache<T>
    {
        Dictionary<Type, ICacheable> Storage {get; }
        
        void Add(T instance);
        T Get(Type type);

    }
    

    [Serializable]
    public class Cache<T> : ICache<T>  where T: class, ICacheable
    { 
        public Dictionary<Type, ICacheable> Storage {get; } = new Dictionary<Type, ICacheable>(25);
    
    
        public void Add(T instance)
        {
            Storage.Add(instance.GetType(), instance);
        }

        public T Get(Type type)
        {
            
            T instance = null; 
            
            if(Storage.ContainsKey(type))
                instance = (T)Storage[type];
                
            return null;
        }
    
    
    
    
    
    
    
    
    }
}