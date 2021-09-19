using UnityEngine;

class SmallAsteroidCreator
{
    public void CreateAmountAsteroids(GameObject asteroid, Transform currentPosition, int minAmountOfSmallAsteroids, int maxAmountOfSmallAsteroids, float spawnRadius)
    {
        int amountOfAsteroids = Random.Range(minAmountOfSmallAsteroids, maxAmountOfSmallAsteroids);

        for (int i = 0; i < amountOfAsteroids; i++)
        {
            Object.Instantiate(asteroid, (Vector2)currentPosition.position + (Random.insideUnitCircle * spawnRadius), currentPosition.rotation);
        }
    }
}
