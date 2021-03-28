using System;
using System.Collections;
using System.Collections.Generic;

namespace Framework.Core
{
    [Serializable]
    public class Cache<T> where T: class, ICacheable
    { 
        public Hashtable Storage {get; private set;}
    
        public void Add(T instance)
        {
            Storage.Add(typeof(T), instance);

        }

        public T Get<H>()
        {
            if(Storage.ContainsKey(typeof(T)))
                return (T)Storage[typeof(T)];
                
            return null;
        }
    
    
    
    
    
    
    
    
    }
}