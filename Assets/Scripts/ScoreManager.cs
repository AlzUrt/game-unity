using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public int Score { get; private set; } = 0;
    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = GameManager.Instance;
        _gameManager.RupeeManager.OnRupeeCollected += RupeeCollectedHandler;
    }

    private void RupeeCollectedHandler(Rupee rupee)
    {
        Score++;
        Debug.Log($"Score: {Score}");
    }
}
