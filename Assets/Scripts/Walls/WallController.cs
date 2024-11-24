using UnityEngine;

public class WallController : MonoBehaviour
{
    private SpriteRenderer _renderer;

    private void Awake()
    {
        _renderer = this.GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _renderer.color = new Color(1, 1, 1, 0);
    }

    public void ChnageBright(float value)
    {
        _renderer.color = new Color(1, 1, 1, value);
    }
}
