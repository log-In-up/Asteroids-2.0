using UnityEngine;

public class ShortLaserBehaviour : MonoBehaviour
{
    [SerializeField, Min(0.0f)] private float movementSpeed = 5.0f;

    private ShortLaserMovement laserMovement = null;

    private void Awake()
    {
        laserMovement = new ShortLaserMovement();
    }

    private void Update()
    {
        laserMovement.MoveForward(transform, movementSpeed);
    }
}
