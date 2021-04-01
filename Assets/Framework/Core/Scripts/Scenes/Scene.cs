using System;
using UnityEngine;

namespace Framework.Core
{
    public interface IScene
    {
        string   Name    {get; }
        int      ID      {get; }  
    }
    
    [Serializable]
    public abstract class Scene: IScene
    {
        [SerializeField] private string name;
        [SerializeField] private int id;

        public string   Name    {get => name; private set => name = value;}
        public int      ID      {get => id; private set => id = value;}
    
        public Scene(string name, int id)
        {
            Name = name;
            ID = id;

        }   
    }
}
