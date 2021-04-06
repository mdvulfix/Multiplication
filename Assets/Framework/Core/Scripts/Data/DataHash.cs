using System.Linq;
using System.Collections;
using UnityEngine;

namespace Framework.Core 
{
    
    public interface IDataHash : IData
    {
        void Add<T>(T instance) where T: class;
        T Get<T>() where T: class;
    }
    
    public class DataHash : Data, IDataHash
    {
        public Hashtable Storage {get; private set;}

        public DataHash()
        {
            Storage = new Hashtable();
        }

        public void Add<T>(T instance) where T: class
        {
            Storage.Add(instance.GetType(), instance);

        }
        
        public T Get<T>() where T: class
        {
         
            if(Storage.ContainsKey(typeof(T)))
            {
                var instance = Storage[typeof(T)];
                return instance as T;
            }
            return null;
        }

        public T Get<T>(int id) where T: class, IScene
        {
            //var values = Storage.Values;
            //var instance = from x in values where values[x]=id select x; 
            
            //T scene = Storage.Values.Cast<T>().Select(x => x.ID == id);
            
            var scene = from T s in Storage.Values
                where  s.ID == id                
                select Storage[ s ];
            
            //var scene = Storage.Cast<DictionaryEntry>().Where(instance => ((T)instance).ID == id) as T;
            Debug.Log(scene.GetType().ToString());
            
            return scene as T;
        }

    }
}
