using System.Collections.Generic;

namespace Framework.Core
{    
    
    public interface IControlPage: IControl
    {
        HashSet<IPage> Pages {get; }
        
        void SetPages(IFactoryPage factory);
        void SetPages(HashSet<IPage> pages); 
        
        void TurnPageOn(IPage page);
        void TurnPageOff(IPage page);
    
    } 
    
    
    public abstract class ControlPage : Control, IControlPage
    {
   
        
        private HashSet<IPage> pages;
       
        public HashSet<IPage> Pages {get => pages; private set => pages = value; }
        
        
        
        public void SetPages(IFactoryPage factory)
        {
            Pages = factory.GetPages();

        }
        
        public void SetPages(HashSet<IPage> pages)
        {
            Pages = pages;

        }
        
        
        public virtual void TurnPageOn(IPage page)
        {
            if(!Pages.Contains(page))
            {
                LogWarning("You are trying to turn a page on [" + page.Name + "] that has not been registered!");
                return;
            }

            page.Activate(true);
        }
        
        
        public virtual void TurnPageOff(IPage page)
        {

            
        }


    }
}
