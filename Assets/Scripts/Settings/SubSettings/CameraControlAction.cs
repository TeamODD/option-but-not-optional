using UnityEngine;

namespace Settings.SubSettings
{
    [CreateAssetMenu(fileName = "CameraControlAction", menuName = "CameraControlAction")]
    public class CameraControlAction : SliderActionSo
    {
        private Camera main_Camera;


        public override void OnSliderValueChanged(float value, GameObject player)
        {
            // main_Camera가 null이라면 자동으로 카메라를 찾음
            if (main_Camera == null)
            {
                main_Camera = Camera.main; // Main Camera 찾기
                if (main_Camera == null)
                {
                    Debug.LogError("Main Camera not found!");
                    return;
                }
            }

            main_Camera.GetComponent<Transform>().position = new Vector3(0, 0, -15 + value * -10f);
        }
    }
}