using UnityEngine;

class ShortLaserMovement
{
    public void MoveForward(Transform laser, float movementSpeed)
    {
        laser.Translate(movementSpeed * Time.deltaTime * Vector2.up);
    }
}
