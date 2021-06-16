using Core.Data;
using Core.Scene.State;

namespace Framework.Data.Stats
{
    public interface IDataStats: IData
    {
        IState StateCurrent { get; set; }
    }
      
 
    public struct DataStats : IDataStats
    {
        public IState StateCurrent { get; set; }

    }
}
