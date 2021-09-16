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

        playerInputActions.Player.MoveForward.performed += PlayerMovement.MoveForward;
        playerInputActions.Player.ShootBullet.performed += PlayerShooting.ShootBullet;
        playerInputActions.Player.ShootLaser.performed += PlayerShooting.ShootLaser;
    }

    private void Update()
    {
        PlayerMovement.RotatePlayerToMousePoint(transform);
    }

    private void OnDisable()
    {
        playerInputActions.Player.MoveForward.performed -= PlayerMovement.MoveForward;
        playerInputActions.Player.ShootBullet.performed -= PlayerShooting.ShootBullet;
        playerInputActions.Player.ShootLaser.performed -= PlayerShooting.ShootLaser;

        playerInputActions.Disable();
    }
}
