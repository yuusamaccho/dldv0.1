using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_ButtonClick : MonoBehaviour
{
    public AudioSource buttonClick;

    private void Awake()
    {
        DontDestroyOnLoad(this);

        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }

    }

    public void ButtonClickSound()
    {
        buttonClick.Play();
    }

}
