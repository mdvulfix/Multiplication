using System;
using Framework.Core;

namespace Framework
{
    
    [Serializable]
    public class Scene : AScene
    {
        public Scene(string name, int id)
        {
            Name = name;
            ID = id;
            

        }   
    }
}
