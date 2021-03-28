
namespace Framework.Core
{
    public interface IPage: ICacheable
    {

    }
    
    public abstract class APage : Agent, IPage
    {
        
        public static Cache<IPage> Cache {get; } = new Cache<IPage>();


#region Unity functions
    
        public virtual void OnAwake()
        {
            Cache.Add(this);
            Register();
        
        
        }
        
        public abstract void OnUpdate();

#endregion
        
        
        
#region Private functions      
        protected abstract void Register();

    

#endregion  
    }

}
