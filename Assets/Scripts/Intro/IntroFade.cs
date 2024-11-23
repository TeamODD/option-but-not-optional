using Unity.VisualScripting;
using UnityEngine;

public class IntroFade : MonoBehaviour
{
    [Header("페이드 작동 시간")][SerializeField] private float fadeTime;
    private SpriteRenderer _renderer;

    [RuntimeInitializeOnLoadMethod]
    private static void Initialize()
    {
        var fade = FindFirstObjectByType<IntroFade>();
        if (fade == null)
        {
            return;
        }

        fade._renderer = fade.GetComponent<SpriteRenderer>();
    }

    private void Awake()
    {
        _renderer.color = new Color(0, 0, 0, 0);
    }

    private void Start()
    {

    }
}
