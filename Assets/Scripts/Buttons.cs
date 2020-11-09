using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Buttons : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("Level01");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Play()
    {
        SceneManager.LoadScene("Level01");
    }

    public void Exit()
    {
        EditorApplication.isPlaying = false;
    }
}
