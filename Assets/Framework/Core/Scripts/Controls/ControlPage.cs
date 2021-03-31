using UnityEngine;

namespace Framework.Core
{    
    [CreateAssetMenu(fileName = "Control Page (default)", menuName = "Controls/Page", order = 7)]
    public class ControlPage : Control
    {
        private IPage initialPage;

                
        public override void Initialize() 
        {                         
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
            
        }
        
        
        
        public void OnPageEnter(IPage page)
        {

        }

        public void OnPageExit(IPage page)
        {

        }


    }
}
