using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;



public class MenuController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    public void Play()
    {
        SceneManager.LoadScene("PlayMenu");
    }

    public void SinglePlayer()
    {
        SceneManager.LoadScene("SinglePlayer");
    }

    public void Multiplayer()
    {
        SceneManager.LoadScene("MultiPlayer");
    }

    public void Options()
    {
        SceneManager.LoadScene("OptionsMenu");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
