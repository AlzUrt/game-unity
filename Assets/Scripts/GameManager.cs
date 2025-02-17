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
        TimeManager.reset();
        TimeManager.StartTimer();
    }
}
