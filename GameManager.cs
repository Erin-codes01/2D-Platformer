using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Player")]
    public PlayerController player;

    [Header("UI")]
    public TextMeshProUGUI scoreText;
    public GameObject winPanel;

    [Header("Game Settings")]
    public int lives = 3;
    public int score = 0;
    public int totalCoins = 0;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        if (winPanel != null)
            winPanel.SetActive(false);

        totalCoins = FindObjectsOfType<CoinSimple>().Length;

        UpdateUI();
    }

    // ---------------- LIFE ----------------
    public void LoseLife()
    {
        lives--;

        if (lives > 0)
        {
            player.Respawn();
        }
        else
        {
            RestartGame();
        }
    }

    // ---------------- SCORE ----------------
    public void AddScore(int amount)
    {
        score += amount;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score + " / " + totalCoins;
        }
    }

    // ---------------- WIN CHECK ----------------
    public void TryWin()
    {
        if (score >= totalCoins)
        {
            WinGame();
        }
        else
        {
            Debug.Log("Collect all coins first!");
        }
    }

    void WinGame()
    {
        Debug.Log("YOU WIN!");

        if (winPanel != null)
            winPanel.SetActive(true);

        Time.timeScale = 0f;
    }

    // ---------------- RESTART ----------------
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}