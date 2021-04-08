using System;
using UnityEngine;

namespace Framework.Core
{
    public interface IScene: ICacheable
    {
        string   Name       {get; }
        int      ID         {get; }  
        bool     IsActive   {get; set;}  
    
        void Configure(string name, int id);
    }
    
    [Serializable]
    public abstract class Scene: IScene
    {
        [SerializeField] private string     name; 
        [SerializeField] private int        id;
        [SerializeField] private bool       isActive;

        public string   Name        {get => name;       protected set => name = value;}
        public int      ID          {get => id;         protected set => id = value;}
        public bool     IsActive    {get => isActive;   set => isActive = value;}
       
        public abstract void Configure(string name, int id);
    
    }
    
    public class Scene<T>: Scene where T: class, IScene
    {
        public static ICache<T> Cache {get; private set;}

        public override void Configure(string name, int id)
        {
            Name = name;
            ID = id;
            Cache = new Cache<T>();
        } 
    
    
    }




}
