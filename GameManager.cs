using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Player")]
    public PlayerController player;

    [Header("UI")]
    public TextMeshProUGUI scoreText;
    public GameObject winPanel;

    [Header("Game Stats")]
    public int lives = 3;
    public int score = 0;
    public int totalCoins = 0;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UpdateUI();
        if (winPanel != null)
            winPanel.SetActive(false);
    }

    public void LoseLife()
    {
        lives--;

        if (lives > 0)
        {
            player.Respawn();
        }
        else
        {
            Debug.Log("Game Over");
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateUI();

        if (score >= totalCoins)
        {
            WinGame();
        }
    }

    void UpdateUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score + " / " + totalCoins;
        }
    }

    void WinGame()
    {
        Debug.Log("YOU WIN!");

        if (winPanel != null)
            winPanel.SetActive(true);
    }
}