using UnityEngine;
using PlayerInputSystem;
using UnityEngine.InputSystem;
using TMPro;

[DisallowMultipleComponent]
class PlayerBehaviour : MonoBehaviour
{
    [Header("Player characteristics")]
    [SerializeField] private PlayerCharacteristics characteristics = null;

    [Header("Bullet settings")]
    [SerializeField] private GameObject bullet = null;
    [SerializeField] private Transform bulletSpawnPoint = null;

    [Header("Laser settings")]
    [SerializeField] private Transform laserSpawnPoint = null;
    [SerializeField] private LayerMask whatIsEnemy;

    [Header("Other components")]
    [SerializeField] private TagManager tagManager = null;
    [SerializeField] private LineRenderer lineRenderer = null;

    [Header("UI components")]
    [SerializeField] private TextMeshProUGUI playerCoordinates = null;
    [SerializeField] private TextMeshProUGUI playerAngle = null;
    [SerializeField] private TextMeshProUGUI playerSpeed = null;
    [SerializeField] private TextMeshProUGUI laserRollbackTime = null;
    [SerializeField] private TextMeshProUGUI laserCharges = null;

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

    private void Start()
    {
        shooting.SetupLaserCharges(characteristics.LaserShots, characteristics.CurrentLaserShots);
    }

    private void OnEnable()
    {
        inputActions.Enable();

        inputActions.Player.MoveForward.started += StartMovement;
        inputActions.Player.MoveForward.canceled += StopMovement;

        inputActions.Player.ShootBullet.performed += ShootBullet;
        inputActions.Player.ShootLaser.performed += ShootLaser;
    }

    private void Update()
    {
        movement.RotatePlayerToMousePoint(transform, out float rotationAngle);
        shooting.CheckLaserCharges(this, characteristics.LaserReloadTime);

        stateVisualizer.ShowPlayerAngles(playerAngle, rotationAngle);
        stateVisualizer.ShowPlayerPosition(playerCoordinates, transform);
        stateVisualizer.ShowPlayerSpeed(playerSpeed, transform);
        stateVisualizer.ShowLaserChargesCount(laserCharges, shooting.Laser—harges);
        stateVisualizer.ShowLaserRollbackTime(laserRollbackTime, shooting.LaserRestoreTime);
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
        inputActions.Player.MoveForward.started -= StartMovement;
        inputActions.Player.MoveForward.canceled -= StopMovement;

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
        shooting.ShootLaser(laserSpawnPoint, this, lineRenderer, whatIsEnemy, characteristics.LaserDistance, characteristics.ShowLaserDelay, characteristics.LaserRollbackTime);
    }

    private void StartMovement(InputAction.CallbackContext obj)
    {
        movement.StartMovement(this, transform, characteristics.MovementSpeed);
    }

    private void StopMovement(InputAction.CallbackContext obj)
    {
        movement.StopMovement(this);
    }
}
