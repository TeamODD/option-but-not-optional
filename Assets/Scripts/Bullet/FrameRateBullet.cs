using UnityEngine;
using UnityEngine.SceneManagement;

public class FrameRateBullet : MonoBehaviour
{
    [Header("이동 방향")] [SerializeField] private moveDirection direction;
    [Header("감지할 태그")] [SerializeField] private string wallTag = "Floor";
    [Header("속도")] [SerializeField] private float movePower = 5f;
    public bool alpacacaAlive = true;
    private Rigidbody2D _rigid;
    private Vector2 moveVector;
    private Vector3 startPos;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
        switch (direction)
        {
            case moveDirection.up:
                moveVector = new Vector2(0, 1);
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
                Debug.LogErrorFormat("{}오브젝트의 방향이 지정되지 않았습니다.", name);
                break;
        }
    }

    private void Start()
    {
        startPos = transform.position;
        _rigid.AddForce(moveVector * movePower, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("enter");
        if (collision.collider.CompareTag(wallTag))
        {
            if (!alpacacaAlive)
            {
                Destroy(gameObject);
            }

            _rigid.linearVelocity = Vector2.zero;
            transform.position = startPos;
            _rigid.AddForce(moveVector * movePower, ForceMode2D.Impulse);
        }

        if (collision.collider.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            var playerPos = new Vector3(-7f, -1.89f, 0);
            collision.transform.position = playerPos;
        }
    }

    public void ChangeMovePower(float value)
    {
        movePower = 10 * value;
        _rigid.linearVelocity = Vector2.zero;
        _rigid.AddForce(moveVector * movePower, ForceMode2D.Impulse);
    }

    public void ColliderOnOff(bool On)
    {
        if (On)
        {
            GetComponent<BoxCollider2D>().enabled = true;
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }
        else
        {
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        }
    }

    public void DestroyThis()
    {
        Destroy(gameObject);
    }

    private enum moveDirection
    {
        up = 1,
        down = 2,
        left = 3,
        right = 4
    }
}