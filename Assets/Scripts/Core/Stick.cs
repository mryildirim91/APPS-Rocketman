using UnityEngine;

namespace Mryildirim.Core
{
    public class Stick : MonoBehaviour
    {
        private Animator _animator;
        private static readonly int Release = Animator.StringToHash("Release");
    
        public float Force { get; private set; } = 1;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }
    
        private void Update()
        {
            LaunchRocketman();
        }

        private void LaunchRocketman()
        {
            if(Rocketman.IsLaunched) return;
        
            if (Input.GetMouseButtonDown(0))
            {
                _animator.Play("Bend", -1, 0f);
            }

            if (Input.GetMouseButton(0))
            {
                if(Force >= 3) return;
                Force += Time.deltaTime;
            }
        
            if (Input.GetMouseButtonUp(0))
            {
                _animator.SetTrigger(Release);
            }
        }
    }
}

