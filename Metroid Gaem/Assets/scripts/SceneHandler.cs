using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("Quit the game");
        Application.Quit();
    }
    /// <summary>
    /// switches the scene based on the build index
    /// </summary>
    /// <param name="buildIndex"></param>
    public void SwitchScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }
}
