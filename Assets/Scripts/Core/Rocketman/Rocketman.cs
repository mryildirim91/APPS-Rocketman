using System.Collections;
using DG.Tweening;
using Mryildirim.Utilities;
using UnityEngine;

namespace Mryildirim.Core
{ 
    public class Rocketman : MonoBehaviour
    {
        [SerializeField] private float _launchForce, _rotateForce, _steerForce,_speed;
        [SerializeField] private Stick _stick;
        private Rigidbody _rigidbody;
        private Touch _touch;
        private Vector3 _touchPosition;
        private Quaternion _yRotation;
        public static bool IsLaunched { get; private set; }
        public static bool IsFloating { get; private set; }
        public static bool HasJumped { get; private set; }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();

            IsLaunched = false;
            IsFloating = false;
            HasJumped = false;
        }

        private void OnEnable()
        {
            EventManager.OnRocketmanLaunched += Launch;
            EventManager.OnRocketmanJumped += Jump;
        }
        
        private void OnDisable()
        {
            EventManager.OnRocketmanLaunched -= Launch;
            EventManager.OnRocketmanJumped -= Jump;
        }

        private void Update()
        {
            if(GameManager.Instance.IsGameOver) return;
            
            Float();

            if (IsLaunched && transform.position.z > 0)
                ScoreManager.SetScore((int)transform.position.z);

        }

        private void FixedUpdate()
        {
            if(GameManager.Instance.IsGameOver) return;
            
            RotateAround();
            Steer();

        }

        private void OnCollisionEnter(Collision other)
        {
            if(other.transform.CompareTag("Ground"))
                GameManager.Instance.GameOver();
        }

        private void Jump()
        {
            StartCoroutine(JumpRoutine());
        }

        private IEnumerator JumpRoutine()
        {
            HasJumped = true;
            IsFloating = false;
            yield return new WaitForSeconds(2);
            HasJumped = false;
        }
        
        private void Launch()
        {
            IsLaunched = true;

            if(transform.parent != null)
                transform.SetParent(null);

            _rigidbody.isKinematic = false;
            var direction = new Vector3(0, 0.7f, 1f) * _launchForce * _stick.Force;
            _rigidbody.AddForce(direction, ForceMode.Impulse);
        }

        private void Float()
        {
            if(!IsLaunched || HasJumped) return;

            if (Input.GetMouseButtonDown(0))
            {
                IsFloating = true;
                _rigidbody.DORotate(Vector3.right * 90, 0.7f);
            }
            if (Input.GetMouseButtonUp(0))
                IsFloating = false;
        }
        private void RotateAround()
        {
            if (!IsFloating && IsLaunched)
            {
                var deltaRotation = Quaternion.Euler(transform.right * Time.fixedDeltaTime * _rotateForce);
                _rigidbody.MoveRotation(_rigidbody.rotation * deltaRotation);
            }
        }
        
        private void Steer()
        {
            if (!IsFloating) return;

            if (Input.touchCount <= 0) return;
            _touch = Input.GetTouch(0);

            if (_touch.phase != TouchPhase.Moved) return;
            
            _yRotation = Quaternion.Euler(Vector3.down * _touch.deltaPosition.x * _steerForce * Time.fixedDeltaTime);
            _rigidbody.MoveRotation(_rigidbody.rotation * _yRotation);
            _rigidbody.velocity += Vector3.right * Time.fixedDeltaTime * _speed * _touch.deltaPosition.x;
        }
    } 
}

