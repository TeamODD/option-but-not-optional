using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;

public class Alpacapaca : MonoBehaviour
{
    [Header("프리팹")] public GameObject leftBullet;
    private List<GameObject> bullets;

    private Vector3 startPos = new Vector3(3.69f, -2.72f, 0);

    private void Start()
    {
        StartCoroutine(FireNBullet(2));
    }

    private IEnumerator FireNBullet(int number)
    {
        for (int i = 0; i < number; i++)
        {
            Instantiate(leftBullet, startPos, quaternion.Euler(Vector3.zero));
            yield return new WaitForSeconds(1f);
        }

        FrameRateBullet[] _bullets = FindObjectsByType<FrameRateBullet>(FindObjectsSortMode.None);
        bullets = new List<GameObject>();

        for (int i = 0; i < _bullets.Count(); i++)
        {
            bullets.Add(_bullets[i].gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            foreach (ContactPoint2D contact in collision.contacts)
            {
                Vector2 collisionDirection = contact.normal;

                if (collisionDirection.y < 0.5f)
                {
                    for (int i = 0; i < bullets.Count; i++)
                    {
                        bullets[i].GetComponent<FrameRateBullet>().alpacacaAlive = false;
                    }
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
