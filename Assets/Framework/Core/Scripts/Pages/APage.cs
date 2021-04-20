using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Framework.Core.Handlers;

namespace Framework.Core
{   
    public interface IPage: ISceneObject, IConfigurable, IDebug, IHaveCache<IPageDataStruct>
    {   
        IDataStats      DataStats       {get; set;}
        IDataAnimation  DataAnimation   {get; set;}
        
        //void SetData(IPageDataStruct datasSruct);
        
        IPage Activate(bool active);
    }


    [Serializable, RequireComponent(typeof(Animator)), RequireComponent(typeof(CanvasGroup))]
    public abstract class APage : ASceneObject, IPage
    {       
        
        public static readonly string PARENT_OBJECT_NAME = ABuilder.OBJECT_NAME_UI;

        public static readonly string ANIMATOR_STATE_NONE = "None";
        public static readonly string ANIMATOR_STATE_ON = "On";
        public static readonly string ANIMATOR_STATE_OFF = "Off";
        
        public ICache<IPageDataStruct>  Cache           {get; protected set;} = new Cache<IPageDataStruct>(); 
        
        public bool                     UseDebug        {get; set;} = true;
        public IDataStats               DataStats       {get => dataStats;      set => dataStats = value as DataStats;}
        public IDataAnimation           DataAnimation   {get => dataAnimation;  set => dataAnimation = value as DataAnimation;}
        
        [SerializeField] 
        protected bool projectMode;

        [Header("Data")]
        [SerializeField] private DataStats      dataStats;
        [SerializeField] private DataAnimation  dataAnimation;
        


 #region Configure
        
        public abstract void Initialize();
        public abstract IConfigurable Configure();

#endregion

        public abstract IPage Activate(bool active);
        

#region Cache

        public IPageDataStruct SetToCache(IPageDataStruct instance)
        {
            Cache.Add(instance);
            return instance;
        }

        public List<IPageDataStruct> SetToCache(List<IPageDataStruct> instances)
        {
            foreach (var instance in instances)
            {
                SetToCache(instance);
            }
            return instances;
        }

#endregion 

#region Log

        public virtual void Log(string instance, string message)
        {
            if(UseDebug)
            {
                Debug.Log("["+ instance +"]: " + message);
            }
        }

        public virtual void LogWarning(string instance, string message)
        {
            if(UseDebug)
            {
                Debug.LogWarning("["+ instance +"]: " + message);
            }
        }

#endregion
    }





}
