using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Framework.Core;
using Framework.Core.Handlers;

namespace Framework
{

    public class PageLoading : APage
    {
        public static readonly string OBJECT_NAME = "Page: Loading";
        
        public override void Initialize()
        {
            SetParams(OBJECT_NAME);
        
            DataStats.ID = 0;
            DataStats.IsInitialized = true;

            Log(Label, "was sucsessfully initialized");
            //return this;

        }

        public override IConfigurable Configure()
        {
            
            DataAnimation.UseAnimation = true;
            DataAnimation.CurrentState = ANIMATOR_STATE_NONE;
            DataAnimation.TargetState = ANIMATOR_STATE_NONE;
            
            DataAnimation.Animator = GetComponent<Animator>();
            
            //Activate(false);
            
            DataStats.IsConfigerd = true;
            Log(Label, "was sucsessfully configured");
            return this;
        }
    }
}
