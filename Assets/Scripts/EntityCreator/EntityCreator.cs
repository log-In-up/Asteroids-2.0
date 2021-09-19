using UnityEngine;
using Pathfinding;

class EntityCreator
{
    private float nextShot = 0.0f;

    private const float ONE_HUNDRED_PERCENT = 100.0f, ZERO_PERCENT = 0.0f;
    private const int FIRST_SPAWN_POINT = 0;

    public void CreateEntity(GameObject asteroid, Transform asteroidLookAtPosition, float asteroidMinAngle, float asteroidMaxAngle,
        GameObject enemy, GameObject player, Transform[] spawnPositions, float crateDelay, float chanceToSpawnEnemy)
    {
        if (Time.time > nextShot)
        {
            float randomNumber = Random.Range(ZERO_PERCENT, ONE_HUNDRED_PERCENT);
            int randomPosition = Random.Range(FIRST_SPAWN_POINT, spawnPositions.Length);

            if (randomNumber >= chanceToSpawnEnemy)
            {
                CreateEnemy(enemy, spawnPositions[randomPosition], player.transform);
            }
            else
            {
                float angleOffset = Random.Range(asteroidMinAngle, asteroidMaxAngle);

                CreateAsteroid(asteroid, spawnPositions[randomPosition], asteroidLookAtPosition, angleOffset);
            }

            nextShot = Time.time + crateDelay;
        }
    }

    private void CreateEnemy(GameObject enemy, Transform position, Transform player)
    {
        GameObject enemyEntity = Object.Instantiate(enemy, position.position, position.rotation);
        enemyEntity.GetComponent<AIDestinationSetter>().target = player;
    }

    private void CreateAsteroid(GameObject asteroid, Transform position, Transform lookAtPoint, float angleOffset)
    {
        float xRotationAngle = 0.0f, yRotationAngle = 0.0f;

        float angle = Mathf.Atan2(asteroid.transform.position.y - lookAtPoint.position.y, asteroid.transform.position.x - lookAtPoint.position.x) * Mathf.Rad2Deg;
        Quaternion asteroidRotation = Quaternion.Euler(new Vector3(xRotationAngle, yRotationAngle, angle + angleOffset));

        GameObject meteorite = Object.Instantiate(asteroid, position.position, asteroidRotation);

        //meteorite.transform.LookAt(lookAtPoint);
    }
}
