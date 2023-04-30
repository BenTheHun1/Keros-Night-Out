using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Fungus;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject pauseMenu;
    public AudioSource sfx;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            PauseGame();
        }
    }

    // Pauses the game and opens up the pause menu.
    public void PauseGame()
    {
        if (pauseMenu.activeSelf)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
            sfx.UnPause();
            sfx.loop = true;
			FindObjectOfType<Flowchart>().SetBooleanVariable("paused", false);

		}
        else
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            sfx.Pause();
			FindObjectOfType<Flowchart>().SetBooleanVariable("paused", true);
		}
    }

    // Returns the player to the title screen.
    public void ReturnMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}