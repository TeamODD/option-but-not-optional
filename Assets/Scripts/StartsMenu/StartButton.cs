using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace StartMenu
{
    public class StartButton : MonoBehaviour
    {
        [Header("이미지")] public Sprite BC;

        public Sprite HI;
        public Sprite AC;

        private SpriteRenderer _renderer;
        private readonly Color aColor = new(80f / 255f, 80f / 255f, 80f / 255f, 255);

        [Header("텍스트 컬러")] private readonly Color bColor = new(0, 0, 0, 255);

        [Header("텍스트")] private GameObject text;

        private TMP_Text tmp_text;

        private void Start()
        {
            text = transform.Find("Text").gameObject;
            tmp_text = text.GetComponent<TMP_Text>();

            _renderer.sprite = BC;
            tmp_text.color = bColor;
        }

        private void OnMouseDown()
        {
            _renderer.sprite = AC;
            text.transform.position -= new Vector3(0, 0.05f, 0);
            tmp_text.color = aColor;
        }

        private void OnMouseEnter()
        {
            _renderer.sprite = HI;
        }

        private void OnMouseExit()
        {
            _renderer.sprite = BC;
        }

        /// <summary>
        ///     TODO : 기능 구현 필요
        /// </summary>
        private void OnMouseUp()
        {
            text.transform.position += new Vector3(0, 0.05f, 0);
            _renderer.sprite = BC;
            tmp_text.color = bColor;
            // 기능 작동 구현할 곳 or 다른 코드에서 실행
            SceneManager.LoadScene("Scene1");
        }

        [RuntimeInitializeOnLoadMethod]
        private static void Initialize()
        {
            var startButton = FindFirstObjectByType<StartButton>();
            if (startButton == null)
            {
                return;
            }

            startButton._renderer = startButton.GetComponent<SpriteRenderer>();
        }
    }
}