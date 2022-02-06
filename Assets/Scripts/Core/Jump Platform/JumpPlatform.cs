using Mryildirim.Scriptables;
using UnityEngine;

namespace Mryildirim.Core
{
    public abstract class JumpPlatform : MonoBehaviour
    {
        private Rocketman _rocketman;
        private JumpPlatformSpawner _platformSpawner;
        [SerializeField] protected JumpPlatformData _platformData;

        private MeshRenderer _meshRenderer;
        private void Awake()
        {
            _rocketman = FindObjectOfType<Rocketman>();
            _platformSpawner = FindObjectOfType<JumpPlatformSpawner>();
            _meshRenderer = GetComponent<MeshRenderer>();
            _meshRenderer.material.color = _platformData.PlatformType == PlatformType.Rectangle ? Color.red : Color.blue;
        }

        private void Update()
        {
            if(transform.position.z < _rocketman.transform.position.z - 30)
                TeleportPlatform();
        }

        private void OnCollisionEnter(Collision other)
        {
            if(GameManager.Instance.IsGameOver) return;
            
            if (other.transform.CompareTag("Rocketman"))
            {
                EventManager.TriggerRocketmanJumped();
                
                var rb = other.transform.GetComponent<Rigidbody>();
                rb.AddForce(new Vector3(0,1f,0.6f) * _platformData.JumpForce, ForceMode.Impulse);
            }
        }

        private void TeleportPlatform()
        {
            float xRange = Random.Range(-60, 60);
            float yRange = Random.Range(5, 20);

            var platformTransform = transform;
            platformTransform.position = new Vector3(xRange, yRange,
                platformTransform.position.z + _platformSpawner.NumberOfPlatform * 45);
        }
    }  
}

