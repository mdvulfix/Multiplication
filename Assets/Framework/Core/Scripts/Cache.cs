using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framework.Core
{
    
    public interface ICache<T>: ISimpleObject, IDebug where T: class, ICacheable
    {
        Dictionary<Type, T> Store {get; }
        
        T Add(T instance);

        T Get<TValue>() where TValue: T;
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

    public class Cache<T> : ICache<T>  where T: class, ICacheable
    { 
        public string               Label       {get; }
        public bool                 UseDebug    {get; set;} = true;
        public Dictionary<Type, T>  Store       {get; } = new Dictionary<Type, T>(100);
    
        
        public Cache(string label)
        {   
            Label = label;

        }
        
        public T Add(T instance)
        {
            
            if(instance==null)
            {
                LogWarning(Label, "Instance was not found!");
                return null;

            }
            
            Store.Add(instance.GetType(), instance);
            return instance;
        }

        public T Get<TValue>() where TValue: T
        {
            T instance = null;
            Type type = typeof(TValue);
            if(Store.TryGetValue(type, out instance))
                return instance as T;
            else
            {
                LogWarning(Label, "Cache [" + typeof(T).Name + "] is empty!");
                return null;
            }
                
        }
        
        public T Get(Type type)
        {
            T instance = null;
            if(Store.TryGetValue(type, out instance))
                return instance as T;
            else     
            {
                LogWarning(Label, "Cache [" + typeof(T).Name + "] is empty!");
                return null;
            }
        }

        public T Get(T instance)
        {
            var valueArr = new List<object>(Store.Values);
            if(valueArr.Contains(instance))
            {
                var index = valueArr.IndexOf(instance);
                return valueArr[index] as T;
            }

            LogWarning(Label, "Cache [" + typeof(T).Name + "] is not contains [" + instance + "] with hashcode [" + instance.GetHashCode() + "]!");
            return null;
        }

        public T GetNext()
        {
            T instance = null;
            Type type = typeof(T);
            if(Store.ContainsKey(type))
            {
                var keyArr = new List<Type>(Store.Keys);
                var current = keyArr.IndexOf(type);
                var next = keyArr[++current];
                
                Store.TryGetValue(next, out instance);
                return instance as T;
            }
            else
            {
                LogWarning(Label, "Cache [" + typeof(T).Name + "] is empty!");
                return null;
            }       
        }
        
        public T GetNext(Type type)
        {
            T instance = null;
            if(Store.ContainsKey(type))
            {
                var keyArr = new List<Type>(Store.Keys);
                var current = keyArr.IndexOf(type);
                var next = keyArr[++current];
                
                Store.TryGetValue(next, out instance);
                return instance as T;
            }
            else
            {
                LogWarning(Label, "Cache [" + typeof(T).Name + "] is empty!");
                return null;
            }         
        }

        public T GetPrev()
        {
            T instance = null;
            Type type = typeof(T);
            if(Store.ContainsKey(type))
            {
                var keyArr = new List<Type>(Store.Keys);
                var current = keyArr.IndexOf(type);
                var next = keyArr[--current];
                
                Store.TryGetValue(next, out instance);
                return instance as T;
            }
            else
            {
                LogWarning(Label, "Cache [" + typeof(T).Name + "] is empty!");
                return null;
            }

        }

        public T GetPrev(Type type)
        {
            T instance = null;
            if(Store.ContainsKey(type))
            {
                var keyArr = new List<Type>(Store.Keys);
                var current = keyArr.IndexOf(type);
                var next = keyArr[--current];
                
                Store.TryGetValue(next, out instance);
                return instance as T;
            }
            else
            {
                LogWarning(Label, "Cache [" + typeof(T).Name + "] is empty!");
                return null;
            }

        }

        public List<T> GetAll()
        {
            
            if(!IsEmpty())
            {
                return new List<T>(Store.Values);
            }
            else
            {
                LogWarning(Label, "Cache " + typeof(T) + " is empty!");
                return null;
            }
        }

        public bool Contains(T instance)
        {           
           
           var valueArr = new List<object>(Store.Values);
           if(valueArr.Contains(instance))
            {
                Log(Label, "Cache [" + typeof(T).Name + "] is contains [" + instance + "]! HashCode is [" + instance.GetHashCode() + "]");
                return true;
            }
 
            LogWarning(Label, "Cache [" + typeof(T).Name + "] is not contains [" + instance + "]!");
            return false;
        }

        public bool IsEmpty()
        {
            if(Store.Keys.Count> 0)
                return false;

            LogWarning(Label, "Cache [" + typeof(T).Name + "] is empty!");
            return true;
        }

#region DebugFunctions

        public virtual void Log(string instance, string message)
        {
            if(UseDebug)
            {
                Debug.Log("["+ instance +"]: " + message);
            }
                
        }

        public virtual void LogWarning(string instance, string message)
        {
            if(UseDebug)
            {
                Debug.LogWarning("["+ instance +"]: " + message);
            }
        }

#endregion
    }



}