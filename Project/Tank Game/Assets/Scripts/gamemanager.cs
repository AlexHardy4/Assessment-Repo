using UnityEngine;
using UnityEngine.Rendering;


public class gamemanager : MonoBehaviour
{
    public float playerHealth;
    public float playerMaxHealth;
    public float enemyHealth;
    public int score;


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
        score += amount;
    }
}
