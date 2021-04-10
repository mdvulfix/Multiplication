using UnityEngine;

namespace Framework.Core 
{
    public enum AnimationState
    {
        None,
        On,
        Off
    }
    
    public interface IDataAnimation: IData
    {
        bool            UseAnimation    {get; set;}
        Animator        Animator        {get; set;}
        AnimationState  CurrentState    {get; set;}
        AnimationState  TargetState     {get; set;} 
    }
    
    
    public class DataAnimation : IDataAnimation
    {
        
        public string         Label         {get; set;}
        
        public bool           UseAnimation  {get; set;} = false;
        public Animator       Animator      {get; set;} = null;
        public AnimationState CurrentState  {get; set;} = AnimationState.None;
        public AnimationState TargetState   {get; set;} = AnimationState.None;

    
        public DataAnimation()
        {


        }

    
    
    
    
    }


}
