using Core.Scene.Page;
using UnityEngine;


namespace Source.Scene.Page
{
    public class PageMenu : APage
    {
        public static readonly string OBJECT_NAME = "Page: Menu";

        protected override void OnAwake()
        {
            var dataAnimation = new DataAnimation();
            
            dataAnimation.UseAnimation = true;
            dataAnimation.CurrentState = ANIMATOR_STATE_NONE;
            dataAnimation.TargetState = ANIMATOR_STATE_NONE;
            dataAnimation.Animator = GetComponent<Animator>();

            var pageParams = new PageInitializationParams(dataAnimation);
            
            Initialize(pageParams);

        }
        
        protected override void OnStart()
        {
            
        }
        
    } 
}