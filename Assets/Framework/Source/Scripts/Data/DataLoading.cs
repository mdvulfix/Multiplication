using System;
using UnityEngine;
using Core.Data;
using Core.Page;
using Core.Scene;

namespace Source.Data.Scene.Loading
{
    public interface IDataLoading: IData
    {
        SceneIndex Index { get; }

        IPage PageDefault { get; }
        IPage PageActive { get; }

    }

    [Serializable]
    public struct DataLoading: IDataLoading
    {
        public SceneIndex Index { get; private set; }

        public IPage PageDefault { get; private set; }
        public IPage PageActive { get; private set; }

        public DataLoading(SceneIndex index, IPage pageActive, IPage pageDefault)
        {
            Index = index;
            PageActive = pageActive;
            PageDefault = pageDefault;
        }


    }
}