using UnityEngine;

[DisallowMultipleComponent]
class SmallAsteroidBehaviour : MonoBehaviour
{
    [Header("Small asteroid characteristics")]
    [SerializeField, Min(0.0f)] private float movementSpeed = 7.5f;

    private AsteroidMovement movement = null;

    private void Awake()
    {
        movement = new AsteroidMovement();
    }

    private void Update()
    {
        movement.MoveForward(transform, movementSpeed);
    }
}
