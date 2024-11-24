using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class StartMenuPlayer : MonoBehaviour
{
    private GameObject firstwall;
    private GameObject secondwall;
    public Animator animator;
    private Vector3 startPos = new Vector3(0, 7, 0);
    private void Awake()
    {
        firstwall = GameObject.FindWithTag("Floor");
        secondwall = GameObject.FindWithTag("tp");
        animator.SetTrigger("Jump");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject == firstwall)
        {
            animator.SetTrigger("Landing");
            StartCoroutine(OnOffWall());
        }
        else if (collision.collider.gameObject == secondwall)
        {
            this.transform.position = startPos;
        }
    }

    private IEnumerator OnOffWall()
    {
        yield return new WaitForSeconds(0.3f);
        animator.SetTrigger("Idle");
        yield return new WaitForSeconds(5f);
        firstwall.GetComponent<BoxCollider2D>().enabled = false;
        animator.SetTrigger("Jump");
        yield return new WaitForSeconds(1f);
        firstwall.GetComponent<BoxCollider2D>().enabled = true;
    }


}
