using TMPro;
using UnityEngine;
using UnityEngine.Rendering.UI;
namespace StartMenu
{
    public class StartButton : MonoBehaviour
    {
        [Header("이미지")]
        public Sprite BC;
        public Sprite HI;
        public Sprite AC;

        [Header("텍스트")]
        public GameObject text;
        private TMP_Text tmp_text;

        [Header("텍스트 컬러")]
        private Color bColor = new Color(0, 0, 0, 255);
        private Color aColor = new Color(80f / 255f, 80f / 255f, 80f / 255f, 255);

        private SpriteRenderer _renderer;

        [RuntimeInitializeOnLoadMethod]
        private static void Initialize()
        {
            var startButton = FindFirstObjectByType<StartButton>();
            if (startButton == null) return;
            startButton._renderer = startButton.GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            tmp_text = text.GetComponent<TMP_Text>();
            _renderer.sprite = BC;
            tmp_text.color = bColor;
        }

        private void OnMouseEnter()
        {
            _renderer.sprite = HI;
        }

        private void OnMouseExit()
        {
            _renderer.sprite = BC;
        }

        private void OnMouseDown()
        {
            _renderer.sprite = AC;
            text.transform.position -= new Vector3(0, 0.05f, 0);
            tmp_text.color = aColor;
        }

        /// <summary>
        /// TODO : 기능 구현 필요
        /// </summary>
        private void OnMouseUp()
        {
            text.transform.position += new Vector3(0, 0.05f, 0);
            _renderer.sprite = BC;
            tmp_text.color = bColor;
            // 기능 작동 구현할 곳
        }
    }
}
