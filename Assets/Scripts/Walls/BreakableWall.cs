using Unity.VisualScripting;
using UnityEngine;

public class BreakableWall : MonoBehaviour
{
    public void Awake()
    {
        this.GetComponent<BoxCollider2D>().enabled = false;
    }

    public void BreakTheWalls()
    {
        this.transform.SetParent(null);
        this.GetComponent<BoxCollider2D>().enabled = true;
        this.AddComponent<Rigidbody2D>();
        this.GetComponent<Rigidbody2D>().AddForce(new Vector2(10, 0));
    }
}
