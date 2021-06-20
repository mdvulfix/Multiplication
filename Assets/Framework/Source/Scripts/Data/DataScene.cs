using System;
using Core.Scene;
using Core.Scene.Page;
using UnityEngine;

namespace Core.Data.Scene
{

    public interface IDataScene: IData
    {
        string      Label { get; }
        GameObject  Parent { get; }

        SceneIndex  Index { get; }

        IPage       PageStart { get; }
        IPage[]     Pages { get; }
    }
    
    [Serializable]
    public struct DataScene: IDataScene
    {
        public string           Label { get; private set; }
        public GameObject       Parent { get; private set; }
        
        public SceneIndex       Index { get; private set; }
        
        public IPage[]          Pages { get; private set; }
        public IPage            PageStart { get; private set; }
        
        public DataScene(string label, GameObject parent, SceneIndex index, IPage[] pages, IPage pageStart)
        {
            Label = label;
            Parent = parent;
            Index = index;
            Pages = pages;
            PageStart = pageStart;

        }


    }
}