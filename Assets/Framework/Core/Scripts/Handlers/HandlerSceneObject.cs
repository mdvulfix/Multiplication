using UnityEngine;

namespace Framework.Core.Handlers
{

    public static class HandlerSceneObject
    {
        public static T Create<T>(string label, GameObject objParent = null, GameObject objPrefab = null) where T: ASceneObject
        {
            GameObject obj;
            
            if(objPrefab!=null)
            {
                obj =  GameObject.Instantiate(objPrefab);
                obj.name = label;
            }
            else
                obj =  new GameObject(label);

            if(objParent!=null)
            {
                obj.transform.SetParent(objParent.transform);
            }

            var instance = obj.AddComponent<T>();
            return instance as T;
        }

        public static GameObject Find(string label)
        {
            return GameObject.Find(label);
        }





    }
}