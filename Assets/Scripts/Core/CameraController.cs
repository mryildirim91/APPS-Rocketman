using Cinemachine;
using UnityEngine;

namespace Mryildirim.Core
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _rocketmanCamera, _sideCamera;

        private void OnEnable()
        {
            EventManager.OnRocketmanLaunched += () =>
            {
                _rocketmanCamera.Priority = 3;
                if(_sideCamera !=null)
                    _sideCamera.gameObject.SetActive(false);
            };
        }

        private void OnDisable()
        {
            EventManager.OnRocketmanLaunched -= () =>
            {
                _rocketmanCamera.Priority = 3;
                if(_sideCamera !=null)
                    _sideCamera.gameObject.SetActive(false);
            };
        }
    }
}

