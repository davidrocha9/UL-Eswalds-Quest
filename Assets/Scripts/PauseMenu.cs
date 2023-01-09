using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenuUI;
    [SerializeField] private GameObject DeathMenuUI;
    [SerializeField] private GameObject StatsUI;

    [SerializeField] private bool isPaused;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            isPaused = !isPaused;
        }

        Debug.Log(GameManager.gameManager._playerHealth.Health);
        
        if(GameManager.gameManager._playerHealth.Health <= 0 ) {
            isPaused = true;
            StatsUI.SetActive(false);
            DeathMenuUI.SetActive(true);
        }

        if(isPaused) {
            activateMenu();
        }else {
            deactivateMenu();
        }
    }

    void activateMenu() {
        Time.timeScale = 0;
        AudioListener.pause = true;
        PauseMenuUI.SetActive(true);
    }

    public void jumpMainMenu() {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void restartScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void deactivateMenu() {
        Time.timeScale = 1;
        AudioListener.pause = false;
        PauseMenuUI.SetActive(false);
        isPaused = false;
    }
}
