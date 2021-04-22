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
            
            DataStats.GUID = 5;
            DataStats.IsInitialized = true;

            Log(Label, "was sucsessfully initialized");
            //return this;

        }

        public override IConfigurable Configure()
        {
            DataAnimation.UseAnimation = true;
            DataAnimation.Animator = GetComponent<Animator>();
            DataAnimation.CurrentState = ANIMATOR_STATE_NONE;
            DataAnimation.TargetState = ANIMATOR_STATE_NONE;

            //Activate(false);

            DataStats.IsConfigerd = true;
            Log(Label, "was sucsessfully configured");

            return this;
        }
    } 
}
