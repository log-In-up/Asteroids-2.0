using UnityEngine;
using System.Collections;

class PlayerShooting
{
    private Coroutine showLaser = null;

    public void ShootLaser(Transform origin, LayerMask enemy, float laserDistance, float showLaserDelay)
    {
        RaycastHit2D[] raycastHits = Physics2D.RaycastAll(origin.position, origin.up, laserDistance, enemy.value);

        foreach (RaycastHit2D hit in raycastHits)
        {
            Object.Destroy(hit.collider.gameObject);
        }
    }

    public void ShootBullet(GameObject bullet, Transform spawnPosition)
    {
        Object.Instantiate(bullet, spawnPosition.position, spawnPosition.rotation);
    }

    private IEnumerator ShowAndDisableLaser(float showLaserDelay)
    {
        yield return new WaitForSeconds(showLaserDelay);
    }
}
