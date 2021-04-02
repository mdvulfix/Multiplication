using UnityEngine;
using Framework.Core;

namespace Framework
{    
    public class ControlPageDefault : ControlPage
    {
        public override void Configure() 
        {                         
            if(Pages.Count > 0)
            {
                Log("[ControlPage]: " + Pages.Count + "pages were stored in cache.");
                foreach (var page in Pages)
                    page.Register();
            }
            else
                LogWarning("[ControlPage]: Pages haven't been found.");


        }
        
        public override void TurnPageOn(IPage page)
        {

        }

        public override void TurnPageOff(IPage page)
        {

        }


    
    
    
    }
}
