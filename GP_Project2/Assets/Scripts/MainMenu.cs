﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource MainMenuMusic;

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
            Debug.Log("QUIT");
        }
    }
    public void PlayGame ()
    {
        SceneManager.LoadScene("MainLevel");
    }
    public void QuitGame ()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
