using Mryildirim.Utilities;
using UnityEngine;

namespace Mryildirim.Core
{
    public class JumpPlatformSpawner : MonoBehaviour
    {
        [SerializeField] private int _numberOfPlatforms;
        [SerializeField] private GameObject _rectanglePlatform, _cylinderPlatform;

        private void Start()
        {
            SpawnPlatform();
        }

        private void SpawnPlatform()
        {
            for (int i = 0; i < _numberOfPlatforms; i++)
            {
                var randomNumber = Random.Range(1, 11);
                var platform = ObjectPool.Instance.GetObject(randomNumber < 4 ? _cylinderPlatform : _rectanglePlatform);
                platform.transform.position = GetPlatformLocation(i);
                platform.transform.SetParent(transform);
            }
        }

        private Vector3 GetPlatformLocation(int z)
        {
            float xRange = Random.Range(-50, 50);
            float yRange = Random.Range(-20, -17);
            float zRange = Random.Range(35, 50);

            var location = new Vector3(xRange, yRange, z*zRange + zRange);
            return location;
        }
    }
}

