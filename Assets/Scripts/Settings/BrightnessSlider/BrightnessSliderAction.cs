using UnityEngine;
using UnityEngine.UI;

namespace Settings.BrightnessSlider
{
    public abstract class BrightnessSliderAction : ScriptableObject
    {
        public Slider slider;

        public abstract void OnSliderValueChanged(float value, GameObject player);

    }
}