using UnityEngine;
using UnityEngine.SceneManagement;

namespace Enemys.Rabbits
{
    public class BlackRabbit : MonoBehaviour
    {
        public bool checkVolume = true;
        private Animator _animator;
        private BoxCollider2D _boxCollider2D;

        private EnemyState _enemyState = EnemyState.Idle;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _boxCollider2D = GetComponent<BoxCollider2D>();
        }

        private void Update()
        {
            if (checkVolume)
            {
                EnemyStateChange();
                _boxCollider2D.isTrigger = false;
            }
            else
            {
                _boxCollider2D.isTrigger = true;
                _animator.Play("BlackRabbitAnimation_Idle");
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player") && checkVolume)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                var playerPos = new Vector3(-7f, -1.89f, 0);
                other.transform.position = playerPos;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player") && checkVolume)
            {
                _animator.SetTrigger("Detect");
                _enemyState = EnemyState.Detect;
                //checkVolume = false;
            }
        }

        private void EnemyStateChange()
        {
            switch (_enemyState)
            {
                case EnemyState.Idle:
                    _animator.Play("BlackRabbitAnimation_Idle");
                    //FixedPosition
                    break;
                case EnemyState.Detect:
                    //FollowPlayer; 
                    transform.position += Vector3.left * (Time.deltaTime * 3f);
                    _animator.SetTrigger("Detect");
                    break;
                case EnemyState.Attack:
                    //GameOver 
                    break;
            }
        }

        private enum EnemyState
        {
            Idle,
            Detect,
            Attack
        }
    }
}