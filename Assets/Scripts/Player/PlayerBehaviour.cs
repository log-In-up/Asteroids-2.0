using UnityEngine;
using PlayerInputSystem;
using UnityEngine.InputSystem;
using TMPro;

[DisallowMultipleComponent]
class PlayerBehaviour : MonoBehaviour
{
    [Header("Player characteristics")]
    [SerializeField, Min(0.0f)] private float movementSpeed = 5.0f;

    [Header("Other Components")]
    [SerializeField] private GameObject bullet = null;
    [SerializeField] private Transform bulletSpawnPoint = null;

    [Header("UI Components")]
    [SerializeField] private TextMeshProUGUI playerCoordinates = null;
    [SerializeField] private TextMeshProUGUI playerAngle = null;
    [SerializeField] private TextMeshProUGUI playerSpeed = null;

    private PlayerInputActions playerInputActions = null;
    private VisualizePlayerState playerStateVisualizer = null;
    private PlayerMovement playerMovement = null;
    private PlayerShooting playerShooting = null;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerMovement = new PlayerMovement();
        playerShooting = new PlayerShooting();
        playerStateVisualizer = new VisualizePlayerState();
    }

    private void OnEnable()
    {
        playerInputActions.Enable();

        playerInputActions.Player.MoveForward.started += MoveForward;
        playerInputActions.Player.MoveForward.canceled += MoveForward;

        playerInputActions.Player.ShootBullet.performed += ShootBullet;
        playerInputActions.Player.ShootLaser.performed += ShootLaser;
    }

    private void Update()
    {
        playerMovement.RotatePlayerToMousePoint(transform, out float rotationAngle);

        playerStateVisualizer.ShowPlayerAngles(playerAngle, rotationAngle);
        playerStateVisualizer.ShowPlayerPosition(playerCoordinates, transform);
    }

    private void OnDisable()
    {
        playerInputActions.Player.MoveForward.started -= MoveForward;
        playerInputActions.Player.MoveForward.canceled -= MoveForward;

        playerInputActions.Player.ShootBullet.performed -= ShootBullet;
        playerInputActions.Player.ShootLaser.performed -= ShootLaser;

        playerInputActions.Disable();
    }

    private void ShootBullet(InputAction.CallbackContext inputAction)
    {
        playerShooting.ShootBullet(bullet, bulletSpawnPoint);
    }

    private void ShootLaser(InputAction.CallbackContext inputAction)
    {
        playerShooting.ShootLaser();
    }

    private void MoveForward(InputAction.CallbackContext obj)
    {
        playerMovement.MoveForward(transform, movementSpeed);
    }
}
