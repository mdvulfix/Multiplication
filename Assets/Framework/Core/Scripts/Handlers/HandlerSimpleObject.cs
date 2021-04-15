using UnityEngine;

namespace Framework.Core.Handlers
{

    public static class HandlerSimpleObject
    {
        public static T Create<T>(string label) where T: ASimpleObject, new()
        {
            var instance = new T();
            instance.Label = label;
            
            return instance as T;
        }



    }
}