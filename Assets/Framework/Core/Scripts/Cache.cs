using System;
using System.Collections;
using System.Collections.Generic;

namespace Framework.Core
{
    
    public interface ICache<T>
    {
        Dictionary<Type, ICacheable> Store {get; }
        
        T Add(T instance);
        T Get(Type type);
        T GetNext(Type type);
        T GetPrev(Type type);

    }

    public class Cache<T> : ICache<T>  where T: class, ICacheable
    { 
        public Dictionary<Type, ICacheable> Store {get; } = new Dictionary<Type, ICacheable>(100);
    
        public T Add(T instance)
        {
            Store.Add(instance.GetType(), instance);
            return instance;
        }

        public T Get(Type type)
        {
            ICacheable instance = null;
            if(Store.TryGetValue(type, out instance))
                return instance as T;
            else     
                return null;
        }

        public T GetNext(Type type)
        {
            ICacheable instance = null;
            if(Store.ContainsKey(type))
            {
                var keyArr = new List<Type>(Store.Keys);
                var current = keyArr.IndexOf(type);
                var next = keyArr[++current];
                
                Store.TryGetValue(next, out instance);
                return instance as T;
            }
            else
                return null;          
        }

        public T GetPrev(Type type)
        {
            ICacheable instance = null;
            if(Store.ContainsKey(type))
            {
                var keyArr = new List<Type>(Store.Keys);
                var current = keyArr.IndexOf(type);
                var next = keyArr[--current];
                
                Store.TryGetValue(next, out instance);
                return instance as T;
            }
            else
                return null; 

        }
    }
}