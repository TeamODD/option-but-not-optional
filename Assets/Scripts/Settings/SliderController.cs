using UnityEngine;
using UnityEngine.UI;

namespace Settings
{
    //각 슬라이더는 SliderController를 통해 값을 전달받아야 한다.
    //SetAction 메소드를 통해 SliderActionSo를 받아서 OnSliderValueChanged 메소드를 호출한다.
    public class SliderController : MonoBehaviour
    {
        [SerializeField] private Slider slider;
        [SerializeField] private GameObject player;
        private SliderActionSo action;

        private void Start()
        {
            slider.onValueChanged.AddListener(OnSliderValueChanged);
        }

        public void SetAction(SliderActionSo newAction)
        {
            action = newAction;
        }

        private void OnSliderValueChanged(float value)
        {
            if (action != null)
            {
                action.OnSliderValueChanged(value, player);
            }
            else
            {
                Debug.LogWarning("No action set for this slider");
            }
        }
    }
}