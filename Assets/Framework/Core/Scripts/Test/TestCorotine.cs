using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCorotine : MonoBehaviour
{
        public static readonly string ANIMATOR_STATE_NONE = "None";
        public static readonly string ANIMATOR_STATE_ON = "On";
        public static readonly string ANIMATOR_STATE_OFF = "Off";
    
        
        public GameObject obj;
        private Animator animator; 
    
    
    
    void Start()
    {
        
        animator = obj.GetComponent<Animator>();
        
    }
    
    void Update()
    {
        
        if(Input.GetKeyUp(KeyCode.I))
        {
            TurnIn();
        }

        if(Input.GetKeyUp(KeyCode.O))
        {
            TurnOut();
        }
        
    }


    void TurnIn()
    {
        
        Debug.Log("Start On!");
        StopCoroutine("AwaitAnimation");
        StartCoroutine(AwaitAnimation (true));
        
    }

    void TurnOut()
    {
        
        Debug.Log("Start Off!");
        StopCoroutine("AwaitAnimation");
        StartCoroutine(AwaitAnimation (false));
        
    }

    private IEnumerator AwaitAnimation (bool wait)
    {

        if(wait)
        {
            obj.SetActive(wait);
            Debug.Log("Object was activated.");
            
        }

        animator.SetBool("On", wait);

        var TargetState = wait ? ANIMATOR_STATE_ON : ANIMATOR_STATE_OFF;
        Debug.Log("Target state is ["  + TargetState + "].");

        //var state = animator.GetCurrentAnimatorStateInfo(0).IsName(TargetState);
        

        
        while(!animator.GetCurrentAnimatorStateInfo(0).IsName(TargetState))
        {
            yield return null;

        }
        
        
        while(animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
        {
            yield return null;

        }

        TargetState = ANIMATOR_STATE_NONE;
        
        Debug.Log("Target state is ["  + TargetState + "].");
        Debug.Log("was finised transition to " + (wait ? "On" : "Off") + " animation state!"); 
    
    
        if(!wait)
        {
            obj.SetActive(wait);
            Debug.Log("Object was diactivated.");
            
        }
    }
}
