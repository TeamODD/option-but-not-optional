using UnityEngine;

namespace Settings.SubSettings
{
    public class FrameSliderAction : SliderActionSo
    {
        public GameObject bullet;

        public override void OnSliderValueChanged(float value, GameObject player)
        {
            //적 총알의 프레임을 조절한다.
            //value가 0.5f 이하일 때 총알의 발사 속도를 낮춘다.
            // if (value < 0.5f)
            // {
            //     bullet.GetComponent<Bullet>().frame = 0.5f;
            // }
            // else
            // {
            //     bullet.GetComponent<Bullet>().frame = value;
            // }
        }
    }
}