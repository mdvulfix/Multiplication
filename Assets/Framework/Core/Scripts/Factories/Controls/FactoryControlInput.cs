
namespace Framework.Core
{   
    public abstract class FactoryControlInput : FactoryControl
    {
        public override T Get<T>() 
        {

            var obj = CreateSceneObject(typeof(T).Name, PARENT_NAME);
            var instance = obj.AddComponent<T>();
            
            return instance as T;
        }
        


    }
}