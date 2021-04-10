using System;

namespace Framework.Core 
{
    
    public interface IData: ICacheable, ISimpleObject
    {


    }
    
    
    public abstract class Data : SimpleObject, IData
    {

        public abstract ICacheable Initialize();
        public abstract ICacheable Configure();
            


        
    }


}