using System;
using Core.Scene;


namespace Core.Events
{
    
    public interface IEventArgs
    {

    }
    
    public interface IEventArgs<T>
    {
        
    }

    public interface ISceneEventArgs: IEventArgs<IScene>
    {
        IScene Scene {get; }
        
    }




}