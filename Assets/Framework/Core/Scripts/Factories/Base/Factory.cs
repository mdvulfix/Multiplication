using UnityEngine;

namespace Framework.Core
{
    
    public interface IFactory: IScriptableObject, IDebug
    {
        T GetInstanceOf<T>(string name, string parent = null, GameObject prefab = null) where T: SceneObject;
    }

    public abstract class Factory: ScriptableObject, IFactory
    {       
        public string   Label       {get; set;} 
        public bool     UseDebug    {get; set;} = true;      
        
        public virtual T GetInstanceOf<T>(string name, string parent = null, GameObject prefab = null) where T: SceneObject
        {

            var obj = CreateSceneObject(name, parent, prefab);
            var instance = obj.AddComponent<T>();
            
            return instance as T;
        }

        protected GameObject CreateSceneObject(string name, string parent, GameObject prefab)
        {
            return HandlerSceneObject.Create(name, parent, prefab);

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