using TMPro;
using UnityEngine;

namespace Settings.SubSettings
{
    [CreateAssetMenu(fileName = "ShowHint", menuName = "ShowHint")]
    public class ShowHint : ToggleActionSo
    {
        //public TextMeshProUGUI hintText;
        //ScriptableObject는 씬에 종속되지않는 데이터 Asset인데 .. 

        public override void OnToggleValueChanged(bool value, GameObject player)
        {
            if (player == null)
            {
                Debug.LogError("Player GameObject가 null입니다.");
                return;
            }
            //Find 쓰기 싫었는데 아 내일 코드 다시봐야겠다. 

            var canvas = GameObject.Find("Canvas"); // Canvas를 Hierarchy에서 찾음
            if (canvas == null)
            {
                return;
            }

            var hintText = canvas.transform.Find("HintText")?.GetComponent<TextMeshProUGUI>();
            if (hintText == null)
            {
                return;
            }

            if (value)
            {
                Debug.LogWarning("불들어옴");
                hintText.gameObject.SetActive(true);
            }
            else
            {
                hintText.gameObject.SetActive(false);
            }
        }
    }
}