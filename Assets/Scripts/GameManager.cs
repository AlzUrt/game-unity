using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public RupeeManager RupeeManager { get; private set; }
    public ScoreManager ScoreManager { get; private set; }
    public UIManager UIManager { get; private set; }
    public TimeManager TimeManager { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        RupeeManager = GetComponent<RupeeManager>();
        ScoreManager = GetComponent<ScoreManager>();
        TimeManager = GetComponent<TimeManager>();
        UIManager = GetComponent<UIManager>();
    }

    private void Start()
    {
        TimeManager.OnTimeOver += TimeOverHandler;
    }

    private void TimeOverHandler()
    {
        StopGame();
    }

    public void StartGame()
    {
        TimeManager.reset();

        UIManager.StartGame();
        TimeManager.StartTimer();
        ScoreManager.startGame();
        RupeeManager.StartSpawning();
    }

    public void StopGame()
    {
        UIManager.StopGame();
        RupeeManager.StopSpawning();
        RupeeManager.DestroyAllRupees();
        TimeManager.StopTimer();
    }
}
