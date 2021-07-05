using Core.Scene.Page;
using UnityEngine;

namespace Source.Scene.Page
{
    public class PageLogin : APage
    {
        private readonly string OBJECT_NAME = "Page: Login";
        
        protected override void OnAwake()
        {
            var dataAnimation = new DataAnimation();
            
            dataAnimation.UseAnimation = true;
            dataAnimation.CurrentState = ANIMATOR_STATE_NONE;
            dataAnimation.TargetState = ANIMATOR_STATE_NONE;
            dataAnimation.Animator = GetComponent<Animator>();

            var parametrs = new PageInitializationParams(dataAnimation);
            
            Initialize(parametrs);

        }
        
        protected override void OnStart()
        {
            
        }
        
    } 
}
