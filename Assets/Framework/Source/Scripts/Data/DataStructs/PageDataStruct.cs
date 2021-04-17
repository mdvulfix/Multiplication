using UnityEngine;

using Framework.Core;

namespace Framework
{
    
    public interface IPageDataStruct: ISimpleObject, IDataStatsStuct, IDataAnimationStuct, ICacheable
    {
        
    }
    
    public class PageDataStruct : ASimpleObject, IPageDataStruct, IDebug
    {
        public static readonly string OBJECT_NAME = "DataStruct: Page";
        

        public bool             UseDebug        {get; set;} = true;
        public IDataStats       DataStats       {get; set;}
        public IDataAnimation   DataAnimation   {get; set;}
        
#region Configure

        public void Initialize()
        {
            Label = OBJECT_NAME;
            Log(Label, "was sucsessfully initialized");
            //return this;
        }

        public IConfigurable Configure()
        {
            Log(Label, "was sucsessfully configured");
            return this;
        }

#endregion

#region Debug

        public virtual void Log(string instance, string message)
        {
            if(UseDebug)
            {
                Debug.Log("["+ instance +"]: " + message);
            }
                
        }

        public virtual void LogWarning(string instance, string message)
        {
            if(UseDebug)
            {
                Debug.LogWarning("["+ instance +"]: " + message);
            }
        }

#endregion



    }
}
