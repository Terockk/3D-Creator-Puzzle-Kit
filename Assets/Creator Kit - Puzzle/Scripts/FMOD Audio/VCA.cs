using UnityEngine;
using UnityEngine.UI;

namespace DreamTeam.Runtime.Systems.FMODSystem
{
    public class VCA : MonoBehaviour
    {
        FMOD.Studio.VCA vca;
        public string VCAName;

        private Slider slider;

        void Awake()
        {
            vca = FMODUnity.RuntimeManager.GetVCA("vca:/" + VCAName);
            slider = GetComponent<Slider>();

            // Load the saved volume from PlayerPrefs
            float savedVolume = PlayerPrefs.GetFloat(VCAName + "_Volume", 0.1f);
            slider.value = savedVolume;

            // Set the volume based on the loaded value
            SetVolume(savedVolume);
        }

        public void SetVolume(float volume)
        {
            vca.setVolume(volume);

            // Save the current volume to PlayerPrefs
            PlayerPrefs.SetFloat(VCAName + "_Volume", volume);
            PlayerPrefs.Save();
        }
    }
}