using TMPro;
using UnityEngine;
using UnityEngine.Rendering;


public class gamemanager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI scoreText;

    public float playerHealth;
    public float playerMaxHealth;
    public int score;

    public GameObject pauseScreen;
    PlayerMovement PlayerMovement;

    //public GameOverScreen gameOverScreen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerHealth = PlayerMovement.currentHealth;
        playerMaxHealth = PlayerMovement.maxHealth;
        score = PlayerMovement.score;
    }

    // Update is called once per frame
    void Update()
    {
        ShowPauseMenu();
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
        if (Input.GetButtonDown("Pause"))
        {
            if (pauseScreen.activeSelf)
            {
                // We're paused, so unpause
                UnPause();
            }
            else
            {
                // We're unpaused, so pause
                Pause();
            }
        }
    }

    public void Pause()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void UnPause()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Save()
    {
        PlayerPrefs.SetInt("PlayerScore", PlayerMovement.score);
        PlayerPrefs.SetInt("PlayerHP", PlayerMovement.currentHealth);
        PlayerPrefs.SetFloat("PlayerPositionX", PlayerMovement.transform.position.x);
        PlayerPrefs.SetFloat("PlayerPositionY", PlayerMovement.transform.position.y);
        PlayerPrefs.SetFloat("PlayerPositionZ", PlayerMovement.transform.position.z);
        PlayerPrefs.Save();
    }

    public void Load()
    {
        PlayerMovement.score = PlayerPrefs.GetInt("PlayerScore");
        PlayerMovement.currentHealth = PlayerPrefs.GetInt("PlayerHP");
        PlayerMovement.transform.position = new Vector3(
            PlayerPrefs.GetFloat("PlayerPositionX"),
            PlayerPrefs.GetFloat("PlayerPositionY"),
            PlayerPrefs.GetFloat("PlayerPositionZ"));
        
    }
    public void ShowGameOver()
    {
        // Logic to display game over UI
        //gameOverScreen.Setup(score: score);
    }
}
