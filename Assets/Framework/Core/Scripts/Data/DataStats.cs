using UnityEngine;

namespace Framework.Core 
{
    public interface IDataStats: IData, ISimpleObject
    {
        int ID {get; }
    }
      
    public class DataStat : IDataStats
    {
        public int      ID      {get; private set;}
        public string   Label   {get; private set;}
        
        public DataStat(int id, string label)
        {
            ID = id;
            Label = label;

        }
    }


}
