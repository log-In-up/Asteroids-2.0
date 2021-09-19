using UnityEngine;

[CreateAssetMenu(fileName = "PlayerCharacteristics", menuName = "ScriptableObjects/PlayerCharacteristics", order = 1)]
public class PlayerCharacteristics : ScriptableObject
{
    [SerializeField, Min(0.0f)] private float movementSpeed = 5.0f;
    [SerializeField, Min(0.0f)] private float laserRollbackTime = 2.0f;
    [SerializeField, Min(0.0f)] private float laserReloadTime = 5.0f;
    [SerializeField, Min(0.0f)] private float laserDistance = 50.0f;
    [SerializeField, Min(0.0f)] private float showLaserDelay = 0.2f;
    [SerializeField, Min(0)] private int laserShots = 3;

    public float LaserDistance => laserDistance;

    public float LaserReloadTime => laserReloadTime;

    public float LaserRollbackTime => laserRollbackTime;

    public int LaserShots => laserShots;

    public float MovementSpeed => movementSpeed;

    public float ShowLaserDelay => showLaserDelay;
}
