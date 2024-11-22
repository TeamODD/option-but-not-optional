using UnityEngine;

public class ExitButton : MonoBehaviour
{
    [Header("버튼 이미지")]
    public Sprite BC;
    public Sprite HI;
    public Sprite AC;

    private SpriteRenderer _renderer;

    [RuntimeInitializeOnLoadMethod]
    private static void Initialize()
    {
        var exitbutton = FindFirstObjectByType<ExitButton>();
        exitbutton._renderer = exitbutton.GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _renderer.sprite = BC;
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
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
#endif
    }
}
