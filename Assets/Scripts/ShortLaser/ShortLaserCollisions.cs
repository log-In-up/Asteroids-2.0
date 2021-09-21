using UnityEngine;

class ShortLaserCollisions
{
    public void HandleCollisionWithAsteroid(Collider2D collision)
    {
        if (collision.TryGetComponent(out Asteroid asteroid))
        {
            asteroid.OnHit.Invoke();
        }

        DestroyObject(collision.gameObject);
    }

    public void HandleCollisionWithEnemy(Collider2D collision)
    {
        if (collision.TryGetComponent(out EnemyBehaviour enemyBehaviour))
        {
            enemyBehaviour.OnHit.Invoke();
        }

        DestroyObject(collision.gameObject);
    }

    public void DestroyObject(GameObject gameObj)
    {
        Object.Destroy(gameObj);
    }
}
