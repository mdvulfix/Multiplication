using System;
using UnityEngine;

namespace Framework.Core
{
    public interface IScene: ICacheable
    {
        string   Name       {get; }
        int      ID         {get; }  
        bool     IsActive   {get; set;}  
    }
    
    [Serializable]
    public abstract class Scene:  IScene
    {
        [SerializeField] private string     name; 
        [SerializeField] private int        id;
        [SerializeField] private bool       isActive;

        public string   Name        {get => name;       protected set => name = value;}
        public int      ID          {get => id;         protected set => id = value;}
        public bool     IsActive    {get => isActive;   set => isActive = value;}
    
    }

    [Serializable]
    public abstract class Scene<T> : Scene
    {
        public Scene(string name, int id)
        {
            Name = name;
            ID = id;
            

        }   
    }
}
