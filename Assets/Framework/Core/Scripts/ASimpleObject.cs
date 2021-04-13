using System;
using UnityEngine;

namespace Framework.Core
{   
    
    public interface ISimpleObject
    {   
        string Label {get; }
    

    }
    
    [Serializable]
    public abstract class ASimpleObject: ISimpleObject
    {       
        public string Label {get; set;}
       
    }

}
