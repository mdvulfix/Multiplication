using System;
using System.Collections.Generic;
using UnityEngine;

namespace Framework.Core
{
    [Serializable]
    public class Cache<T> where T: ICacheable
    { 
        [SerializeField]
        private List<T> instances;
        [SerializeField]
        private int id;

        public List<T> Instances {get => this.instances; set => this.instances = value;}
    
    
    
    
    
    
    
    
    
    
    
    }
}