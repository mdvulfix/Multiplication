using UnityEngine;
using Framework.Core;

namespace Framework
{    
    public class ControllerPageDefault : AControllerPage
    {       
        
        public static readonly string OBJECT_NAME = "Controller: Page";
    
        
        [SerializeField] private PageLoading pageLoading;
        [SerializeField] private PageLogin pageLogin;
        [SerializeField] private PageMenu pageMenu;
        
        
        public override void OnAwake()
        {
            Initialize();
            
            SetToCache(pageLoading).Initialize();
            SetToCache(pageLogin).Initialize();
            SetToCache(pageMenu).Initialize();
            
            Configure();

        }
        
    
        // Initialize in factory        
        public override void Initialize()
        {
            SetParams(OBJECT_NAME);
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
