using System.Collections.Generic;
using Settings;
using UnityEngine;

namespace Settings.SubSettings
{
    [CreateAssetMenu(fileName = "ToggleAction", menuName = "ToggleAction")]
    public class EffectToggle : ToggleActionSo
    {
        private List<GameObject> bullet;
        public override void OnToggleValueChanged(bool value, GameObject player)
        {
            FrameRateBullet[] bullets = FindObjectsByType<FrameRateBullet>(FindObjectsSortMode.None);
            bullet = new List<GameObject>();

            foreach (var item in bullets)
            {
                bullet.Add(item.gameObject);
            }
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
                bullet[i].GetComponent<FrameRateBullet>().ColliderOnOff(value);
            }
        }
    }
}
