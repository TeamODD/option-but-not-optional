using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class Alpacapaca : MonoBehaviour
{
    [Header("프리팹")] public GameObject leftBullet;

    private Vector3 startPos = new Vector3(3.69f, -2.72f, 0);

    private void Start()
    {
        StartCoroutine(FireNBullet(3));
    }

    private IEnumerator FireNBullet(int number)
    {
        for (int i = 0; i < number; i++)
        {
            Instantiate(leftBullet, startPos, quaternion.Euler(Vector3.zero));
            yield return new WaitForSeconds(0.3f);
        }
    }
}
