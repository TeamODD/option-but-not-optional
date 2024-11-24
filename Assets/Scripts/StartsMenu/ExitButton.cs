using TMPro;
using UnityEngine;


public class ExitButton : MonoBehaviour
{
    [Header("버튼 이미지")]
    public Sprite BC;
    public Sprite HI;
    public Sprite AC;

    [Header("텍스트")]
    private GameObject text;
    private TMP_Text tmp_text;

    private SpriteRenderer _renderer;

    [Header("텍스트 컬러")]
    private Color bColor = new Color(0, 0, 0, 255);
    private Color aColor = new Color(80f / 255f, 80f / 255f, 80f / 255f, 255);

    private void Awake()
    {
        text = this.transform.Find("Text").gameObject;
        _renderer = this.GetComponent<SpriteRenderer>();
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
        text.transform.position -= new Vector3(0, 0.05f, 0);
    }

    private void OnMouseUp()
    {
        text.transform.position += new Vector3(0, 0.05f, 0);
        _renderer.sprite = BC;
        tmp_text.color = bColor;
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
#endif
    }
}
