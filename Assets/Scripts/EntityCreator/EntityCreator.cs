using UnityEngine;
using Pathfinding;

class EntityCreator
{
    private float nextSpawnTime = 0.0f;

    private const float ONE_HUNDRED_PERCENT = 100.0f, ZERO_PERCENT = 0.0f;
    private const int FIRST_SPAWN_POINT = 0;

    public void CreateEntity(GameObject asteroid, Transform asteroidLookAtPosition, float asteroidMinAngle, float asteroidMaxAngle,
        GameObject enemy, GameObject player, Transform[] spawnPositions, float crateDelay, float chanceToSpawnAsteroid)
    {
        if (Time.time > nextSpawnTime)
        {
            float randomNumber = Random.Range(ZERO_PERCENT, ONE_HUNDRED_PERCENT);
            int randomPosition = Random.Range(FIRST_SPAWN_POINT, spawnPositions.Length);

            if (randomNumber >= chanceToSpawnAsteroid)
            {
                CreateEnemy(enemy, spawnPositions[randomPosition], player.transform);
            }
            else
            {
                CreateAsteroid(asteroid, spawnPositions[randomPosition], asteroidLookAtPosition, asteroidMinAngle, asteroidMaxAngle);
            }

            nextSpawnTime = Time.time + crateDelay;
        }
    }

    private void CreateEnemy(GameObject enemy, Transform position, Transform player)
    {
        GameObject enemyEntity = Object.Instantiate(enemy, position.position, position.rotation);
        enemyEntity.GetComponent<AIDestinationSetter>().target = player;
    }

    private void CreateAsteroid(GameObject asteroid, Transform position, Transform lookAtPoint, float asteroidMinAngle, float asteroidMaxAngle)
    {
        float xRotationAngle = 0.0f, yRotationAngle = 0.0f, angleRotationOffset = 90.0f;

        float angle = Mathf.Atan2(
            position.position.y - lookAtPoint.transform.position.y,
            position.position.x - lookAtPoint.transform.position.x)
            * Mathf.Rad2Deg + angleRotationOffset;

        float angleOffset = Random.Range(asteroidMinAngle, asteroidMaxAngle);

        Quaternion asteroidRotation = Quaternion.Euler(new Vector3(xRotationAngle, yRotationAngle, angle + angleOffset));

        Object.Instantiate(asteroid, position.position, asteroidRotation);
    }
}
