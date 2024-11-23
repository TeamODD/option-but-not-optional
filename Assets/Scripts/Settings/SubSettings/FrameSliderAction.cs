using System.Collections.Generic;
using UnityEngine;

namespace Settings.SubSettings
{
    public class FrameSliderAction : SliderActionSo
    {
        private List<GameObject> bullet;

        private void Start()
        {
            FrameRateBullet[] bullets = FindObjectsByType<FrameRateBullet>(FindObjectsSortMode.None);
            bullet = new List<GameObject>();

            foreach (var item in bullets)
            {
                bullet.Add(item.gameObject);
            }
        }

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
            for (int i = 0; i < bullet.Count; i++)
            {
                bullet[i].GetComponent<FrameRateBullet>().ChangeMovePower(value);
            }
        }
    }
}