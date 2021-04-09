using UnityEngine;
using Framework.Core;

namespace Framework
{    
    public class ControllerPageDefault : ControllerPage
    {       
        // Initialize in factory        
        public override IController Initialize()
        {
            SetSceneObject(ControllerPage.OBJECT_NAME);
            Log(Label, "was sucsessfully initialized");
            return this;
        } 
        
        // Initialize in builder 
        public override IController Configure() 
        {                                     
            InitializePages();
            SetActivePage<PageLoading>();
            Log(Label, "was successfully configured.");
            return this;
        }

        private void InitializePages() 
        {
            foreach (var page in Cache.Store.Values)
            {
                page.Initialize();
            
            }
            
        }

        private void SetActivePage<T>() where T: class, IPage
        {
            PageActive = Cache.Get<T>();
        }


    }
}
