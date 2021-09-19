using UnityEngine;

[DisallowMultipleComponent]
class EntityCreatorBehaviour : MonoBehaviour
{
    [Header("Asteroid spawn settings")]
    [SerializeField] private GameObject asteroid = null;
    [SerializeField] private Transform asteroidLookatPosition = null;
    [SerializeField] private float minAngle = -10.0f;
    [SerializeField] private float maxAngle = 10.0f;

    [Header("Enemy spawn settings")]
    [SerializeField] private GameObject enemy = null;

    [Header("Common spawn settings")]
    [SerializeField, Range(0.0f, 100.0f)] private float enemySpawnChance = 25.0f;
    [SerializeField, Min(0.0f)] private float createDelay = 1.5f;
    [SerializeField] private Transform[] spawnPoints = null;

    [Header("Other objects")]
    [SerializeField] private GameObject player = null;

    private EntityCreator entityCreator = null;

    private void Awake()
    {
        entityCreator = new EntityCreator();
    }

    private void Update()
    {
        entityCreator.CreateEntity(asteroid, asteroidLookatPosition, minAngle, maxAngle,
            enemy, player,
            spawnPoints, createDelay, enemySpawnChance);
    }
}
