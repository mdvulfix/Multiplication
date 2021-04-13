using System.Collections.Generic;

namespace Framework.Core
{
    public interface IConfigurable
    {
        //IDataStats  DataStats {get; set;} 
        void Initialize();
        IConfigurable Configure();
            
    }

}