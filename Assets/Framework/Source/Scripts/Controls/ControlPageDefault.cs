using UnityEngine;
using Framework.Core;

namespace Framework
{    
    public class ControlPageDefault : ControlPage
    {
        
        
        public Page PageOn;
        public Page PageOff;
        
        
        public override void Configure() 
        {                         
            if(Pages.Count > 0)
            {
                Log(Pages.Count + "pages were stored in cache.");
                foreach (var page in Pages)
                    page.Register();
            }
            else
                LogWarning("Pages haven't been found.");

        }
           
    
    
    }
}
