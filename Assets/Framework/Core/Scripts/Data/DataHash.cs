using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace Framework.Core 
{
    
    public interface IDataHash : IData
    {
        void Add(object instance);
        object Get(int typeHashCode);
    }
    
    public class DataHash : Data
    {
        public Dictionary<int, object> Storage {get; private set;}

        public DataHash()
        {
            Storage = new Dictionary<int, object>();
        }

        public void Add(object instance)
        {
            Storage.Add(instance.GetType().GetHashCode(), instance);

        }
        
        public object Get(int typeHashCode)
        {
            object instance;
            if(Storage.TryGetValue(typeHashCode, out instance))
                return instance;
            else
                return null;
        }

        public object GetNext(int typeHashCode)
        {
            if(Storage.ContainsKey(typeHashCode))
            {           
                List<int> lKeys = Storage.Keys.ToList();
                int reqIndex = lKeys.IndexOf(typeHashCode) + 1;
                typeHashCode = lKeys[reqIndex];
                object instance;
                Storage.TryGetValue(typeHashCode, out instance);
                return instance;
            }
            else
                return null;

        }

        public object GetPrev(int typeHashCode)
        {
            if(Storage.ContainsKey(typeHashCode))
            {           
                List<int> lKeys = Storage.Keys.ToList();
                int reqIndex = lKeys.IndexOf(typeHashCode) - 1;
                typeHashCode = lKeys[reqIndex];
                object instance;
                Storage.TryGetValue(typeHashCode, out instance);
                return instance;
            }
            else
                return null;

        }

    }
}
