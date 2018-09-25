using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausemenu : MonoBehaviour
{
    [SerializeField]
    public static bool GameIsPaused = false;

    //[SerializeField]
    //Behaviour[] componentsToDisableIfPaused;

    public GameObject pauseMenuUI;
    //// Update is called once per frame
    private void Start()
    {
        pauseMenuUI.SetActive(false);
    }
    private void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            
            if (GameIsPaused)
            {
                
              
                Resume();
            }
            else
            { 
                Pause();
            }
        }

    }

    public void Resume()
    {

        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }

}
//    public void enableOnResume()
//    {
//        for (int i = 0; i < componentsToDisableIfPaused.Length; i++)
//        {
//            componentsToDisableIfPaused[i].enabled = true;


//        }
//    }
//}
