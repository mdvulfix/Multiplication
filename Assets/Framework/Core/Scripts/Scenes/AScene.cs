﻿using System;
using UnityEngine;

namespace Framework.Core
{
    public interface IScene: ISimpleObject, IConfigurable, IDebug
    {
        IDataStats DataStats {get; set;}
        
        //IScene Activate(bool active);
    }
    
    [Serializable]
    public abstract class AScene: ASimpleObject, IScene
    {
        
        public bool         UseDebug    {get; set;} = true;
        public IDataStats   DataStats   {get; set;}

        public abstract void Initialize();
        public abstract IConfigurable Configure();
            
        public AScene()
        {

        }
    
#region Log

        public void Log(string instance, string message)
        {
            if(UseDebug)
            {
                Debug.Log("["+ instance +"]: " + message);
            }
        }
      
        public void LogWarning(string instance, string message)
        {
            if(UseDebug)
            {
                Debug.LogWarning("["+ instance +"]: " + message);
            }
        }

#endregion
    
    }
}
