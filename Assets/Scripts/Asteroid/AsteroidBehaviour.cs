using UnityEngine;
using UnityEngine.Events;

public class AsteroidBehaviour : MonoBehaviour
{
    [Header("Asteroid characteristics")]
    [SerializeField, Min(0.0f)] private float movementSpeed = 5.0f;

    [Header("Spawned small asteroid characteristics")]
    [SerializeField] private GameObject smallAsteroid = null;
    [SerializeField, Min(0.0f)] private float spawnRadius = 1.0f;
    [SerializeField, Min(0)] private int minAmountOfSmallAsteroids = 1;
    [SerializeField, Min(0)] private int maxAmountOfSmallAsteroids = 3;

    private AsteroidMovement movement = null;
    private SmallAsteroidCreator smallAsteroidCreator = null;

    [HideInInspector] public UnityEvent OnHit = null;

    private void Awake()
    {
        movement = new AsteroidMovement();
        smallAsteroidCreator = new SmallAsteroidCreator();
    }

    private void OnEnable()
    {
        OnHit.AddListener(OnHitAsteroid);
    }

    private void Update()
    {
        movement.MoveForward(transform, movementSpeed);
    }

    private void OnDisable()
    {
        OnHit.RemoveListener(OnHitAsteroid);
    }

    private void OnHitAsteroid()
    {
        smallAsteroidCreator.CreateAmountAsteroids(smallAsteroid, transform, minAmountOfSmallAsteroids, maxAmountOfSmallAsteroids, spawnRadius);
    }
}
