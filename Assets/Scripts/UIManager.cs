using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI score;
    public TMPro.TextMeshProUGUI time;

    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = GameManager.Instance;
    }

    private void Update()
    {
        score.text = $"Score: {_gameManager.ScoreManager.Score}";
        time.text = $"Time: {_gameManager.TimeManager.RemainingTime.ToString("0.00")}";
    }
}
