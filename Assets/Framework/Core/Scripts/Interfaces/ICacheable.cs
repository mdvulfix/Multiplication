using System.Collections.Generic;

namespace Framework.Core
{
    public interface ICacheable
    {
        IDataStats  DataStats {get; } 
        
        ICacheable Initialize();
        ICacheable Configure();
            
    }

}