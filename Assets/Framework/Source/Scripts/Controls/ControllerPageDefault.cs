using UnityEngine;
using Framework.Core;

namespace Framework
{    
    public class ControllerPageDefault : ControllerPage
    {       
                
        
        
        public override void Initialize()
        {
            SetSceneObject(SCENEOBJECT_NAME);
            Log(Label, "was sucsessfully initialized");

        } 
        
        
        public override void Configure() 
        {                                     

            
            
            
            
            foreach (var page in Cache.Store.Values)
            {
                page.Initialize();
            }

            PageActive = Cache.Get<PageLoading>();
            Log(Label, "was successfully configured.");
        }
    }
}
