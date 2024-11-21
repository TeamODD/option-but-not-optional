using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

namespace OBNO.Player
{
    public class PlayerController : MonoBehaviour
    {
        [Header("이동 값")]
        [SerializeField]
        private float movePower = 5f;
        [SerializeField]
        private float jumpPower = 10f;
        [SerializeField]
        private string groundTag = "Floor";

        [Header("내부 계산용")]
        private bool _isJumping = false;
        private int moveTarget;
        private Rigidbody2D rigid;

        // 로딩 시 Rigidbody2D 가져오기
        [RuntimeInitializeOnLoadMethod]
        private static void Initialize()
        {
            var playerController = Object.FindFirstObjectByType<PlayerController>();
            playerController.rigid = playerController.GetComponent<Rigidbody2D>();
            playerController.rigid.freezeRotation = true;
        }

        private void Update()
        {
            if (Input.GetKey("a")) moveTarget = -1;
            else if (Input.GetKey("d")) moveTarget = 1;
            else moveTarget = 0;

            transform.position += new Vector3(moveTarget, 0, 0) * movePower * Time.fixedDeltaTime;

            if (_isJumping) return;
            if (!Input.GetKey("space")) return;
            rigid.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
            _isJumping = true;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            // 바닥에 닿았을 때 점프 상태 해제
            if (!_isJumping) return;
            if (collision.collider.CompareTag(groundTag)) _isJumping = false;
        }
    }
}