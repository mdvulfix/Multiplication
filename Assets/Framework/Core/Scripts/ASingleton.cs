using UnityEngine;


namespace Core
{
    public abstract class ASingleton<T> : ASceneObject where T : ASceneObject
    {
        private static T instance;

        public static T Instance
        {
            get
            {
                if (instance != null) 
                    return instance; 
                
                var singleObj = new GameObject();
                
                instance = singleObj.AddComponent<T>();
                instance.name = typeof(T).Name;

                return instance;

            }
        }
    }
}