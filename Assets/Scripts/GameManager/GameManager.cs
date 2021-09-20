using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[DisallowMultipleComponent]
public class GameManager : MonoBehaviour
{
    [SerializeField] private Button restartGameButton = null;

    public UnityEvent OnFinishTheGame = null;

    private const float NORMAL_TIME_SCALE = 1.0f, STOP_TIME_SCALE = 0.0f;

    private GameManagerActions managerActions = null;

    private void Awake()
    {
        managerActions = new GameManagerActions();

        managerActions.SetTimeScale(NORMAL_TIME_SCALE);
    }

    private void OnEnable()
    {
        OnFinishTheGame.AddListener(FinishTheGame);
        restartGameButton.onClick.AddListener(managerActions.RestartGame);
    }

    private void OnDisable()
    {
        OnFinishTheGame.RemoveListener(FinishTheGame);
        restartGameButton.onClick.RemoveListener(managerActions.RestartGame);
    }

    private void FinishTheGame()
    {
        managerActions.SetTimeScale(STOP_TIME_SCALE);        
    }
}
