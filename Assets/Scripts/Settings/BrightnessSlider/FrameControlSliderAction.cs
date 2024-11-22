using UnityEngine;

namespace Settings.BrightnessSlider
{
    public abstract class FrameControlSliderAction : BrightnessSliderAction
    {
        public override void OnSliderValueChanged(float value, GameObject player)
        {
            if (value < 3f)
            {
                Debug.Log("Player speed adjusted. Speed: 1");
            }
        }

        
        
    }
}