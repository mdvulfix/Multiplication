using System.Collections.Generic;

namespace Framework.Core
{
    public interface IConfigurable: ICacheable
    {
        IDataStats Stats {get; }
        
        void Initialize();
        IConfigurable Configure();
            
    }

}