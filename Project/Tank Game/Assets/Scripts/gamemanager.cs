using TMPro;
using UnityEngine;
using UnityEngine.Rendering;


public class gamemanager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI scoreText;

    public float playerHealth;
    public float playerMaxHealth;
    public int score;

    public PlayerMovement PlayerMovement;

    public GameOverScreen gameOverScreen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerHealth = playerMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Health()
    {
        
    }

    public void IncreaseScore(int amount)
    {
        var scoreText = GetComponent<TextMeshProUGUI>();
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
    public void ShowPauseMenu()
    {
        // Logic to display pause menu UI
    }
    public void ShowGameOver()
    {
        // Logic to display game over UI
        //gameOverScreen.Setup(score: score);
    }
}
