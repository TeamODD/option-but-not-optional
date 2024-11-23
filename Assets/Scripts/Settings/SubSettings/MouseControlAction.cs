using UnityEngine;

namespace Settings.SubSettings
{
    public class MouseControlAction : SliderActionSo
    {
        public override void OnSliderValueChanged(float value, GameObject player)
        {
            //value에 비례하여 마우스 포인터 객체의 크기를 조절한다. 
            //player.GetComponent<MousePointer>().ChangeSize(value);
        }
    }
}