using System.Collections.Generic;
using Player;
using UnityEngine;


public class BreakableWallController : MonoBehaviour
{
    private List<GameObject> walls;

    private void Awake()
    {
        var _walls = FindObjectsByType<BreakableWall>(FindObjectsSortMode.None);
        walls = new List<GameObject>();

        foreach (var item in _walls)
        {
            walls.Add(item.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (collision.collider.gameObject.GetComponent<PlayerController>().ReturnMovePower() >= 6f)
            {
                this.GetComponent<BoxCollider2D>().enabled = false;
                for (int i = 0; i < walls.Count; i++)
                {
                    walls[i].GetComponent<BreakableWall>().BreakTheWalls();
                }
            }
        }
    }
}
