using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_MainMenu : MonoBehaviour
{
    public GameObject MainMenuUI;
    public GameObject OptionsUI;
    public Script_ButtonClick buttonClick;

    private void Awake()
    {
        DontDestroyOnLoad(this);

        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }

    }


    public void StoryMode()
    {
        buttonClick.ButtonClickSound();
        Debug.Log("entrou Story Mode");
        //SceneManager.LoadScene("Story_Mode");
    }

    public void EndlessMode()
    {
        buttonClick.ButtonClickSound();
        Debug.Log("entrou Endless Mode");
        //SceneManager.LoadScene("Endless_Mode");
    }

    public void Options()
    {
        buttonClick.ButtonClickSound();
        Debug.Log("entrou Options");
        MainMenuUI.SetActive(false);
        OptionsUI.SetActive(true);
        
    }

    public void BackMainMenu()
    {
        buttonClick.ButtonClickSound();
        Debug.Log("saiu Options");
        OptionsUI.SetActive(false);
        MainMenuUI.SetActive(true);

    }

    public void Exit()
    {
        buttonClick.ButtonClickSound();
        Debug.Log("Saiu do jogo");
        Application.Quit();
    }

    public void Demo()
    {
        buttonClick.ButtonClickSound();
        Debug.Log("entrou demo");
        SceneManager.LoadScene("Demo");
    }

}
