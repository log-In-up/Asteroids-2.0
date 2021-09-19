using UnityEngine;

class AsteroidMovement
{
    public void MoveForward(Transform asteroid, float movementSpeed)
    {
        asteroid.Translate(movementSpeed * Time.deltaTime * Vector2.up);
    }
}
