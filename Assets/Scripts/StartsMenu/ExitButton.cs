using UnityEditor;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    [Header("버튼 이미지")] public Sprite BC;

    public Sprite HI;
    public Sprite AC;

    [Header("텍스트")] public GameObject text;

    private SpriteRenderer _renderer;

    private void Start()
    {
        _renderer.sprite = BC;
    }

    private void OnMouseDown()
    {
        _renderer.sprite = AC;
        text.transform.position -= new Vector3(0, 0.05f, 0);
        return;
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
#endif
    }

    private void OnMouseEnter()
    {
        _renderer.sprite = HI;
    }

    private void OnMouseExit()
    {
        _renderer.sprite = BC;
    }

    private void OnMouseUp()
    {
        text.transform.position += new Vector3(0, 0.05f, 0);
        _renderer.sprite = BC;
    }

    [RuntimeInitializeOnLoadMethod]
    private static void Initialize()
    {
        var exitbutton = FindFirstObjectByType<ExitButton>();
        if (exitbutton == null)
        {
            return;
        }

        exitbutton._renderer = exitbutton?.GetComponent<SpriteRenderer>();
    }
}