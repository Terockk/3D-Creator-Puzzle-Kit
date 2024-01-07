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
    FMOD.Studio.EventInstance musicEventInstance;
    FMOD.Studio.EventInstance WinStop;

    AudioSource m_AudioSource;

    void Awake()
    {
        m_AudioSource = GetComponent<AudioSource>();
        musicEventInstance = FMODUnity.RuntimeManager.CreateInstance("event:/Music/Gameplay Music");
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
                FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/UI/General/Win");
                win = true;
                WinStop.setParameterByName("Win Stop", 1f);
            }
        }
    }
}