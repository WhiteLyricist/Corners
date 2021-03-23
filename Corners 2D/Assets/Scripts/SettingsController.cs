using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SettingsController : MonoBehaviour
{

    public void Exit()
    {
        Application.Quit();
    }

    public void SetParametersClassic()
    {
        GameParameters.GameParametr(0);
        SceneManager.LoadScene("Game Scene");
    }
    public void SetParametersDiagonal()
    {
        GameParameters.GameParametr(2);
        SceneManager.LoadScene("Game Scene");
    }
    public void SetParametersLinear()
    {
        GameParameters.GameParametr(1);
        SceneManager.LoadScene("Game Scene");
    }

    public void Menu() 
    {
        Destroy(GameObject.FindObjectOfType<SceneController>());
        SceneManager.LoadScene("Menu");
    }

}
