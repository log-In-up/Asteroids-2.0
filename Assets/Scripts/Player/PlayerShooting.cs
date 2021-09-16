using UnityEngine;
using UnityEngine.InputSystem;

class PlayerShooting
{
    public static void ShootLaser(InputAction.CallbackContext inputAction)
    {
        Debug.Log("I'm shoot laser");
    }

    public static void ShootBullet(InputAction.CallbackContext inputAction)
    {
        Debug.Log("I'm shoot bullet");
    }
}
