using UnityEngine;
using Framework.Core;

namespace Framework
{    
    public class ControllerPageDefault : AControllerPage
    {       
        
        public static readonly string OBJECT_NAME = "Controller: Page";
        
        
        // Initialize in factory        
        public override void Initialize()
        {
            SetSceneObject(OBJECT_NAME);
            Log(Label, "was sucsessfully initialized");
            //return this;
        } 
        
        // Initialize in builder 
        public override IConfigurable Configure() 
        {                                     
            foreach (var page in Cache.GetAll())
            {
                page.Configure();
            }
            
            SetActivePage<PageLoading>();
            
            Log(Label, "was successfully configured.");
            return this;
        }


        private void SetActivePage<T>() where T: class, IPage
        {
            PageActive = Cache.Get<T>();
            PageActive.Activate(true);
            Log(Label, "Page [" + PageActive.Label + "] was activated.");
        }


    }
}
