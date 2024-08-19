using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void About()
    {
        SceneManager.LoadScene("About");
    }

    public void Exit()
    {
        Application.Quit();
    }
}