using UnityEngine;

namespace DreamTeam.Runtime.Systems.FMODSystem
{
    public class AnimationOneShotSound : MonoBehaviour
    {

        void PlayEvent(string path)
        {
            FMODUnity.RuntimeManager.PlayOneShot(path, GetComponent<Transform>().position);
        }
    }
}