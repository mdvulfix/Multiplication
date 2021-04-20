using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Framework.Core;
using Framework.Core.Handlers;

namespace Framework
{
    public class PageRunTime : APage
    {
        public static readonly string OBJECT_NAME = "Page: RunTime";
        
        public override void Initialize()
        {
            SetParams(OBJECT_NAME);
            
            DataStats.ID = 3;
            DataStats.IsInitialized = true;

            Log(Label, "was sucsessfully initialized");
            //return this;

        }

        public override IConfigurable Configure()
        {
            DataStats.ID = 4;

            DataAnimation.UseAnimation = true;
            DataAnimation.Animator = GetComponent<Animator>();
            DataAnimation.CurrentState = ANIMATOR_STATE_NONE;
            DataAnimation.TargetState = ANIMATOR_STATE_NONE;
            
            //Activate(false);
            
            DataStats.IsConfigerd = true;
            Log(Label, "was sucsessfully configured");
            return this;
        }


        public override IPage Activate(bool activate)
        {
            if(DataAnimation.UseAnimation)
            {
                if(activate)
                {
                    DataStats.IsActive = ActivateObject(true);
                    Animate(true);
                }
                else
                {
                    Animate(false);
                    
                }
            }
            else
            {
                Log(Label, "Animation is disabled on page [ " + Label + " ]");
                DataStats.IsActive = ActivateObject(activate);
            }
                
            return this;
        }
        
        
        private void Animate (bool animate)
        {
            
            if(DataAnimation.Animator == null)
            {
                LogWarning(Label, "Animator is not set!");
                return;
            }


            if(!DataStats.IsActive)
            {
                LogWarning(Label, "Page is not active!");
                return;
            }

            DataAnimation.Animator.SetBool("On", animate);
            
            StopCoroutine("AwaitAnimation");
            StartCoroutine(AwaitAnimation(true));
        }
        
        
        private IEnumerator AwaitAnimation (bool wait)
        {
            
            DataAnimation.TargetState = wait ? ANIMATOR_STATE_ON : ANIMATOR_STATE_OFF;

            Log(Label, "Target state is ["  + DataAnimation.TargetState + "].");

            var state = DataAnimation.Animator.GetCurrentAnimatorStateInfo(0);
            while (state.IsName(DataAnimation.TargetState))
            {
                yield return null;
            }
               

            while (state.normalizedTime < 1)
            {
                
                //Log(Label, "Time ["  + state.normalizedTime + "]...");
                yield return null;
            }
                
            DataAnimation.TargetState = ANIMATOR_STATE_NONE;
            
            if(!wait)
            {
                DataStats.IsActive = false;
                //ActivateObject(false);
            }

            Log(Label, "was finised transition to " + (wait ? "On" : "Off") + " animation state!");      
        
        
        
        
        
        }
        




    }
}
