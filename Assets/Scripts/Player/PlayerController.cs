using System.Collections;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [Header("이동 값")] [SerializeField] private float movePower = 5f;

        [SerializeField] private float jumpPower = 10f;

        [SerializeField] private string groundTag = "Floor";

        [Header("내부 계산용")] [SerializeField] private bool _isJumping;
        private Animator animator;
        private bool landed;

        private int moveTarget;
        private Rigidbody2D rigid;


        /// <summary>
        ///     InputSystem으로 변경하기
        /// </summary>
        private void Awake()
        {
            animator = GetComponent<Animator>();
            rigid = GetComponent<Rigidbody2D>();
            DontDestroyOnLoad(gameObject);
        }

        private void Update()
        {
            if (Input.GetKey("a"))
            {
                moveTarget = -1;
                transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
                ControlMoveAnimation("Move");
            }
            else if (Input.GetKey("d"))
            {
                moveTarget = 1;
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                ControlMoveAnimation("Move");
            }
            else
            {
                moveTarget = 0;
                ControlMoveAnimation("Idle");
            }

            var moveVec = new Vector2(moveTarget, 0) * movePower;
            moveVec.y = rigid.linearVelocityY;
            rigid.linearVelocity = moveVec;

            if (_isJumping)
            {
                return;
            }

            if (!Input.GetKey("space"))
            {
                return;
            }

            animator.ResetTrigger("Move");
            animator.ResetTrigger("Idle");
            animator.SetTrigger("Jump");
            rigid.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
            _isJumping = true;
            landed = false;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!_isJumping)
            {
                return;
            }

            if (collision.collider.CompareTag(groundTag))
            {
                animator.ResetTrigger("Jump");
                animator.SetTrigger("Landing");
                landed = true;
                StartCoroutine(LandingAnimation());
            }
        }

        private void ControlMoveAnimation(string target)
        {
            if (_isJumping)
            {
                if (landed && target == "Move")
                {
                    animator.SetTrigger(target);
                    StopAllCoroutines();
                    _isJumping = false;
                }
            }
            else
            {
                animator.SetTrigger(target);
            }
        }

        private IEnumerator LandingAnimation()
        {
            yield return new WaitForSecondsRealtime(0.3f);

            _isJumping = false;
        }

        public void ChangeMovePower(float value)
        {
            movePower = 6 * value;
            Debug.Log("MovePower : " + movePower);
        }

        // 로딩 시 Rigidbody2D 가져오기
        [RuntimeInitializeOnLoadMethod]
        private static void Initialize()
        {
            var playerController = FindFirstObjectByType<PlayerController>();
            if (playerController == null)
            {
                return;
            }

            playerController.rigid = playerController.GetComponent<Rigidbody2D>();
            playerController.rigid.freezeRotation = true;

            playerController.animator = playerController.GetComponent<Animator>();
        }
    }
}