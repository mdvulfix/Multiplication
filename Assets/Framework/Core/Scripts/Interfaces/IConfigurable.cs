using System.Collections.Generic;

namespace Framework.Core
{
    public interface IConfigurable: ICacheable
    {
        void Initialize();
        IConfigurable Configure();
            
    }

}