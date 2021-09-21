using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

[DisallowMultipleComponent]
public class GameManager : MonoBehaviour
{
    [SerializeField] private Button restartGameButton = null;
    [SerializeField] private Transform player = null;

    [SerializeField] private TextMeshProUGUI totalScoreInGame = null;
    [SerializeField] private TextMeshProUGUI totalScoreFailedGame = null;

    private GameManagerActions managerActions = null;
    private const float NORMAL_TIME_SCALE = 1.0f, STOP_TIME_SCALE = 0.0f;

    [HideInInspector] public GameManagerEvents AddPoints = null;
    public UnityEvent OnFinishTheGame = null;

    private void Awake()
    {
        managerActions = new GameManagerActions();
        AddPoints = new GameManagerEvents();

        managerActions.SetTimeScale(NORMAL_TIME_SCALE);
    }

    private void OnEnable()
    {
        OnFinishTheGame.AddListener(FinishTheGame);
        AddPoints.AddListener(AddScorePoints);

        restartGameButton.onClick.AddListener(managerActions.RestartGame);
    }

    private void Start()
    {
        managerActions.ResetScorePoints(totalScoreInGame, totalScoreFailedGame);
    }

    private void Update()
    {
        managerActions.KeepPlayerInBounds(player, Camera.main);
    }

    private void OnDisable()
    {
        OnFinishTheGame.RemoveListener(FinishTheGame);
        AddPoints.RemoveListener(AddScorePoints);

        restartGameButton.onClick.RemoveListener(managerActions.RestartGame);
    }

    private void FinishTheGame()
    {
        managerActions.SetTimeScale(STOP_TIME_SCALE);        
    }

    private void AddScorePoints(int points)
    {
        managerActions.AddScorePoints(points, totalScoreInGame, totalScoreFailedGame);
    }
}
