using UnityEngine;
using UnityEngine.Events;

[DisallowMultipleComponent]
public class Asteroid : MonoBehaviour
{
    [Header("Asteroid characteristics")]
    [SerializeField, Min(0.0f)] private float movementSpeed = 5.0f;
    [SerializeField, Min(0)] private int pointsForDestroy = 2;

    private AsteroidMovement movement = null;
    private GameManager gameManager = null;

    [HideInInspector] public UnityEvent OnHit = null;

    private void OnEnable()
    {
        OnHit.AddListener(OnHitAsteroid);
    }

    private void Start()
    {
        movement = new AsteroidMovement();

        gameManager = (GameManager)FindObjectOfType(typeof(GameManager));
    }

    private void Update()
    {
        movement.MoveForward(transform, movementSpeed);        
    }

    private void OnDisable()
    {
        OnHit.RemoveListener(OnHitAsteroid);
    }

    public virtual void OnHitAsteroid()
    {
        gameManager.AddPoints.Invoke(pointsForDestroy);
    }
}
