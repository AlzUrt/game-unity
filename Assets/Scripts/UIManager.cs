using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI score;
    public TMPro.TextMeshProUGUI time;

    public GameObject startButton;
    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = GameManager.Instance;
    }

    private void Update()
    {
        score.text = $"Score: {_gameManager.ScoreManager.Score}";

        float remainingTime = _gameManager.TimeManager.RemainingTime;
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        time.text = $"{minutes:00}:{seconds:00}";
    }

    public void StartGame()
    {
        startButton.SetActive(false);
    }

    public void StopGame()
    {
        startButton.SetActive(true);
    }
}
