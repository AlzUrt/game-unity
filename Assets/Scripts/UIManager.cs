using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI score;

    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = GameManager.Instance;
    }

    private void Update()
    {
        score.text = $"Score: {_gameManager.ScoreManager.Score}";
    }
}
