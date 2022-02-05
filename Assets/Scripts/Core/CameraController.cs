using Cinemachine;
using UnityEngine;

namespace Mryildirim.Core
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _rocketmanCamera;

        private void OnEnable()
        {
            EventManager.OnRocketmanLaunched += () => _rocketmanCamera.Priority = 3;
        }

        private void OnDisable()
        {
            EventManager.OnRocketmanLaunched -= () => _rocketmanCamera.Priority = 3;
        }
    }
}

