using UnityEngine;

namespace Framework.Core
{
    
    public interface IFactory
    {
        GameObject CreateSceneObject(string name, string parent);
    }

    public abstract class Factory: ScriptableObject, IFactory
    {

        
    
        public GameObject CreateSceneObject(string name, string parent)
        {
            return HandlerSceneObject.Create(name, parent);

        }
    
    
    }
}