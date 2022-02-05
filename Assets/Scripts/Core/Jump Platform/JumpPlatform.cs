using Mryildirim.Scriptables;
using UnityEngine;

namespace Mryildirim.Core
{
    public abstract class JumpPlatform : MonoBehaviour
    {
        [SerializeField] protected JumpPlatformData _platformData;

        private MeshRenderer _meshRenderer;
        private void Awake()
        {
            _meshRenderer = GetComponent<MeshRenderer>();

            _meshRenderer.material.color = _platformData.PlatformType == PlatformType.Rectangle ? Color.red : Color.blue;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.transform.CompareTag("Rocketman"))
            {
                var rb = other.transform.GetComponent<Rigidbody>();
            
                rb.AddForce(Vector3.up * _platformData.JumpForce, ForceMode.Impulse);
            }
        }
    }  
}

