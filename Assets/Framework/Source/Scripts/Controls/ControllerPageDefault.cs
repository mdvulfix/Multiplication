using UnityEngine;
using Framework.Core;

namespace Framework
{    
    public class ControllerPageDefault : ControllerPage
    {       
        // Initialize in factory        
        public override void Initialize()
        {
            SetSceneObject(ControllerPage.OBJECT_NAME);
            Log(Label, "was sucsessfully initialized");
        } 
        
        // Initialize in builder 
        public override ICacheable Configure() 
        {                                     
            InitializePages();
            SetActivePage<PageLoading>();
            Log(Label, "was successfully configured.");
            return this;
        }

        private void InitializePages() 
        {
            foreach (var page in Cache.GetAll())
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
