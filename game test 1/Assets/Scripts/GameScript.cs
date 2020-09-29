using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour
{
    public string gameScene;
    public string menuScene;
    public GameObject pausePanel;
    public GameObject gameOver;

    private bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene(gameScene);
        }
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(isPaused){
                isPaused = true;
                pausePanel.SetActive(true);
                Time.timeScale = 0;

            }
            else{
                isPaused = false;
                pausePanel.SetActive(false);
                Time.timeScale = 1;
            }

        }    
    }

    public void QuitGame(){
        SceneManager.LoadScene(menuScene);
    }

    public void Restart(){
        SceneManager.LoadScene(gameScene);
    }

    public void Die(){
        gameOver.SetActive(true);
    }

}
