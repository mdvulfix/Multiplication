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

        T Get();
        T Get<TValue>() where TValue: T;
        T Get(Type type);

        T GetNext();
        T GetNext(Type type);
        
        T GetPrev();
        T GetPrev(Type type);

        List<T> GetAll();

    }

    public class Cache<T> : ICache<T>  where T: class, ICacheable
    { 
        public string               Label       {get; }
        public bool                 UseDebug    {get; set;} = true;
        public Dictionary<Type, T>  Store       {get; } = new Dictionary<Type, T>(100);
    
        public T Add(T instance)
        {
            Store.Add(instance.GetType(), instance);
            return instance;
        }

        public T Get()
        {
            T instance = null;
            Type type = typeof(T);
            if(Store.TryGetValue(type, out instance))
                return instance as T;
            else     
                return null;
        }

        public T Get<TValue>() where TValue: T
        {
            T instance = null;
            Type type = typeof(TValue);
            if(Store.TryGetValue(type, out instance))
                return instance as T;
            else     
                return null;
        }
        
        public T Get(Type type)
        {
            T instance = null;
            if(Store.TryGetValue(type, out instance))
                return instance as T;
            else     
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
                return null;          
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
                return null;          
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
                return null; 

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
                return null; 

        }

        public List<T> GetAll()
        {
            
            if(Store.Keys.Count > 0)
            {
                return new List<T>(Store.Values);
            }
            else
            {
                LogWarning(Label, "Cache " + typeof(T) + " is empty!");
                return null;
            }
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