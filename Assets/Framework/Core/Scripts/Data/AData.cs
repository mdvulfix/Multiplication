using System;

namespace Framework.Core 
{
    
    public interface IData: ICacheable, ISimpleObject
    {


    }
    
    
    public abstract class AData : ASimpleObject, IData
    {


        
    }


}