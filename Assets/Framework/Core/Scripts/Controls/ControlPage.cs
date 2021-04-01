using System.Collections.Generic;

namespace Framework.Core
{    
    
    public interface IControlPage: IControl
    {
        HashSet<IPage> Pages {get; }
        
        void SetPages(IFactoryPage factory);
        void SetPages(HashSet<IPage> pages); 
        
        void OnPageEnter(IPage page);
        void OnPageExit(IPage page);
    
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
        
        
        
        
        
        
        
        
        public abstract void OnPageEnter(IPage page);
        public abstract void OnPageExit(IPage page);


    }
}
