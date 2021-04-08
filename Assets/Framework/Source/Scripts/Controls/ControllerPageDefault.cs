using UnityEngine;
using Framework.Core;

namespace Framework
{    
    public class ControllerPageDefault : ControllerPage
    {       
        [SerializeField]
        private FactoryPage factoryPage;
        
        public void Start()
        {   
            Configure();
            PageActive = Cache.Get<PageLoading>();
        }
        
        public override void Configure() 
        {                                     
           
            Cache.Add(factoryPage.Get<PageLoading>("Page: Loading"));
            Cache.Add(factoryPage.Get<PageLogin>("Page: Login"));
            Cache.Add(factoryPage.Get<PageMenu>("Page: Menu"));
            
            Log(Name, Cache.Store.Count + "pages were stored in cache.");

            foreach (var page in Cache.Store.Values)
            {
                page.Initialize();
            }
        }
    }
}
