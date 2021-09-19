using UnityEngine;

class ShortLaserCollisions
{
    public void HandleCollisionWithAsteroid(GameObject asteroid, Collider2D collision)
    {
        if (collision.TryGetComponent(out AsteroidBehaviour component))
        {
            component.OnHit.Invoke();
        }

        Object.Destroy(asteroid);
    }

    public void HandleCollisionWithEnemy(GameObject enemy)
    {
        Object.Destroy(enemy);
    }

    public void DestroyYourself(GameObject laser)
    {
        Object.Destroy(laser);
    }
}
