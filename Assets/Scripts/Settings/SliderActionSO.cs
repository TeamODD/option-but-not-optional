using UnityEngine;

namespace Settings
{
    //슬라이더 동작의 추상클래스 정의
    public abstract class SliderActionSo : ScriptableObject
    {
        public abstract void OnSliderValueChanged(float value, GameObject player);
    }
}