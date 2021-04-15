using UnityEngine;

namespace Framework.Core.Handlers
{

    public static class HandlerSceneObject
    {
        public static T Create<T>(string label, string parent = null, GameObject prefab = null) where T: ASceneObject
        {
            GameObject obj;
            
            if(prefab!=null)
            {
                obj =  GameObject.Instantiate(prefab);
                obj.name = label;
            }
            else
                obj =  new GameObject(label);

            if(parent!=null)
            {
                var objParent = GameObject.Find(parent);
                obj.transform.SetParent(objParent.transform);
            }

            var instance = obj.AddComponent<T>();
            return instance as T;
        }
    }
}