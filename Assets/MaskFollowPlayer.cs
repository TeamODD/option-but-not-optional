using Player;
using UnityEngine;

public class MaskFollowPlayer : MonoBehaviour
{
    private Transform player;

    private void Awake()
    {
        var playerController = FindObjectOfType<PlayerController>();
        if (playerController != null)
        {
            player = playerController.transform;
        }
    }


    private void Update()
    {
        if (player != null)
        {
            transform.position = player.position;
        }
    }
}