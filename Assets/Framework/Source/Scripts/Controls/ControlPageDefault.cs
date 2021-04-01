using UnityEngine;
using Framework.Core;

namespace Framework
{    
    public class ControlPageDefault : ControlPage
    {
   
        public override void Configure() 
        {                         
            /*
            if(Page.GetAllPages().Length > 0)
            {
                Log("[ControlPage]: " + Page.GetAllPages().Length + "pages were stored in cache.");
                foreach (var page in Page.GetAllPages())
                {
                    //TODO: Play animation

                }
            }
            else
                LogWarning("[ControlPage]: Pages haven't been found.");
            */

        }
        
        
        
        public override void OnPageEnter(IPage page)
        {

        }

        public override void OnPageExit(IPage page)
        {

        }


    }
}
