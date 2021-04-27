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
            
            Stats.GUID = 3;
            Stats.IsInitialized = true;

            Log(Label, "was sucsessfully initialized");
            //return this;

        }

        public override IConfigurable Configure()
        {
            Animation.UseAnimation = true;
            Animation.Animator = GetComponent<Animator>();
            Animation.CurrentState = ANIMATOR_STATE_NONE;
            Animation.TargetState = ANIMATOR_STATE_NONE;
            
            //Activate(false);
            
            Stats.IsConfigerd = true;
            Log(Label, "was sucsessfully configured");
            return this;
        }
    }
}
