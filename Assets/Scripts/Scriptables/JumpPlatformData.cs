using UnityEngine;

namespace Mryildirim.Scriptables
{
    [CreateAssetMenu(menuName = "Jump Platform", fileName = "Jump Platfom")]
    public class JumpPlatformData : ScriptableObject
    {
        [SerializeField] private float _jumpForce;
        [SerializeField] private PlatformType _platformType;

        public float JumpForce => _jumpForce;
        public PlatformType PlatformType => _platformType;
    }

    public enum PlatformType
    {
        Rectangle,
        Cylinder
    }
}


