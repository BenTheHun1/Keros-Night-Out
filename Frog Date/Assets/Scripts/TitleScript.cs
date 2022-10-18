using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour
{
    [SerializeField] GameObject creditsPanel;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Starts the game - brings the player to the main game.
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    // Opens the credits page.
    public void OpenCredits()
    {
        creditsPanel.SetActive(true);
    }

    // Closes the credits page.
    public void CloseCredits()
    {
        creditsPanel.SetActive(false);
    }

    // Closes the game.
    public void QuitGame()
    {
        Application.Quit();
    }
}