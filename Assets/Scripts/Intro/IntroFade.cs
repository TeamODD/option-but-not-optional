using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class IntroFade : MonoBehaviour
{
    [Header("페이드 작동 시간")][SerializeField] private float fadeTime;
    [Header("랜더러")][SerializeField] private SpriteRenderer _renderer;

    private void Awake()
    {
        _renderer.color = new Color(0, 0, 0, 1);
    }

    private void Start()
    {
        _renderer.DOFade(0, fadeTime);
    }
}
