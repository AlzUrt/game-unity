using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public int Score { get; private set; } = 0;
    public int BestScore { get; private set; } = 0;
    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = GameManager.Instance;
        _gameManager.RupeeManager.OnRupeeCollected += RupeeCollectedHandler;
    }

    private void Start()
    {
        BestScore = PlayerPrefs.GetInt("BestScore", 0);
    }

    private void RupeeCollectedHandler(Rupee rupee)
    {
        Score++;

        if (Score > BestScore)
        {
            BestScore = Score;
            PlayerPrefs.SetInt("BestScore", BestScore);
        }
    }

    public void startGame()
    {
        Score = 0;
    }
}
