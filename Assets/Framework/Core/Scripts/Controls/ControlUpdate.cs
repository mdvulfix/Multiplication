using UnityEngine;
using Framework.Core;

namespace Framework 
{
    [CreateAssetMenu(fileName = "Update(Default)", menuName = "Controls/Update", order = 2)]
    public class ControlUpdate : AControl
    {

        private Cache<ICacheable> cache;
        
        public override void OnAwake() 
        {
            
            foreach (var instance in cache.Instances)
            {
                instance.OnAwake();
            }
        
        
        
        }

        public override void OnUpdate() 
        {
            foreach (var instance in cache.Instances)
            {
                instance.OnUpdate();
            }
        
        }



    }


}
