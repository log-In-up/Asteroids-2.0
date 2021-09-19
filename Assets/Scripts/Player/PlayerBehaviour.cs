using UnityEngine;
using PlayerInputSystem;
using UnityEngine.InputSystem;
using TMPro;

[DisallowMultipleComponent]
class PlayerBehaviour : MonoBehaviour
{
    [Header("Player characteristics")]
    [SerializeField, Min(0.0f)] private float movementSpeed = 5.0f;

    [Header("Bullet settings")]
    [SerializeField] private GameObject bullet = null;
    [SerializeField] private Transform bulletSpawnPoint = null;

    [Header("Laser settings")]
    [SerializeField, Min(0.0f)] private float laserDistance = 50.0f;
    [SerializeField, Min(0.0f)] private float showLaserDelay = 0.2f;
    [SerializeField] private Transform laserSpawnPoint = null;
    [SerializeField] private LayerMask whatIsEnemy;

    [Header("Other components")]
    [SerializeField] private TagManager tagManager = null;

    [Header("UI components")]
    [SerializeField] private TextMeshProUGUI playerCoordinates = null;
    [SerializeField] private TextMeshProUGUI playerAngle = null;
    [SerializeField] private TextMeshProUGUI playerSpeed = null;

    private PlayerInputActions inputActions = null;
    private VisualizePlayerState stateVisualizer = null;
    private PlayerMovement movement = null;
    private PlayerShooting shooting = null;
    private PlayerCollisions collisions = null;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
        movement = new PlayerMovement();
        shooting = new PlayerShooting();
        stateVisualizer = new VisualizePlayerState();
        collisions = new PlayerCollisions();
    }

    private void OnEnable()
    {
        inputActions.Enable();

        inputActions.Player.MoveForward.started += MoveForward;
        inputActions.Player.MoveForward.canceled += MoveForward;

        inputActions.Player.ShootBullet.performed += ShootBullet;
        inputActions.Player.ShootLaser.performed += ShootLaser;
    }

    private void Update()
    {
        movement.RotatePlayerToMousePoint(transform, out float rotationAngle);

        stateVisualizer.ShowPlayerAngles(playerAngle, rotationAngle);
        stateVisualizer.ShowPlayerPosition(playerCoordinates, transform);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(tagManager.Asteroid) || collision.CompareTag(tagManager.Enemy))
        {
            collisions.FinishTheGame();
        }
    }

    private void OnDisable()
    {
        inputActions.Player.MoveForward.started -= MoveForward;
        inputActions.Player.MoveForward.canceled -= MoveForward;

        inputActions.Player.ShootBullet.performed -= ShootBullet;
        inputActions.Player.ShootLaser.performed -= ShootLaser;

        inputActions.Disable();
    }

    private void ShootBullet(InputAction.CallbackContext inputAction)
    {
        shooting.ShootBullet(bullet, bulletSpawnPoint);
    }

    private void ShootLaser(InputAction.CallbackContext inputAction)
    {
        shooting.ShootLaser(laserSpawnPoint, whatIsEnemy, laserDistance, showLaserDelay);
    }

    private void MoveForward(InputAction.CallbackContext obj)
    {
        movement.MoveForward(transform, movementSpeed);
    }
}
