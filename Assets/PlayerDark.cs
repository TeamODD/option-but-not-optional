using UnityEngine;
using UnityEngine.UI;

public class PlayerDark : MonoBehaviour
{
    public Image sprite;

    private void Awake()
    {
    }

    private void OnDrawGizmos()
    {
        var player = GameObject.Find("Player");
        if (player == null)
        {
            return;
        }

        var playerPosition = player.transform.position;
        Gizmos.color = new Color(1, 1, 1, 0);
        Gizmos.DrawWireSphere(playerPosition, 1.5f);
    }
}