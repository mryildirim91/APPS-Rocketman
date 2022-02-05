using UnityEngine;

namespace Mryildirim.Core
{ 
    public class Rocketman : MonoBehaviour
    {
        [SerializeField] private float _force, _speed, _steerLimit;
        [SerializeField] private Stick _stick;
        private Rigidbody _rigidbody;
        private Camera _camera;
        private Vector3 _startPosition;
        public static bool IsLaunched { get; private set; }
        public static bool IsFloating { get; private set; }
    
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>(); 
            _camera = Camera.main;
        }

        private void OnEnable()
    
        {
            EventManager.OnRocketmanLaunched += Launch;
        }
        
        private void OnDisable()
        {
            EventManager.OnRocketmanLaunched -= Launch;
        }

        private void Update()
        {
            if(GameManager.Instance.IsGameOver) return;

            Float();

            if (IsFloating)
                Steer();
        }

        private void OnCollisionEnter(Collision other)
        {
            if(other.transform.CompareTag("Ground"))
                GameManager.Instance.GameOver();
        }

        private void Launch()
        {
            IsLaunched = true;

            if(transform.parent != null)
                transform.SetParent(null);

            _rigidbody.isKinematic = false;
            var direction = new Vector3(0, 1, 0.5f) * _force * _stick.Force;
            _rigidbody.AddForce(direction, ForceMode.Impulse);
        }

        private void Float()
        {
            if(!IsLaunched) return;

            if (Input.GetMouseButtonDown(0))
            {
                IsFloating = true;
                _startPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
                _rigidbody.mass = 1;
            }

            if (Input.GetMouseButtonUp(0))
            {
                IsFloating = false;
                _rigidbody.mass *= 5;
            }
        }

        private void Steer()
        {
            transform.Translate(transform.forward * Time.deltaTime * _speed);

            /*if (Input.GetMouseButton(0))
            {
                var endPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
                var xPosition = _startPosition.x - endPosition.x;
                var direction = 0;
                
                if (xPosition < 0)
                {
                    direction = -1;
                }
                else
                {
                    direction = 1;
                }
    
                var rotation = Vector3.up * _steerLimit * Time.deltaTime * direction;
                
                transform.DORotate(rotation, 1);
            }*/
        }
    } 
}

