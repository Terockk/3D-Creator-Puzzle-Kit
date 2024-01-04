using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class TriggerAndStopSoundOnAnimator : StateMachineBehaviour
{
    public EventReference EnterSound;
    FMOD.Studio.EventInstance instance;
    private Transform objectTransform;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayEvent(EnterSound, animator);
    }

    void PlayEvent(EventReference soundEvent, Animator animator)
    {
        Vector3 position = animator.gameObject.transform.position;
        instance = FMODUnity.RuntimeManager.CreateInstance(soundEvent);
        instance.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(position));
        instance.start();
        instance.release();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       instance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}