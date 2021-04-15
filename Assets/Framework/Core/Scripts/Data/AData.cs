using System;

namespace Framework.Core 
{
    
    public interface IData: ICacheable, ISceneObject
    {


    }
    
    
    public abstract class AData : ASceneObject, IData
    {


        
    }


}