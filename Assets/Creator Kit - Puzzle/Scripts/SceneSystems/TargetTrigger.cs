using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider)), RequireComponent(typeof(AudioSource))]
public class TargetTrigger : MonoBehaviour
{
    public float uiDelay = 3f;
    public Collider marble;
    public TimingRecording timingRecording;
    public TargetGroupWeightControl targetGroupWeightControl;
    public ParticleSystem completeParticleSystem;

    bool win = false;

    FMOD.Studio.Bus MusicBus;

    //AudioSource m_AudioSource;

    void Awake()
    {
        MusicBus = FMODUnity.RuntimeManager.GetBus("Bus:/Music");
        //m_AudioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other == marble)
        {
            completeParticleSystem.Play();
            timingRecording.GoalReached(uiDelay);
            targetGroupWeightControl.ApplySpecificFocus(marble.attachedRigidbody);

            // Check if win is false before playing the FMOD event
            if (!win)
            {
                MusicBus.stopAllEvents(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                FMODUnity.RuntimeManager.PlayOneShot("event:/Music/Win");
                win = true;
            }
        }
    }
}