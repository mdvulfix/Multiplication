using UnityEngine;
using Framework.Core;

namespace Framework
{
    public class PagePause : APage
    {
        public static readonly string OBJECT_NAME = "Page: Pause";

        public override void Initialize()
        {
            SetParams(OBJECT_NAME);
            
            Stats.GUID = 5;
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
