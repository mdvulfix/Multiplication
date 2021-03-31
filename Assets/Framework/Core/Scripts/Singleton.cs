using UnityEngine;


namespace Framework.Core
{
    public abstract class Singleton<T> : SceneObject where T : SceneObject
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

        public void Initialize()
        {
            if (instance) 
                return;
        
            instance = this as T;
        }



    }
}