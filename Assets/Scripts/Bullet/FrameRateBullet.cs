using System;
using UnityEngine;

public class FrameRateBullet : MonoBehaviour
{
    [Header("이동 방향")][SerializeField] private moveDirection direction;
    [Header("감지할 태그")][SerializeField] private string wallTag = "Floor";
    [Header("속도")][SerializeField] private float movePower = 5f;
    private Vector2 moveVector;
    private Vector3 startPos;
    private Rigidbody2D _rigid;
    public bool alpacacaAlive = true;

    private void Awake()
    {
        _rigid = this.GetComponent<Rigidbody2D>();
        switch (direction)
        {
            case moveDirection.up:
                moveVector = new Vector2(0, 1);
                // this.transform.rotation = 
                break;
            case moveDirection.down:
                moveVector = new Vector2(0, -1);
                break;
            case moveDirection.left:
                moveVector = new Vector2(-1, 0);
                break;
            case moveDirection.right:
                moveVector = new Vector2(1, 0);
                break;
            default:
                Debug.LogErrorFormat("{}오브젝트의 방향이 지정되지 않았습니다.", this.name);
                break;
        }

    }

    private void Start()
    {
        startPos = this.transform.position;
        _rigid.AddForce(moveVector * movePower, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("enter");
        if (collision.collider.CompareTag(wallTag))
        {
            if (!alpacacaAlive) Destroy(this.gameObject);
            _rigid.linearVelocity = Vector2.zero;
            this.transform.position = startPos;
            _rigid.AddForce(moveVector * movePower, ForceMode2D.Impulse);
        }
        if (collision.collider.CompareTag("Player"))
        {
            // 재시작 
        }
    }

    public void ChangeMovePower(float value)
    {
        this.movePower = 10 * value;
        _rigid.linearVelocity = Vector2.zero;
        _rigid.AddForce(moveVector * movePower, ForceMode2D.Impulse);
    }

    public void ColliderOnOff(bool On)
    {
        if (On == true)
        {
            this.GetComponent<BoxCollider2D>().enabled = true;
            this.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1);
        }
        else
        {
            this.GetComponent<BoxCollider2D>().enabled = false;
            this.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        }
    }

    public void DestroyThis()
    {
        Destroy(this.gameObject);
    }

    private enum moveDirection
    {
        up = 1,
        down = 2,
        left = 3,
        right = 4
    }
}
