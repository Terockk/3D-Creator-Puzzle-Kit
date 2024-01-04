using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class TriggerSoundOnAnimator : StateMachineBehaviour
{
    public EventReference EnterSound;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        FMODUnity.RuntimeManager.PlayOneShotAttached(EnterSound, animator.gameObject);
    }
}