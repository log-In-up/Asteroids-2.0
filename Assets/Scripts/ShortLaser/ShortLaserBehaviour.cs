using UnityEngine;

[DisallowMultipleComponent]
class ShortLaserBehaviour : MonoBehaviour
{
    [SerializeField, Min(0.0f)] private float movementSpeed = 5.0f;
    [SerializeField] private TagManager tagManager = null;

    private ShortLaserMovement movement = null;
    private ShortLaserCollisions collisions = null;

    private void Awake()
    {
        movement = new ShortLaserMovement();
        collisions = new ShortLaserCollisions();
    }

    private void Update()
    {
        movement.MoveForward(transform, movementSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(tagManager.Asteroid))
        {
            collisions.HandleCollisionWithAsteroid(collision);
        }

        if(collision.CompareTag(tagManager.Enemy))
        {
            collisions.HandleCollisionWithEnemy(collision);
        }

        collisions.DestroyObject(gameObject);
    }
}
