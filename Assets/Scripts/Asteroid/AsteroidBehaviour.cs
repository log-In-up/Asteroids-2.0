using UnityEngine;

public class AsteroidBehaviour : Asteroid
{
    [Header("Spawned small asteroid characteristics")]
    [SerializeField] private GameObject smallAsteroid = null;
    [SerializeField, Min(0.0f)] private float spawnRadius = 1.0f;
    [SerializeField, Min(0)] private int minAmountOfSmallAsteroids = 1;
    [SerializeField, Min(0)] private int maxAmountOfSmallAsteroids = 3;

    private SmallAsteroidCreator smallAsteroidCreator = null; 

    private void Awake()
    {
        smallAsteroidCreator = new SmallAsteroidCreator();
    }

    public override void OnHitAsteroid()
    {
        base.OnHitAsteroid();

        smallAsteroidCreator.CreateAmountAsteroids(smallAsteroid, transform, minAmountOfSmallAsteroids, maxAmountOfSmallAsteroids, spawnRadius);
    }
}
