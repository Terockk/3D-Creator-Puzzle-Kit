using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace DreamTeam.Runtime.Systems.FMODSystem
{
    public class ButtonAudio : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public FMODUnity.EventReference Click;
        public FMODUnity.EventReference HoverIn;
        public FMODUnity.EventReference HoverOut;

        private Button button;

        private void Awake()
        {
            button = GetComponent<Button>();

            //button.onClick.AddListener(ClickSound);
        }

        public void ClickSound()
        {
            if (Click.IsNull)
                return;

            FMODUnity.RuntimeManager.PlayOneShotAttached(Click, gameObject);
        }
        public void HoverInSound()
        {
            if (HoverIn.IsNull)
                return;

            FMODUnity.RuntimeManager.PlayOneShotAttached(HoverIn, gameObject);
        }
        public void HoverOutSound()
        {
            if (HoverOut.IsNull)
                return;

            FMODUnity.RuntimeManager.PlayOneShotAttached(HoverOut, gameObject);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            HoverInSound();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            HoverOutSound();
        }
    }
}