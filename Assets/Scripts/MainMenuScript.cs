using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void GoToLose() 
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(2);
    }
    public void GoToWin()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(3);
    }

}
