using DG.Tweening;
using UnityEngine;

public class RocketmanRotation : MonoBehaviour
{
    [SerializeField] private float _rotateForce;
    private void Update()
    { 
        if(GameManager.Instance.IsGameOver) return;
        Rotate();
    }

    private void Rotate()
    {
        if(!Rocketman.IsLaunched ) return;

        if (Input.GetMouseButton(0) && Rocketman.IsFloating)
        {
            transform.DORotate(Vector3.right * 80, 1);
            return;
        }
        
        transform.RotateAround(transform.position, Vector3.right,_rotateForce * Time.deltaTime);
    }
}
