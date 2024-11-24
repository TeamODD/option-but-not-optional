using UnityEngine;

namespace Settings.SubSettings.Slider
{
    [CreateAssetMenu(fileName = "VisibilityControlAction", menuName = "VisibilityControlAction")]
    public class VisibilityControlAction : SliderActionSo
    {
        public override void OnSliderValueChanged(float value, GameObject player)
        {
            var _nextStage = GameObject.FindGameObjectWithTag("NextStage");
            if (_nextStage != null)
            {
                _nextStage.transform.position -= new Vector3(15 * value, 0, 0);
            }
            else
            {
                Debug.LogWarning("NextStage object is not assigned.");
            }
        }
    }
}