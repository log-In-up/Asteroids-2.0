using UnityEngine;
using System.Collections;

class PlayerShooting
{
    private Coroutine showLaser = null;

    public void ShootLaser(Transform origin, MonoBehaviour monoBehaviour, LineRenderer line, LayerMask enemy, float laserDistance, float showLaserDelay)
    {
        int positionCount = 2, firstIndex = 0, secondIndex = 1;

        RaycastHit2D[] raycastHits = Physics2D.RaycastAll(origin.position, origin.up, laserDistance, enemy.value);

        if (showLaser != null)
        {
            monoBehaviour.StopCoroutine(showLaser);
        }
        showLaser = monoBehaviour.StartCoroutine(ShowAndDisableLaser(line, showLaserDelay));

        line.positionCount = positionCount;

        line.SetPosition(firstIndex, new Vector3(origin.position.x, origin.position.y, -0.01f));
        line.SetPosition(secondIndex, origin.up * laserDistance);

        foreach (RaycastHit2D hit in raycastHits)
        {
            Object.Destroy(hit.collider.gameObject);
        }
    }

    public void ShootBullet(GameObject bullet, Transform spawnPosition)
    {
        Object.Instantiate(bullet, spawnPosition.position, spawnPosition.rotation);
    }

    private IEnumerator ShowAndDisableLaser(LineRenderer line, float showLaserDelay)
    {
        line.enabled = true;

        yield return new WaitForSeconds(showLaserDelay);

        line.enabled = false;
    }
}
