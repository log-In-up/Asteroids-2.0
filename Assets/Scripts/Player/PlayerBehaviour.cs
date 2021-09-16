using UnityEngine;
using PlayerInputSystem;
using UnityEngine.InputSystem;

class PlayerBehaviour : MonoBehaviour
{
    private PlayerInputActions playerInputActions = null;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();

    }    

    private void OnEnable()
    {
        playerInputActions.Enable();

        playerInputActions.Player.MoveForward.performed += MoveForward;
        playerInputActions.Player.ShootBullet.performed += ShootBullet;
        playerInputActions.Player.ShootLaser.performed += ShootLaser;
    }

    private void OnDisable()
    {
        playerInputActions.Player.MoveForward.performed -= MoveForward;
        playerInputActions.Player.ShootBullet.performed -= ShootBullet;
        playerInputActions.Player.ShootLaser.performed -= ShootLaser;

        playerInputActions.Disable();
    }

    private void ShootLaser(InputAction.CallbackContext inputAction)
    {
        print("I'm shoot laser");
    }

    private void ShootBullet(InputAction.CallbackContext inputAction)
    {
        print("I'm shoot bullet");
    }

    private void MoveForward(InputAction.CallbackContext inputAction)
    {
        print("I'm moving forward.");
    }
}
