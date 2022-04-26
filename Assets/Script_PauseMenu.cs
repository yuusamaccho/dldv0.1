using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_PauseMenu : MonoBehaviour
{
    public bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject interfaceUI;
    public GameObject configUI;

    public Script_ButtonClick buttonClick;

    private void Awake()
    {
        DontDestroyOnLoad(this);

        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        CheckPauseMenu();
    }

    public void Resume()
    {
        buttonClick.ButtonClickSound();

        interfaceUI.SetActive(true);
        pauseMenuUI.SetActive(false);
        configUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

     public void Pause()
    {
        interfaceUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void MainMenu()
    {
        Debug.Log("voltou menu principal");
        //Destroy(GameObject.FindGameObjectWithTag("allScript"));
        //Destroy(GameObject.FindGameObjectWithTag("oceanSound"));

        SceneManager.LoadScene("Main_Menu");
        Resume();
    }

    public void Config()
    {
        buttonClick.ButtonClickSound();

        Debug.Log("entra nas opções");
        interfaceUI.SetActive(false);
        pauseMenuUI.SetActive(false);
        configUI.SetActive(true);

    }

    public void Sair()
    {
        buttonClick.ButtonClickSound();

        Debug.Log("saiu do jogo");
        Application.Quit();
    }


    void CheckPauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape) /*&& (GameObject.FindObjectOfType<Script_WinLose>().gameIsPaused == false)*/)
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

}
