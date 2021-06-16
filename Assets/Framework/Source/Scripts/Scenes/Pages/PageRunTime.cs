using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Page;

namespace Source.Page
{
    public class PageRunTime : APage
    {
        public static readonly string OBJECT_NAME = "Page: RunTime";
        
        public override void Init()
        {
            SetParams(OBJECT_NAME);
            
            Stats.GUID = 3;
            Stats.IsInitialized = true;

            Animation.UseAnimation = true;
            Animation.Animator = GetComponent<Animator>();
            Animation.CurrentState = ANIMATOR_STATE_NONE;
            Animation.TargetState = ANIMATOR_STATE_NONE;

            Log(Label, "was sucsessfully initialized");

        }
    }
}
