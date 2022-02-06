using UnityEngine;

namespace Mryildirim.Core
{
    public class JumpPlatformSpawner : MonoBehaviour
    {
        [SerializeField] private int _numberOfPlatforms;
        [SerializeField] private GameObject _rectanglePlatform, _cylinderPlatform;

        public int NumberOfPlatform => _numberOfPlatforms;

        private void Start()
        {
            SpawnPlatform();
        }

        private void SpawnPlatform()
        {
            for (int i = 0; i < _numberOfPlatforms; i++)
            {
                float randomNumber = Random.Range(1, 10);
                var platform = Instantiate(randomNumber < 5 ? _cylinderPlatform : _rectanglePlatform, transform, true);
                platform.transform.position = GetPlatformLocation(i);
            }
        }

        private Vector3 GetPlatformLocation(int z)
        {
            float xRange = Random.Range(-60, 60);
            float yRange = Random.Range(5, 20);

            var location = new Vector3(xRange, yRange, z * 45 + 45);
            return location;
        }
    }
}

