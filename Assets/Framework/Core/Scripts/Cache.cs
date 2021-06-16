using System;
using System.Collections.Generic;

namespace Core.Cache
{
    public interface ICache<T> where T: class
    {

        T Add<TValue>() where TValue : T, new();
        T Add(T instance);

        bool Get<TValue>(out T instance) where TValue: T;
        T Get(Type type);
        T Get(T value);

        T GetNext();
        T GetNext(Type type);
        
        T GetPrev();
        T GetPrev(Type type);

        bool IsEmpty();
        bool Contains(T value);

        List<T> GetAll();

    }

    public class Cache<T> : ICache<T>  where T: class
    {
        private Dictionary<Type, T> m_Storage;

        public Cache()
        {   
            m_Storage = new Dictionary<Type, T>(100);

        }
        
        public T Add<TValue>() where TValue: T, new()
        {
            TValue instance = new TValue();

            m_Storage.Add(typeof(TValue), instance);
            return instance as T;
        }
        
        public T Add(T instance)
        {
            if(instance==null)
                return null;
            
            m_Storage.Add(instance.GetType(), instance);
            return instance;
        }

        public bool Get<TValue>(out T instance) where TValue: T
        {
            Type type = typeof(TValue);
            if (m_Storage.TryGetValue(type, out instance))
            {
                return true;
            }
            
            return false;      
        }
        
        public T Get(Type type)
        {
            T instance = null;
            if(m_Storage.TryGetValue(type, out instance))
                return instance as T;

            return null;
        }

        public T Get(T instance)
        {
            var valueArr = new List<object>(m_Storage.Values);
            if(valueArr.Contains(instance))
            {
                var index = valueArr.IndexOf(instance);
                return valueArr[index] as T;
            }

            return null;
        }

        public T GetNext()
        {
            T instance = null;
            Type type = typeof(T);
            if(m_Storage.ContainsKey(type))
            {
                var keyArr = new List<Type>(m_Storage.Keys);
                var current = keyArr.IndexOf(type);
                var next = keyArr[++current];
                
                m_Storage.TryGetValue(next, out instance);
                return instance as T;
            }

            return null;      
        }
        
        public T GetNext(Type type)
        {
            T instance = null;
            if(m_Storage.ContainsKey(type))
            {
                var keyArr = new List<Type>(m_Storage.Keys);
                var current = keyArr.IndexOf(type);
                var next = keyArr[++current];
                
                m_Storage.TryGetValue(next, out instance);
                return instance as T;
            }

            return null;      
        }

        public T GetPrev()
        {
            T instance = null;
            Type type = typeof(T);
            if(m_Storage.ContainsKey(type))
            {
                var keyArr = new List<Type>(m_Storage.Keys);
                var current = keyArr.IndexOf(type);
                var next = keyArr[--current];
                
                m_Storage.TryGetValue(next, out instance);
                return instance as T;
            }

            return null;
        }

        public T GetPrev(Type type)
        {
            T instance = null;
            if(m_Storage.ContainsKey(type))
            {
                var keyArr = new List<Type>(m_Storage.Keys);
                var current = keyArr.IndexOf(type);
                var next = keyArr[--current];
                
                m_Storage.TryGetValue(next, out instance);
                return instance as T;
            }

            return null;

        }

        public List<T> GetAll()
        {
            if(!IsEmpty())
            {
                return new List<T>(m_Storage.Values);
            }
            
            return null;
        }

        public bool Contains(T instance)
        {           
           var valueArr = new List<object>(m_Storage.Values);
           if(valueArr.Contains(instance))
            {
                return true;
            }
 
            return false;
        }

        public bool IsEmpty()
        {
            if(m_Storage.Keys.Count> 0)
                return false;

            return true;
        }
    }
}