using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScript : MonoBehaviour
{
    public void Redo()
    {
        SceneManager.LoadScene("MainGameScene");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
