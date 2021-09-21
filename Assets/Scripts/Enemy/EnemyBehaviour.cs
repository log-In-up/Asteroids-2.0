using UnityEngine;
using UnityEngine.Events;

[DisallowMultipleComponent]
public class EnemyBehaviour : MonoBehaviour
{
    [Header("Enemy characteristics")]
    [SerializeField, Min(0)] private int pointsForDestroy = 1;

    private GameManager gameManager = null;

    [HideInInspector] public UnityEvent OnHit = null;

    private void OnEnable()
    {
        OnHit.AddListener(OnHitEnemy);
    }

    private void Start()
    {
        gameManager = (GameManager)FindObjectOfType(typeof(GameManager));
    }

    private void OnDisable()
    {
        OnHit.RemoveListener(OnHitEnemy);
    }

    private void OnHitEnemy()
    {
        gameManager.AddPoints.Invoke(pointsForDestroy);
    }
}
