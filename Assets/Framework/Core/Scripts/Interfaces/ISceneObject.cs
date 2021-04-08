using System;
using UnityEngine;

namespace Framework.Core
{
    public interface ISceneObject
    {   
        GameObject  ObjectOnScene   {get; }
        string      Label           {get; }
    
        void SetSceneObject(string label);
    }
}
