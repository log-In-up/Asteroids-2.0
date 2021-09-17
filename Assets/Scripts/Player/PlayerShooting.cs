using UnityEngine;

class PlayerShooting
{
    public void ShootLaser()
    {
        Debug.Log("I'm shoot laser");
    }

    public void ShootBullet(GameObject bullet, Transform spawnPosition)
    {
        Object.Instantiate(bullet, spawnPosition.position, spawnPosition.rotation);
    }
}
